using AutoMapper;
using bARTapp.Data;
using bARTapp.Dtos;
using bARTapp.Models;
using bARTapp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bARTapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly IContactService _contactService;

        public AccountController(IAccountService accountService, IContactService contactService ,IMapper mapper)
        {
            _mapper = mapper;
            _accountService = accountService;
            _contactService = contactService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Account>> GetAccounts()
        {
            return Ok(_accountService.GetAllAccounts());
        }

        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(CreateAccountDto accountDto)
        {
            var contact = await _contactService.GetContactByEmail(accountDto.ContactEmail);
            if (contact == default)
            {
                return NotFound("Contact not found");
            }

            if(contact.Account != default)
            {
                return BadRequest("Contact is already linked");
            }

            var account = _mapper.Map<Account>(accountDto);
            account.Contacts = new List<Contact>()
            {
                contact
            };
            await _accountService.CreateAccountAsync(account);
            return Ok(account);
        }
    }
}
