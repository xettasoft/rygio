using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using rygio.Command.v1.Dtos.Response;
using rygio.Domain.AppData;
using rygio.Domain.Interface;
using rygio.Helper;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace rygio.Command.v1
{
    public class GoogleAuthenticationCommand : IRequest<AuthResponse>
    {
        public ExternalAuthDto googleAuthDto { get; set; }

        public class GoogleAuthenticationCommandHandler : IRequestHandler<GoogleAuthenticationCommand, AuthResponse>
        {
            private readonly IUserService userRepository;
            private readonly IMapper mapper;
            private readonly IRepository<RefreshToken> refreshTokenRepository;
            private readonly AppSettings _appSettings;

            public GoogleAuthenticationCommandHandler(IUserService userRepository, IRepository<RefreshToken> refreshTokenRepository, IMapper mapper, IOptions<AppSettings> appSettings)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
                this.refreshTokenRepository = refreshTokenRepository ?? throw new ArgumentNullException(nameof(refreshTokenRepository));
            }

            public async Task<AuthResponse> Handle(GoogleAuthenticationCommand request, CancellationToken cancellationToken)
            {

                var user = await userRepository.GoogleAuthentication(request.googleAuthDto.AccessToken);
                var expiry = DateTime.UtcNow.AddMinutes(_appSettings.AccessTokenExpiration);
                var authRes = mapper.Map<AuthResponse>(user);

                if (user == null) throw new AppException("No such user in our database.");

                if (user.RefreshTokens.Any(a => a.IsActive))
                {
                    var activeRefreshToken = user.RefreshTokens.Where(a => a.IsActive == true).FirstOrDefault();
                    authRes.RefreshToken = activeRefreshToken.Token;
                    authRes.RefreshTokenExpiration = activeRefreshToken.Expires;
                    // activeRefreshToken.Revoked = DateTime.UtcNow;
                }
                else
                {

                    var refreshToken = RandomGenerator.CreateRefreshToken(user.Id, _appSettings.RefreshTokenExpiration);
                    authRes.RefreshToken = refreshToken.Token;
                    authRes.RefreshTokenExpiration = refreshToken.Expires;
                    await refreshTokenRepository.Add(refreshToken);
                    await refreshTokenRepository.CommitAsync();
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);


                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.Id.ToString()) }),
                    Expires = expiry,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                authRes.AccessToken = tokenString;
                authRes.AccessTokenExpiration = expiry;

                return authRes;

            }


        }
    }
}
