using Movies.DAL.Models;
using Movies.Service.IServices;
using Movies.Repository.IRepository;
using AutoMapper;
using Movies.DAL.Models.Dtos;

namespace Movies.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public Task<bool> MovieExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto movieCreateDto)
        {
            //validates if the movie already exists
            var movieExists = await _movieRepository.MovieExistsByNameAsync(movieCreateDto.Name);
            if (movieExists)
            {
                throw new InvalidOperationException($"Ya existe una pelicula con el nombre de '{movieCreateDto.Name}'");
            }

            var movie = _mapper.Map<Movie>(movieCreateDto);

            var movieCreated = await _movieRepository.CreateMovieAsync(movie);

            if (!movieCreated)
            {
                throw new Exception("Ocurrio un problema al crear la pelicula");
            }

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto dto, int id)
        {
            //validates if the movie already exists
            var movieExists = await _movieRepository.GetMovieAsync(id);
            if (movieExists == null)
            {
                throw new InvalidOperationException($"No se encontró una pelicula con el id '{id}'");
            }

            var nameExists = await _movieRepository.MovieExistsByNameAsync(dto.Name);

            if (nameExists)
            {
                throw new InvalidOperationException($"Ya existe una pelicula con el nombre de '{dto.Name}'");
            }

            //Map the DTO to the entity
            _mapper.Map(dto, movieExists);

            //Update the movie
            var movieUpdated = await _movieRepository.UpdateMovieAsync(movieExists);

            if (!movieUpdated)
            {
                throw new Exception("Ocurrio un error al actualizar la pelicula");
            }

            return _mapper.Map<MovieDto>(movieExists);
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            //validates if the movie exists to delete it
            var movieExists = await _movieRepository.GetMovieAsync(id); // Updated to use _movieRepository

            if(movieExists == null)
            {
                throw new InvalidOperationException($"No se encontró la pelicula con ID: {id}");
            }

            //Delete the movie from repository
            var movieDeleted = await _movieRepository.DeleteMovieAsync(id);

            if (!movieDeleted)
            {
                throw new Exception("Ocurrió un error al eliminar la pelicula");
            }
            return movieDeleted;
        }
        

        public async Task<MovieDto> GetMovieAsync(int id)
        {
            var movie = await _movieRepository.GetMovieAsync(id); //Calling the method from repository
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync(); //Calling the method from repository

            return _mapper.Map<ICollection<MovieDto>>(movies); //Mapping the data to DTO
        }

        public async Task<bool> MovieExistsByIdAsync(int id)
        {
            var movie = await _movieRepository.GetMovieAsync(id);
            return movie != null;
        }
    }
}
