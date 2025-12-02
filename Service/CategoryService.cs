using Movies.DAL.Models;
using Movies.Service.IServices;
using Movies.Repository.IRepository;
using AutoMapper;
using Movies.DAL.Models.Dtos;

namespace Movies.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public Task<bool> CategoryExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateUpdateDto categoryCreateDto)
        {
            //validates if the category already exists
            var categoryExists = await _categoryRepository.CategoryExistsByNameAsync(categoryCreateDto.Name);
            if (categoryExists)
            {
                throw new InvalidOperationException($"Ya existe una categoria con el nombre de '{categoryCreateDto.Name}'");
            }

            var category = _mapper.Map<Category>(categoryCreateDto);

            var categoryCreated = await _categoryRepository.CreateCategoryAsync(category);

            if (!categoryCreated)
            {
                throw new Exception("Ocurrio un problema al crear la categoria");
            }

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> UpdateCategoryAsync(CategoryCreateUpdateDto dto, int id)
        {
            //validates if the category already exists
            var categoryExists = await _categoryRepository.GetCategoryAsync(id);
            if (categoryExists == null)
            {
                throw new InvalidOperationException($"No se encontró una categoria con el id '{id}'");
            }

            var nameExists = await _categoryRepository.CategoryExistsByNameAsync(dto.Name);

            if (nameExists)
            {
                throw new InvalidOperationException($"Ya existe una categoria con el nombre de '{dto.Name}'");
            }

            //Map the DTO to the entity
            _mapper.Map(dto, categoryExists);

            //Update the category
            var categoryUpdated = await _categoryRepository.UpdateCategoryAsync(categoryExists);

            if (!categoryUpdated)
            {
                throw new Exception("Ocurrio un error al actualizar la categoria");
            }

            return _mapper.Map<CategoryDto>(categoryExists);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            //validates if the category exists to delete it
            var categoryExists = await _categoryRepository.GetCategoryAsync(id);

            if(categoryExists == null)
            {
                throw new InvalidOperationException($"No se encontró la categoria con ID: {id}");
            }

            //Delete the category from repository
            var categoryDeleted = await _categoryRepository.DeleteCategoryAsync(id);

            if (!categoryDeleted)
            {
                throw new Exception("Ocurrió un error al eliminar la categoria");
            }
            return categoryDeleted;
        }

        public async Task<CategoryDto> GetCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryAsync(id); //Calling the method from repository
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<ICollection<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync(); //Calling the method from repository

            return _mapper.Map<ICollection<CategoryDto>>(categories); //Mapping the data to DTO
        }

        public Task<bool> CategoryExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
