using AutoMapper;
using BotVoceVaiCantar.Domain.Contracts;
using BotVoceVaiCantar.Domain.Entities;

namespace BotVoceVaiCantar.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<CantorRequest, Cantor>().ReverseMap();
            CreateMap<CantorResponse, Cantor>().ReverseMap();
        }
    }
}
