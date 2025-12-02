
using Movies.DAL.Models;

namespace Movies.Repository.IRepository
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetMoviesAsync(); //Returns a list of movies
        Task<Movie> GetMovieAsync(int id); //Returns a specific movie register
        Task<bool> MovieExistsByIdAsync(int id); //Returns a flag indicating a movie exists by its ID
        Task<bool> MovieExistsByNameAsync(string name); //Returns a flag indicating a movie exists by its name
        Task<bool> CreateMovieAsync(Movie movie); //Create a movie 
        Task<bool> UpdateMovieAsync(Movie movie); //Update a movie 
        Task<bool> DeleteMovieAsync(int id); //Delete a movie 
    }
}
