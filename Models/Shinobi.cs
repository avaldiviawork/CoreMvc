using System.ComponentModel.DataAnnotations;

namespace CoreMvc.Models
{
    public class Shinobi
    {
        [Key] //This Data Annotation sets this column as the primary key field
        public int ShinobiId { get; set; } // Data Annotations are placed above the   
                                           //property table column to expand its features.
        [Required(ErrorMessage = "The field {0} is required")]//No Nulls Allowed
        [MaxLength(50, ErrorMessage = "The field {0} must be maximum {1} characters length")]//length
        [Display(Name = "Shinobi")]//Assign a custom name
        public string? Name { get; set; } //This is a property field   

        public virtual ICollection<NinjaClan>? NinjaClans { get; set; } // Outgoing Foreign Key Relationship Pointer
    }
}
