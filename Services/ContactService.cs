using AutoMapper;
using bARTapp.Data;
using bARTapp.Dtos;
using bARTapp.Models;
using bARTapp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bARTapp.Services
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper; 
        private readonly AppDbContext _context;

        public ContactService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateContact(Contact contact)
        {
            await _context.Contact.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task<Contact> GetContactByEmail(string email)
        {
            return _context.Contact
                .Include(a => a.Account)
                .FirstOrDefault(x => x.Email == email);
        }

        public List<Contact> GetAllContacts()
        {
            return _context.Contact.ToList();
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            _context.Update(contact);
            await _context.SaveChangesAsync();
        }
    }
}
