using AutoMapper;
using MediatR;
using rygio.Command.v1;
using rygio.Domain.Interface;
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

            public FacebookRegisterCommandHandler(IUserService userRepository, IMapper mapper)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<string> Handle(FacebookRegisterCommand request, CancellationToken cancellationToken)
            {

                
                await userRepository.FacebookRegister(request.facebookAuthDto.AccessToken);

                return "User created successfully";

            }


        }
    }
}
