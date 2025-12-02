using Movies.DAL.Models;
using Movies.DAL.Models.Dtos;

namespace Movies.Service.IServices
{
    public interface IMovieService
    {
        Task<ICollection<MovieDto>> GetMoviesAsync(); //Returns a list of movies
        Task<MovieDto> GetMovieAsync(int id); //Returns a specific movie register
        Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto movieDto); //Create a movie 
        Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto movieDto, int id); //Update a movie 
        Task<bool> DeleteMovieAsync(int id); //Delete a movie 
        Task<bool> MovieExistsByIdAsync(int id); //Returns a flag indicating a movie exists by its ID
        Task<bool> MovieExistsByNameAsync(string name); //Returns a flag indicating a movie exists by its name
    }
}
