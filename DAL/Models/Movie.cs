using System.ComponentModel.DataAnnotations;

namespace Movies.DAL.Models
{
    public class Movie : AuditBase
    {
        [Required]
        [Display(Name = "Pelicula")]
        public required string Name { get; set; }
        public required int Duration { get; set; }
        public string? Description { get; set; }
        public required string Clasification { get; set; }
    }
}
