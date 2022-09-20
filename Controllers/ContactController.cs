using AutoMapper;
using bARTapp.Data;
using bARTapp.Dtos;
using bARTapp.Models;
using bARTapp.Services;
using bARTapp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bARTapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _mapper = mapper;
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            return Ok(_contactService.GetAllContacts());
        }

        [HttpGet("Email")]
        public async Task<ActionResult<Contact>> GetContacts(string email)
        {
            var contact = await _contactService.GetContactByEmail(email);
            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(CreateContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);

            await _contactService.CreateContact(contact);

            return Ok(contact);
        }

        [HttpPut]
        public async Task<IActionResult> PutContacts(Contact contact)
        {
            var contactToUpdate = _contactService.GetContactByEmail(contact.Email);
            if (contactToUpdate == null)
            {
                return NotFound("Contact not found");
            }

            await _mapper.Map(contact, contactToUpdate);

            await _contactService.UpdateContactAsync(contact);

            return Ok(contact);
        }
    }
}
