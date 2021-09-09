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
    public class GoogleRegisterCommand : IRequest<string>
    {
        public ExternalAuthDto googleAuthDto { get; set; }

        public class GoogleRegisterCommandHandler : IRequestHandler<GoogleRegisterCommand, string>
        {
            private readonly IUserService userRepository;
            private readonly IMapper mapper;
            private readonly AppSettings _appSettings;

            public GoogleRegisterCommandHandler(IUserService userRepository, IMapper mapper, IOptions<AppSettings> appSettings)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
            }

            public async Task<string> Handle(GoogleRegisterCommand request, CancellationToken cancellationToken)
            {

                //if (request.googleAuthDto.AppKey != _appSettings.AppKey) throw new AppException("Invalid AppKey");
                await userRepository.GoogleRegister(request.googleAuthDto.AccessToken);

                return "User created successfully";

            }


        }
    }
}
