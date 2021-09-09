using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using rygio.Domain.Interface;
using rygio.Helper;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace rygio.Command.v1
{
    public class RevokeTokenCommand : IRequest<string>
    {
        public string token { get; set; }
        //public string AppKey { get; set; }

        public class RevokeTokenCommandHandler : IRequestHandler<RevokeTokenCommand, string>
        {
            private readonly IUserService userRepository;
            private readonly IMapper mapper;
            private readonly AppSettings _appSettings;

            public RevokeTokenCommandHandler(IUserService userRepository, IMapper mapper, IOptions<AppSettings> appSettings)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
            }

            public async Task<string> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
            {

                //if (request.AppKey != _appSettings.AppKey) throw new AppException("Invalid AppKey");
                var result = await userRepository.RevokeRefreshToken(request.token);

                return result;

            }


        }
    }
}
