using AutoMapper;
using MediatR;
using rygio.Command.v1.Dtos.Response;
using rygio.Domain.AppData;
using rygio.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace rygio.Command.v1
{
    public class RevokeTokenCommand : IRequest<string>
    {
        public string token { get; set; }

        public class RevokeTokenCommandHandler : IRequestHandler<RevokeTokenCommand, string>
        {
            private readonly IUserService userRepository;
            private readonly IMapper mapper;

            public RevokeTokenCommandHandler(IUserService userRepository, IMapper mapper)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<string> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
            {


                var result = await userRepository.RevokeRefreshToken(request.token);

                return result;

            }


        }
    }
}
