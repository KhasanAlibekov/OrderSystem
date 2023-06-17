using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordersystem.API.Dto;
using Ordersystem.Services;

namespace Ordersystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class API_CategoryController : ControllerBase
    {
        ICategoryService _categoryService;

        public API_CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //[Authorize]
        [HttpGet] 
        public IActionResult Get()
        {
            try
            {
                var listCategory = _categoryService.GetAllCategories();

                return Ok(listCategory);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var category = _categoryService.GetCategoryByID(id);

                if (category == null)
                {
                    return NotFound("Category not found");
                }

                return Ok(category);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpGet("byid")]
        public IActionResult GetByIdQueryParam(int categoryId, string? personalMessage)
        {
            try
            {
                if (string.IsNullOrEmpty(personalMessage))
                {
                    personalMessage = "This is your personal message";
                }

                var category = _categoryService.GetCategoryByID(categoryId);

                if (category == null)
                {
                    return NotFound("Category not found");
                }
                return Ok(new { category, personalMessage });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CategoryDto category)
        {
            try
            {
                var CreatedCategory = _categoryService.Create(new Ordersystem.DataObjects.Category
                {
                    CategoryName = category.CategoryName,
                });

                return CreatedAtAction("GetById", new { id = CreatedCategory.CategoryID }, CreatedCategory);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] CategoryDto category)
        {
            try
            {
                var categoryToUpdate = _categoryService.Update(id, new Ordersystem.DataObjects.Category
                {
                    CategoryName = category.CategoryName,
                });

                if (categoryToUpdate == null)
                {
                    return NotFound("Category not found");
                }

                return CreatedAtAction("GetById", new { id = categoryToUpdate.CategoryID }, categoryToUpdate);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var isDeleted = _categoryService.Delete(id);

                if (isDeleted)
                {
                    return Ok(new { Message = "Category deleted successfully" });
                }

                return BadRequest(new { Message = "Something went wrong trying to delete category." });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }
    }
}
