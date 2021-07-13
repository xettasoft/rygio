using AutoMapper;
using MediatR;
using rygio.Command.v1;
using rygio.Domain.AppData;
using rygio.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
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

            public GoogleRegisterCommandHandler(IUserService userRepository, IMapper mapper)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<string> Handle(GoogleRegisterCommand request, CancellationToken cancellationToken)
            {


                await userRepository.GoogleRegister(request.googleAuthDto.AccessToken);

                return "User created successfully";

            }


        }
    }
}
