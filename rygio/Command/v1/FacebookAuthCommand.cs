using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using rygio.Command.v1.Dtos.Request;
using rygio.Command.v1.Dtos.Response;
using rygio.Domain.AppData;
using rygio.Domain.Interface;
using rygio.Helper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace rygio.Command.v1
{
    public class FacebookAuthCommand : IRequest<AuthResponse>
    {
        public ExternalAuthDto facebookAuthDto { get; set; }

        public class FacebookAuthCommandHandler : IRequestHandler<FacebookAuthCommand, AuthResponse>
        {
            private readonly IUserService userRepository;
            private readonly IMapper mapper;
            private readonly AppSettings _appSettings;
            private readonly IRepository<RefreshToken> refreshTokenRepository;

            public FacebookAuthCommandHandler(IUserService userRepository, IMapper mapper, IRepository<RefreshToken> refreshTokenRepository, IOptions<AppSettings> appSettings)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
                this.refreshTokenRepository = refreshTokenRepository ?? throw new ArgumentNullException(nameof(refreshTokenRepository));
            }

            public async Task<AuthResponse> Handle(FacebookAuthCommand request, CancellationToken cancellationToken)
            {
                var user = await userRepository.FacebookAuthentication(request.facebookAuthDto.AccessToken);
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
