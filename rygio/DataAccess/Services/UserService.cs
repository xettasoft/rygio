using Microsoft.Extensions.Options;
using rygio.Domain.AppData;
using rygio.Domain.Interface;
using rygio.Helper;
using System;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.PeopleService.v1;
using Google.Apis.Services;
using System.Collections.Generic;
using Google.Apis.Auth.OAuth2;
using rygio.Command.v1.Dtos.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace rygio.DataAccess.Repository
{
    public class UserService : Service<User>, IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;
        public UserService(ApplicationDbContext context, IOptions<AppSettings> appSettings) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _appSettings = appSettings.Value;

        }

        public async Task<User> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new AppException("Username or password is incorrect.");

            var user = await _context.Users.Include(x => x.RefreshTokens.Where(x => x.Revoked == null)).SingleOrDefaultAsync(x => x.Email == username || x.Phone == username || x.Username == username);

            // check if user exists
            if (user == null)
                throw new AppException("User does not exist.");

            //Check if user is confirmed
            if (!user.IsEmailConfirmed && _appSettings.EmailConfirmation)
                throw new AppException("Email is not confirmed.");

            if (_appSettings.PhoneConfirmation && !user.IsPhoneConfirmed)
                throw new AppException("Phone is not confirmed.");

            //Check if user is active
            if (!user.IsActive)
                throw new AppException("Account is not active.");

            //Throttle request 
            if (user.LoginFailedDate != null)
            {
                var ts = DateTime.UtcNow - user.LoginFailedDate.GetValueOrDefault();
                var secondsPassed = ts.TotalSeconds;
                var isMaxCountExceeded = user.LoginFailedCount >= _appSettings.MaxLoginFailedCount;
                var isWaitingTimePassed = secondsPassed > _appSettings.LoginFailedWaitingTime;

                if (isMaxCountExceeded && !isWaitingTimePassed)
                {
                    var secondsToWait = _appSettings.LoginFailedWaitingTime - secondsPassed;
                    throw new AppException(string.Format(
                        "You must wait for {0} minutes before you try to log in again.", (int)(Math.Floor((double)(secondsToWait / 60))) + 1));
                }
            }

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                user.LoginFailedCount += 1;
                user.LoginFailedDate = DateTime.UtcNow;
                _context.Update(user);
                await _context.SaveChangesAsync();
                throw new AppException("Username or password is incorrect.");
            }

            // authentication successful
            user.LoginFailedCount = 0;
            user.LoginFailedDate = null;
            user.LastLoginDate = DateTime.UtcNow;
            _context.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task<bool> ChangePassword(int userId, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ConfirmEmail(string email, string code)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FacebookAuthentication(string accessToken)
        {
             var authUser = ExternalProviders.GetFacebookAccountDetails(_appSettings.FacebookAuthUrl,accessToken);
            var user = await _context.Users.Include(x => x.RefreshTokens.Where(x => x.Revoked == null)).SingleOrDefaultAsync(x => x.Email == authUser.Email || x.FacebookId == authUser.Id);
            if (authUser.Email != null && user != null) {
                user.EmailConfirmedDate = DateTime.Now;
                user.IsEmailConfirmed = true;
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
            return user;
        }

        public async Task<User> GoogleAuthentication(string accessToken)
        {
            GoogleCredential cred = GoogleCredential.FromAccessToken(accessToken);
            var peopleService = new PeopleServiceService(new BaseClientService.Initializer { HttpClientInitializer = cred, ApplicationName = "Rygio" });
            var peopleRequest = peopleService.People.Get("people/me");
            peopleRequest.RequestMaskIncludeField = new List<string> { "person.names", "person.EmailAddresses", "person.Photos","person.PhoneNumbers" };
            var profile =  peopleRequest.Execute();
            if (profile == null) throw new AppException("Error fetching user details from google.");
            var user = await _context.Users.Include(x => x.RefreshTokens.Where(x => x.Revoked == null)).SingleOrDefaultAsync(x => x.Email == profile.EmailAddresses[0].Value);
            if (!string.IsNullOrEmpty(profile?.EmailAddresses[0]?.Value))
            {
                user.EmailConfirmedDate = DateTime.Now;
                user.IsEmailConfirmed = true;
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
            return user;
        }



        public async Task<bool> Register(User user, string password, string passwordConfirmation)
        {

            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required.");
       

            if (!string.IsNullOrWhiteSpace(password) && (password != passwordConfirmation))
                throw new AppException("Password and Confirm password do not match.");
           


            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Phone == user.Phone || x.Email == user.Email);

            if (existingUser?.Phone == user.Phone)
                throw new AppException(string.Format("Phone '{0}' is already taken.", user.Phone));
           

            if (existingUser?.Email == user.Email)
                throw new AppException(string.Format("Email '{0}' is already taken.", user.Email));
            

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.CreatedDate = DateTime.UtcNow;
            user.EmailConfirmationCode = RandomGenerator.GenerateEmailCode(42);
            user.PhoneConfirmationCode = RandomGenerator.GeneratePhoneCode(6);
            user.IsActive = true;
            //End
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<bool> ResetPassword(string username, string code, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendConfirmEmailLink(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendResetPasswordLink(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendResetPasswordOtp(string phone)
        {
            throw new NotImplementedException();
        }


        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<RefreshTokenResponse> RefreshToken(string refreshtoken)
        {

            
            var token = await _context.RefreshTokens.SingleOrDefaultAsync(r => r.Token == refreshtoken);
            if (token == null) throw new AppException("Token did not match any users.");


            if (token.IsExpired || !token.IsActive) {
                if (token.IsExpired  && token.Revoked == null) {
                    token.Revoked = DateTime.UtcNow;
                    var newRefreshToken = RandomGenerator.CreateRefreshToken(token.UserId, _appSettings.RefreshTokenExpiration);
                    _context.RefreshTokens.Add(newRefreshToken);
                    _context.SaveChanges();
                }
                throw new AppException("Token can not be refreshed please re-login to obtain new token.");
            }
            var expiry = DateTime.UtcNow.AddMinutes(_appSettings.AccessTokenExpiration);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, token.UserId.ToString()) }),
                Expires = expiry,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var accesstoken = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(accesstoken);

            return new RefreshTokenResponse {
                AccessToken = tokenString,
                AccessTokenExpiration = expiry,
            };
        

        }

        public async Task<string> RevokeRefreshToken(string refreshtoken)
        {
            var token = await _context.RefreshTokens.SingleOrDefaultAsync(r => r.Token == refreshtoken);
            if (token == null) throw new AppException("Token did not match any users.");

            if (token.IsExpired || !token.IsActive)
            {
                throw new AppException("Token is not active or has expired.");
            }

            token.Revoked = DateTime.UtcNow;
            _context.SaveChanges();
            return "Token has been successfully revoked.";
        }

        public async Task<bool> FacebookRegister(string accessToken)
        {
            var authUser = ExternalProviders.GetFacebookAccountDetails(_appSettings.FacebookAuthUrl, accessToken);

            if(authUser == null ) throw new AppException("Error Fetching user details from facebook");

            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == authUser.Email || x.FacebookId == authUser.Id);

            if (user != null) throw new AppException("User already eisting. Please login to access account.");

            var newUser = new User { 
            Name = authUser.Name,
            FacebookId = authUser.Id,
            DateOfBirth = authUser.Birthday,
            Email = authUser.Email,
            IsActive = true,
            };

            if (!string.IsNullOrEmpty(authUser.Email))
            {
                newUser.EmailConfirmedDate = DateTime.Now;
                newUser.IsEmailConfirmed = true;
                
            }

            var password = RandomGenerator.GenerateEmailCode(8);


            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;
            newUser.CreatedDate = DateTime.UtcNow;
            newUser.EmailConfirmationCode = RandomGenerator.GenerateEmailCode(42);
            newUser.PhoneConfirmationCode = RandomGenerator.GeneratePhoneCode(6);
 
            //End
            await _context.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> GoogleRegister(string accessToken)
        {
            GoogleCredential cred = GoogleCredential.FromAccessToken(accessToken);
            var peopleService = new PeopleServiceService(new BaseClientService.Initializer { HttpClientInitializer = cred, ApplicationName = "Rygio" });
            var peopleRequest = peopleService.People.Get("people/me");
            peopleRequest.RequestMaskIncludeField = new List<string> { "person.names", "person.EmailAddresses", "person.Photos", "person.PhoneNumbers", "person.Birthdays" };
            var profile = peopleRequest.Execute();

            if (profile == null) throw new AppException("Error Fetching user details from google");

            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == profile.EmailAddresses[0].Value);

            if (user != null) throw new AppException("User already eisting. Please login to access account.");

            var newUser = new User
            {
                Name = profile?.Names[0]?.UnstructuredName,
               // DateOfBirth = profile?.Birthdays[0].Date,
                Email = profile?.EmailAddresses[0]?.Value,
                Photo = profile?.Photos[0]?.Url,
                IsActive = true,
            };

            if (!string.IsNullOrEmpty(profile?.EmailAddresses[0]?.Value))
            {
                newUser.EmailConfirmedDate = DateTime.Now;
                newUser.IsEmailConfirmed = true;

            }

            var password = RandomGenerator.GenerateEmailCode(8);


            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;
            newUser.CreatedDate = DateTime.UtcNow;
            newUser.EmailConfirmationCode = RandomGenerator.GenerateEmailCode(42);
            newUser.PhoneConfirmationCode = RandomGenerator.GeneratePhoneCode(6);

            //End
            await _context.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
