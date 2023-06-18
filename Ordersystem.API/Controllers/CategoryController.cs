using Microsoft.AspNetCore.Mvc;
using Ordersystem.API.Dto;
using Ordersystem.Services;

namespace Ordersystem.API.Controllers
{
    #region Category API Controller Overview
    /// <summary>
    /// 1. **Dependencies:**
    /// The controller has a dependency on the `ICategoryService` which is injected through the constructor.
    ///
    /// 2. **Routing and Attributes:** 
    /// The class is decorated with the `[Route]` and `[ApiController]` attributes, which define the base route for the controller and
    /// indicate that it is an API controller.
    ///
    /// 3. **Action Methods:**
    /// - `Get`: Handles the HTTP GET request to retrieve all categories. It calls the `GetAllCategories` method of the `_categoryService` and
    ///          returns the retrieved categories.
    /// - `GetById`: Handles the HTTP GET request to retrieve a specific category by its ID. It calls the `GetCategoryByID` method of the
    ///              `_categoryService` and returns the retrieved category.
    /// - `GetByIdQueryParam`: Handles the HTTP GET request to retrieve a specific category by its ID, along with an optional personal 
    ///                        message. It calls the `GetCategoryByID` method of the `_categoryService`, adds a personal message if
    ///                        provided, and returns the category and the personal message.
    /// - `Create`: Handles the HTTP POST request to create a new category. It calls the `Create` method of the `_categoryService` to create
    ///             the category, and returns the created category.
    /// - `Update`: Handles the HTTP PUT request to update an existing category by its ID. It calls the `Update` method of the
    ///             `_categoryService` to update the category, and returns the updated category.
    /// - `Delete`: Handles the HTTP DELETE request to delete a category by its ID. It calls the `Delete` method of the `_categoryService`
    ///             and returns a success message if the deletion is successful.
    ///
    /// 4. **Exception Handling:**
    /// The action methods include exception handling code within a try-catch block. If an exception occurs during the execution of an
    /// action, it returns an appropriate HTTP status code and an error message indicating that something went wrong.
    /// </summary>
    #endregion

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
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
