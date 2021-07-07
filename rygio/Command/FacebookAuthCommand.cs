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
    public class FacebookAuthCommand : IRequest<User>
    {
        public ExternalAuthDto facebookAuthDto { get; set; }

        public class FacebookAuthCommandHandler : IRequestHandler<FacebookAuthCommand, User>
        {
            private readonly IUserRepository userRepository;
            private readonly IMapper mapper;

            public FacebookAuthCommandHandler(IUserRepository userRepository, IMapper mapper)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<User> Handle(FacebookAuthCommand request, CancellationToken cancellationToken)
            {

                return await userRepository.FacebookAuthentication(request.facebookAuthDto.AccessToken);

            }


        }
    }
}
