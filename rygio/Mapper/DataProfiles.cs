using AutoMapper;
using rygio.Command.v1;
using rygio.Command.v1.Dtos.Response;
using rygio.Command.v1.RegionCommands.Dtos.Request;
using rygio.Domain.AppData;
using rygio.Query.v1.RegionQuery.Dtos.Request;

namespace rygio.Mapper
{
    public class DataProfiles : Profile
    {
        public DataProfiles() {
            CreateMap<UserRegisterationDto, User>();
            CreateMap<User, AuthResponse>();
            CreateMap<NewRegionDto, Region>();
            CreateMap<RegionMemberDto, RegionResident>();
            CreateMap<Region, RegionQueryDto>();
        }
    }
}
