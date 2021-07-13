using AutoMapper;
using rygio.Command.v1;
using rygio.Command.v1.Dtos.Response;
using rygio.Domain.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Mapper
{
    public class DataProfiles : Profile
    {
        public DataProfiles() {
            CreateMap<UserRegisterationDto, User>();
            CreateMap<User, AuthResponse>();
        }
    }
}
