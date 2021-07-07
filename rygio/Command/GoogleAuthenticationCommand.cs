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

namespace rygio.Command
{
    public class GoogleAuthenticationCommand : IRequest<User>
    {
        public ExternalAuthDto googleAuthDto { get; set; }

        public class GoogleAuthenticationCommandHandler : IRequestHandler<GoogleAuthenticationCommand, User>
        {
            private readonly IUserRepository userRepository;
            private readonly IMapper mapper;

            public GoogleAuthenticationCommandHandler(IUserRepository userRepository, IMapper mapper)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<User> Handle(GoogleAuthenticationCommand request, CancellationToken cancellationToken)
            {

                return await userRepository.GoogleAuthentication(request.googleAuthDto.AccessToken);

            }


        }
    }
}
