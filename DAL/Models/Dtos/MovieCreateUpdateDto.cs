using System.ComponentModel.DataAnnotations;

namespace Movies.DAL.Models.Dtos
{
    public class MovieCreateUpdateDto
    {
        [Required(ErrorMessage = "El nombre de la pelicula es obligatorio")]
        [MaxLength(100, ErrorMessage = "El numero maximo de caracteres para el nombre es de 100.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "La duracion de la pelicula no puede ser vacia")]
        public int Duration { get; set; }

        [MaxLength(500, ErrorMessage = "El numero maximo de caracteres para la descripcion es de 500.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "La clasificación no puede ser vacía")]
        [MaxLength(10, ErrorMessage = "El numero maximo de caracteres para la clasificacion es de 10.")]
        public string Clasification { get; set; }
    }
}
