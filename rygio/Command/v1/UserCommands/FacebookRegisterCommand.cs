using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using rygio.Command.v1;
using rygio.Domain.Interface;
using rygio.Helper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace rygio.Command
{
    public class FacebookRegisterCommand : IRequest<string>
    {
        public ExternalAuthDto facebookAuthDto { get; set; }

        public class FacebookRegisterCommandHandler : IRequestHandler<FacebookRegisterCommand, string>
        {
            private readonly IUserService userRepository;
            private readonly IMapper mapper;
            private readonly AppSettings _appSettings;

            public FacebookRegisterCommandHandler(IUserService userRepository, IMapper mapper, IOptions<AppSettings> appSettings)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
            }

            public async Task<string> Handle(FacebookRegisterCommand request, CancellationToken cancellationToken)
            {

               // if (request.facebookAuthDto.AppKey != _appSettings.AppKey) throw new AppException("Invalid AppKey");
                await userRepository.FacebookRegister(request.facebookAuthDto.AccessToken);

                return "User created successfully";

            }


        }
    }
}
