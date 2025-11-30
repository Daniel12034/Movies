using Microsoft.AspNetCore.Mvc;
using Movies.DAL.Models.Dtos;
using Movies.Service.IServices;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<CategoryDto>>> GetCategoriesAsync()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return Ok(categories);
        }
    }
}
