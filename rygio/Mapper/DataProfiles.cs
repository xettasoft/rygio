using AutoMapper;
using rygio.Command.v1;
using rygio.Command.v1.Dtos.Response;
using rygio.Command.v1.ExperienceCommands.Dtos;
using rygio.Command.v1.RegionCommands.Dtos.Request;
using rygio.Domain.AppData;
using rygio.Helper;
using rygio.Query.v1.CollectibleQuery.ResponseDto;
using rygio.Query.v1.RegionQuery.Dtos.Request;

namespace rygio.Mapper
{
    public class DataProfiles : Profile
    {
        public DataProfiles() {
            //user
            CreateMap<UserRegisterationDto, User>();
            CreateMap<User, AuthResponse>();

            //region
            CreateMap<NewRegionDto, Region>()
                                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => RygioGeometry.LatLngMaker(src.Latitude, src.Longitude)))
                                .ForMember(dest => dest.Border, opt => opt.MapFrom(src => RygioGeometry.GeometryMaker(src.Latitude, src.Longitude, src.Radius)));
            CreateMap<RegionMemberDto, RegionResident>();
            CreateMap<Region, RegionQueryDto>()
                                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Location.Y))
                                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Location.X));


            //collectible
            CreateMap< rygio.Command.v1.CollectibleCommand.Dtos.CreateDto, Collectable>();
            CreateMap<Collectable, CollectibleDto>();

            //Experience
            CreateMap<ExperienceDto, Experience>();
            CreateMap<ExperienceStageDto, ExperienceStage>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => RygioGeometry.LatLngMaker(src.Latitude,src.Longitude)))
                .ForMember(dest => dest.Border, opt => opt.MapFrom(src => RygioGeometry.GeometryMaker(src.Latitude, src.Longitude,src.Radius)));
            CreateMap<ExperienceMemberDto, ExperienceMember>();
            CreateMap<ExperienceStageCollectibleDto, ExperienceStageCollectible>();

        }
    }
}
