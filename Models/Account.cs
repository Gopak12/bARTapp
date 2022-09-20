using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace bARTapp.Models
{
    public class Account
    {
        [Key]
        public string Name { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }

        [JsonIgnore]
        public virtual Incident? Incident { get; set; }
    }
}
