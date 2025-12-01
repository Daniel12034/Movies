using AutoMapper;
using Movies.DAL.Models;
using Movies.DAL.Models.Dtos;

namespace Movies.MoviesMapper
{
    public class Mappers : Profile
    {

        public Mappers()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Category, CategoryCreateUpdateDto>().ReverseMap();
        }
    }
}
