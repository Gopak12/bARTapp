using bARTapp.Dtos;
using bARTapp.Models;

namespace bARTapp.Services.Interfaces
{
    public interface IContactService
    {
        Task CreateContact(Contact contact);

        Task<Contact> GetContactByEmail(string email);

        List<Contact> GetAllContacts();

        Task UpdateContactAsync(Contact contact);


    }
}
