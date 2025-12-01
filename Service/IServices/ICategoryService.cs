using Movies.DAL.Models;
using Movies.DAL.Models.Dtos;

namespace Movies.Service.IServices
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryDto>> GetCategoriesAsync(); //Returns a list of categories
        Task<CategoryDto> GetCategoryAsync(int id); //Returns a specific category register
        Task<CategoryDto> CreateCategoryAsync(CategoryCreateUpdateDto categoryDto); //Create a category 
        Task<CategoryDto> UpdateCategoryAsync(CategoryCreateUpdateDto categoryDto, int id); //Update a category 
        Task<bool> DeleteCategoryAsync(int id); //Delete a category 
        Task<bool> CategoryExistsByIdAsync(int id); //Returns a flag indicating a category exists by it's ID
        Task<bool> CategoryExistsByNameAsync(string name); //Returns a flag indicating a category exists by it's name
    }
}
