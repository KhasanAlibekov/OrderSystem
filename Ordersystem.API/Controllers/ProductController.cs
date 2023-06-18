using Microsoft.AspNetCore.Mvc;
using Ordersystem.API.Dto;
using Ordersystem.Services;

namespace Ordersystem.API.Controllers
{
    #region Product API Controller Overview
    /// <summary>
    /// 1. **Dependencies:**
    /// The controller has dependencies on three services: `IProductService`, `ICategoryService`, and `ISupplierService`. These services are
    /// injected through the constructor.
    ///
    /// 2. **Routing and Attributes:**
    /// The class is decorated with the `[Route]` and `[ApiController]` attributes, which define the base route for the controller and
    /// indicate that it is an API controller.
    ///
    /// 3. **Action Methods:**
    /// - `Get`:    Handles the HTTP GET request to retrieve all products. It calls the `GetAllProducts` method of the `_productService` and
    ///             returns the retrieved products.
    /// - `GetById`: Handles the HTTP GET request to retrieve a specific product by its ID. It calls the `GetProductByID` method of the
    ///             `_productService` and returns the retrieved product.
    /// - `GetByIdQueryParam`: Handles the HTTP GET request to retrieve a specific product by its ID, along with an optional personal
    ///             message. It calls the `GetProductByID` method of the `_productService`, adds a personal message if provided, and returns
    ///             the product and the personal message.
    /// - `Create`: Handles the HTTP POST request to create a new product. It retrieves the category entity based on the provided category
    ///             ID, calls the `Create` method of the `_productService` to create the product, and returns the created product.
    /// - `Update`: Handles the HTTP PUT request to update an existing product by its ID. It calls the `Update` method of the
    ///             `_productService` to update the product, and returns the updated product.
    /// - `Delete`: Handles the HTTP DELETE request to delete a product by its ID. It calls the `Delete` method of the `_productService`
    ///             and returns a success message if the deletion is successful.
    ///
    /// 4. **Exception Handling:**
    /// The action methods include exception handling code within a try-catch block. If an exception occurs during the execution of an
    /// action, it returns an appropriate HTTP status code and an error message indicating that something went wrong.
    /// </summary>
    #endregion

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        ICategoryService _categoryService;
        ISupplierService _supplierService;

        public ProductController(IProductService productService, ICategoryService categoryService, ISupplierService supplierService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _supplierService = supplierService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var listProduct = _productService.GetAllProducts();

                var category = _categoryService.GetAllCategories();

                var supplier = _supplierService.GetAllSuppliers();
                return Ok(listProduct);
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
                var product = _productService.GetProductByID(id);

                if (product == null)
                {
                    return NotFound("Product not found");
                }

                return Ok(product);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpGet("byid")]
        public IActionResult GetByIdQueryParam(int productId, string? personalMessage)
        {
            try
            {
                if (string.IsNullOrEmpty(personalMessage))
                {
                    personalMessage = "This is your personal message";
                }

                var product = _productService.GetProductByID(productId);

                if (product == null)
                {
                    return NotFound("Product not found");
                }
                return Ok(new { product, personalMessage });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] ProductDto product)
        {
            try
            {
                var category = _categoryService.GetCategoryByID(product.CategoryID);
                if (category == null)
                    return BadRequest("Invalid Category ID");

                var CreatedProduct = _productService.Create(new Ordersystem.DataObjects.Product
                {
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price,
                    UnitInStock = product.UnitInStock,
                    ImageUrl = product.ImageUrl,
                    Category = category,
                });


                return CreatedAtAction("GetById", new { id = CreatedProduct.ProductID }, CreatedProduct);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] ProductDto product)
        {
            try
            {
                var productToUpdate = _productService.Update(id, new Ordersystem.DataObjects.Product
                {
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price,
                    UnitInStock = product.UnitInStock,
                    ImageUrl = product.ImageUrl,
                });

                if (productToUpdate == null)
                {
                    return NotFound("Product not found");
                }

                return CreatedAtAction("GetById", new { id = productToUpdate.ProductID }, productToUpdate);
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
                var isDeleted = _productService.Delete(id);

                if (isDeleted)
                {
                    return Ok(new { Message = "Product deleted successfully" });
                }

                return BadRequest(new { Message = "Something went wrong trying to delete product." });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }
    }
}
