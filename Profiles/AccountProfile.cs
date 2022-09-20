using AutoMapper;
using bARTapp.Dtos;
using bARTapp.Models;

namespace bARTapp.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<CreateAccountDto, Account>();
            CreateMap<Account, Account>();
        }
    }
}
