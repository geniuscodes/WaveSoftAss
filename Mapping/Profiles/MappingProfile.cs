using AutoMapper;
using WaveSoftAss.Mapping.DTOs;

namespace WaveSoftAss.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventReadDTO>().ReverseMap()
               .ForMember
                (
                    destinationMember => destinationMember.FkTournament.TournamentId,
                    option => option.MapFrom(src => src.TournamentID)
   );

        }

        //Read DTO
        
    }
}
