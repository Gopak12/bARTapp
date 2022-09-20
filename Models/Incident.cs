using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bARTapp.Models
{
    public class Incident
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Name { get; set; }
        
        public string Decsription { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
