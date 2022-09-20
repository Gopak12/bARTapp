using AutoMapper;
using bARTapp.Dtos;
using bARTapp.Models;

namespace bARTapp.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<CreateContactDto, Contact>();
            CreateMap<Contact, Contact>();
        }
    }
}
