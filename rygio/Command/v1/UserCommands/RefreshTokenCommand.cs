using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using rygio.Command.v1.Dtos.Response;
using rygio.Domain.Interface;
using rygio.Helper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace rygio.Command.v1
{
    public class RefreshTokenCommand : IRequest<RefreshTokenResponse>
    {
        public string token { get; set; }

        public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenResponse>
        {
            private readonly IUserService userRepository;
            private readonly IMapper mapper;
            private readonly AppSettings _appSettings;

            public RefreshTokenCommandHandler(IUserService userRepository, IMapper mapper, IOptions<AppSettings> appSettings)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
            }

            public async Task<RefreshTokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
            {

               // if (request.AppKey != _appSettings.AppKey) throw new AppException("Invalid AppKey");
                var newtoken  = await userRepository.RefreshToken(request.token);

                return newtoken;

            }


        }
    }
}
