
using Movies.DAL.Models;

namespace Movies.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCategoriesAsync(); //Returns a list of categories
        Task<Category> GetCategoryAsync(int id); //Returns a specific category register
        Task<bool> CategoryExistsByIdAsync(int id); //Returns a flag indicating a category exists by it's ID
        Task<bool> CategoryExistsByNameAsync(string name); //Returns a flag indicating a category exists by it's name
        Task<bool> CreateCategoryAsync(Category category); //Create a category 
        Task<bool> UpdateCategoryAsync(Category category); //Update a category 
        Task<bool> DeleteCategoryAsync(int id); //Delete a category 
    }
}
