using AutoMapper;
using bARTapp.Dtos;
using bARTapp.Models;

namespace bARTapp.Profiles
{
    public class IncidentProfile : Profile
    {
        public IncidentProfile()
        {
            CreateMap<CreateIncidentDto, Incident>();
        }
    }
}
