using bARTapp.Models;

namespace bARTapp.Dtos
{
    public class CreateIncidentDto
    {
        public string AccountName { get; set; }

        public Contact Contact { get; set; } 

        public string Decsription { get; set; }
    }
}
