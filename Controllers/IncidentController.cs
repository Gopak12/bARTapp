using AutoMapper;
using bARTapp.Dtos;
using bARTapp.Models;
using bARTapp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bARTapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly IContactService _contactService;
        private readonly IIncidentService _incidentService;

        public IncidentController(IAccountService accountService, IContactService contactService, IMapper mapper, IIncidentService incidentService)
        {
            _mapper = mapper;
            _accountService = accountService;
            _contactService = contactService;
            _incidentService = incidentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Incident>> GetIncidents()
        {
            return Ok(_incidentService.GetAllIncidents());
        }

        [HttpPost]
        public async Task<ActionResult<Incident>> PostIncident(CreateIncidentDto incidentDto)
        {
            var account = await _accountService.GetAccountByNameAsync(incidentDto.AccountName);
            if (account == default)
            {
                return NotFound("Account not found");
            }
            var contact = await _contactService.GetContactByEmail(incidentDto.Contact.Email);
            if (contact != default)
            {
                _mapper.Map(incidentDto.Contact, contact);
                await _contactService.UpdateContactAsync(contact);
            }
            else
            {
                await _contactService.CreateContact(incidentDto.Contact);
                contact = await _contactService.GetContactByEmail(incidentDto.Contact.Email);
            }

            contact.Account = account;
            await _contactService.UpdateContactAsync(contact);

            var incident = _mapper.Map<Incident>(incidentDto);
            await _incidentService.CreateIncidentAsync(incident);
            account.Incident = incident;
            await _accountService.UpdateAccountAsync(account);

            
            return Ok(incident);
        }
    }
}
