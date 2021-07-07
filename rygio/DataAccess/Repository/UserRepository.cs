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

namespace rygio.DataAccess.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;
        public UserRepository(ApplicationDbContext context, IOptions<AppSettings> appSettings) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _appSettings = appSettings.Value;

        }

        public Task<User> Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangePassword(int userId, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ConfirmEmail(string email, string code)
        {
            throw new NotImplementedException();
        }

        public Task<User> FacebookAuthentication(string accessToken)
        {
             var authUser = ExternalProviders.GetFacebookAccountDetails(_appSettings.FacebookAuthUrl,accessToken);
            throw new NotImplementedException();
        }

        public async Task<User> GoogleAuthentication(string accessToken)
        {
            GoogleCredential cred = GoogleCredential.FromAccessToken(accessToken);
            var peopleService = new PeopleServiceService(new BaseClientService.Initializer { HttpClientInitializer = cred, ApplicationName = "Rygio" });
            var peopleRequest = peopleService.People.Get("people/me");
            peopleRequest.RequestMaskIncludeField = new List<string> { "person.names", "person.EmailAddresses", "person.Photos","person.PhoneNumbers" };
            var profile =  peopleRequest.Execute();
            if (profile != null)
                return new User {
                Name = profile?.Names[0]?.DisplayName,
                Email = profile?.EmailAddresses[0]?.Value,
                //Phone = profile?.PhoneNumbers[0]?.CanonicalForm,
                Photo = profile?.Photos[0]?.Url
            };
            throw new NullReferenceException();
        }

        public Task<bool> GoogleRegister(string accessToken, string sGooAuth)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(User user, string password, string passwordConfirmation)
        {
            throw new NotImplementedException();
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



    }
}
