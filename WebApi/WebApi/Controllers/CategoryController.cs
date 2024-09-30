using WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("GetCategory/")]
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _context.Categories.FromSqlRaw("EXEC GetCategories").AsEnumerable().ToList();
            return Ok(categories);
        }

        [Route("GetCategoryById/{id}/")]
        [HttpGet]
        public IActionResult GetCategoryById(int id)
        {
            var category = _context.Categories
                .FromSqlRaw("EXEC GetCategoryById @CategoryId", new SqlParameter("@CategoryId", id))
                .AsEnumerable()
                .FirstOrDefault();

            if (category == null)
            {
                return NotFound("Category not found.");
            }

            return Ok(category);
        }

        [Route("AddCategory/")]
        [HttpPost]
        public IActionResult AddCategory([FromBody] Category category)
        {
            if (category == null || string.IsNullOrWhiteSpace(category.CategoryName))
            {
                return BadRequest("Invalid category data.");
            }

            _context.Database.ExecuteSqlRaw("EXEC CreateCategory @CategoryName",
                new SqlParameter("@CategoryName", category.CategoryName));

            return Ok("Category added.");
        }

        [Route("UpdateCategory/{id}/")]
        [HttpPut]
        public IActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            if (category == null || string.IsNullOrWhiteSpace(category.CategoryName))
            {
                return BadRequest("Invalid category data.");
            }

            if (id != category.CategoryId)
            {
                return BadRequest("Category ID mismatch.");
            }

            var rowsAffected = _context.Database.ExecuteSqlRaw("EXEC UpdateCategory @CategoryId, @CategoryName",
                new SqlParameter("@CategoryId", category.CategoryId),
                new SqlParameter("@CategoryName", category.CategoryName));

            if (rowsAffected == 0)
            {
                return NotFound("Category not found.");
            }

            return NoContent();
        }

        [Route("{id}/")]
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var rowsAffected = _context.Database.ExecuteSqlRaw("EXEC DeleteCategory @CategoryId",
                new SqlParameter("@CategoryId", id));

            if (rowsAffected == 0)
            {
                return NotFound("Category not found.");
            }

            return NoContent();
        }
    }
}
