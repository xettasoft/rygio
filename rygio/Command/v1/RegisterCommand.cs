using AutoMapper;
using MediatR;
using rygio.Domain.AppData;
using rygio.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace rygio.Command.v1
{
    public class RegisterCommand : IRequest<string>
    {
        public UserRegisterationDto registerDto { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
        {
            private readonly IUserService userRepository;
            private readonly IMapper mapper;

            public RegisterCommandHandler(IUserService userRepository, IMapper mapper)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {

                var user = mapper.Map<User>(request.registerDto);
                await userRepository.Register(user,request.registerDto.Password, request.registerDto.Password);

                return "User created successfully";

            }


        }
    }
}
