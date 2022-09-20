using bARTapp.Data;
using bARTapp.Models;
using bARTapp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bARTapp.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly AppDbContext _context;

        public IncidentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateIncidentAsync(Incident incident)
        {
            await _context.Incident.AddAsync(incident);
            await _context.SaveChangesAsync();
        }

        public List<Incident> GetAllIncidents()
        {
            return _context.Incident.Include(i => i.Accounts).ThenInclude(a => a.Contacts).ToList();
        }

    }
}
