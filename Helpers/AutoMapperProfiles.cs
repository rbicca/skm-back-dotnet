using AutoMapper;
using skm_back_dotnet.DTOs;
using skm_back_dotnet.Entities;

namespace skm_back_dotnet.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {   
            CreateMap<GenreDTO, Genre>().ReverseMap();
            CreateMap<GenreCreationDTO, Genre>();

            CreateMap<ActorDTO, Actor>().ReverseMap();
            CreateMap<ActorCreationDTO, Actor>()
                .ForMember(x => x.Picture, options  => options.Ignore());
        }
    }
}