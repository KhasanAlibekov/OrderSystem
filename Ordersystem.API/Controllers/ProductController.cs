﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordersystem.API.Dto;
using Ordersystem.Services;

namespace Ordersystem.API.Controllers
{
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
