using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace bARTapp.Models
{
    public class Contact
    {
        [Key]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [JsonIgnore]
        public Account? Account { get; set; }
    }
}
