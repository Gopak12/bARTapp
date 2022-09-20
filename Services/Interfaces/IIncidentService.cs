using bARTapp.Models;

namespace bARTapp.Services.Interfaces
{
    public interface IIncidentService
    {
        Task CreateIncidentAsync(Incident incident);

        List<Incident> GetAllIncidents();
    }
}
