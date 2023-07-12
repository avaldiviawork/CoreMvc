using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CoreMvc.Models
{
    public class NinjaClan
    {
        [Key]
        public int NinjaClanId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")] //No Nulls Allowed
        [MaxLength(50, ErrorMessage = "The field {0} must be maximum {1} characters length")]//length
        [Display(Name = "NinjaClan")] //Assign a custom name
        public string? Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]//No Nulls Allowed
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        public int ShinobiId { get; set; } //Foreign Key Relationship

        public virtual Shinobi? Shinobi { get; set; }//Incoming Foreign Key Relationship Pointer
    }
}
