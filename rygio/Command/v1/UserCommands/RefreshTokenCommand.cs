using AutoMapper;
using MediatR;
using rygio.Command.v1.Dtos.Response;
using rygio.Domain.Interface;
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

            public RefreshTokenCommandHandler(IUserService userRepository, IMapper mapper)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<RefreshTokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
            {

               
                var newtoken  = await userRepository.RefreshToken(request.token);

                return newtoken;

            }


        }
    }
}
