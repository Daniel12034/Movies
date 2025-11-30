using System.ComponentModel.DataAnnotations;

namespace Movies.DAL.Models
{
    public class Category : AuditBase
    {
        [Required]
        [Display(Name = "Categoria")]
        public required string Name { get; set; }
    }
}
