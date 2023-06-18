using Microsoft.AspNetCore.Mvc;
using Ordersystem.API.Dto;
using Ordersystem.Services;

namespace Ordersystem.API.Controllers
{
    #region Supplier API Controller Overview
    /// <summary>
    /// 1. **Dependencies:**
    /// The controller has a dependency on the `ISupplierService` which is injected through the constructor.
    ///
    /// 2. **Routing and Attributes:** 
    /// The class is decorated with the `[Route]` and `[ApiController]` attributes, which define the base route for the controller and
    /// indicate that it is an API controller.
    ///
    /// 3. **Action Methods:**
    /// - `Get`:    Handles the HTTP GET request to retrieve all suppliers. It calls the `GetAllSuppliers` method of the `_supplierService`
    ///             and returns the retrieved suppliers.
    /// - `GetById`: Handles the HTTP GET request to retrieve a specific supplier by its ID. It calls the `GetSupplierByID` method of the
    ///             `_supplierService` and returns the retrieved supplier.
    /// - `GetByIdQueryParam`: Handles the HTTP GET request to retrieve a specific supplier by its ID, along with an optional personal
    ///             message. It calls the `GetSupplierByID` method of the `_supplierService`, adds a personal message if provided, and
    ///             returns the supplier and the personal message.
    /// - `Create`: Handles the HTTP POST request to create a new supplier. It calls the `Create` method of the `_supplierService` to create
    ///             the supplier, and returns the created supplier.
    /// - `Update`: Handles the HTTP PUT request to update an existing supplier by its ID. It calls the `Update` method of the
    ///             `_supplierService` to update the supplier, and returns the updated supplier.
    /// - `Delete`: Handles the HTTP DELETE request to delete a supplier by its ID. It calls the `Delete` method of the `_supplierService`
    ///             and returns a success message if the deletion is successful.
    ///
    /// 4. **Exception Handling:**
    /// The action methods include exception handling code within a try-catch block. If an exception occurs during the execution of an
    /// action, it returns an appropriate HTTP status code and an error message indicating that something went wrong.
    /// </summary>
    #endregion

    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        //[Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var listSupplier = _supplierService.GetAllSuppliers();

                return Ok(listSupplier);
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
                var supplier = _supplierService.GetSupplierByID(id);

                if (supplier == null)
                {
                    return NotFound("Supplier not found");
                }

                return Ok(supplier);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpGet("byid")]
        public IActionResult GetByIdQueryParam(int supplierId, string? personalMessage)
        {
            try
            {
                if (string.IsNullOrEmpty(personalMessage))
                {
                    personalMessage = "This is your personal message";
                }

                var supplier = _supplierService.GetSupplierByID(supplierId);

                if (supplier == null)
                {
                    return NotFound("Supplier not found");
                }
                return Ok(new { supplier, personalMessage });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] SupplierDto supplier)
        {
            try
            {
                var CreatedSupplier = _supplierService.Create(new Ordersystem.DataObjects.Supplier
                {
                    SupplierName = supplier.SupplierName,
                    VATNumber = supplier.VATNumber,
                    Address = supplier.Address,
                    City = supplier.City,
                    PostalCode = supplier.PostalCode,
                    Country = supplier.Country,
                    Phone = supplier.Phone,
                    Email = supplier.Email,
                });

                return CreatedAtAction("GetById", new { id = CreatedSupplier.SupplierID }, CreatedSupplier);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] SupplierDto supplier)
        {
            try
            {
                var supplierToUpdate = _supplierService.Update(id, new Ordersystem.DataObjects.Supplier
                {
                    SupplierName = supplier.SupplierName,
                    VATNumber = supplier.VATNumber,
                    Address = supplier.Address,
                    City = supplier.City,
                    PostalCode = supplier.PostalCode,
                    Country = supplier.Country,
                    Phone = supplier.Phone,
                    Email = supplier.Email,
                });

                if (supplierToUpdate == null)
                {
                    return NotFound("Supplier not found");
                }

                return CreatedAtAction("GetById", new { id = supplierToUpdate.SupplierID }, supplierToUpdate);
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
                var isDeleted = _supplierService.Delete(id);

                if (isDeleted)
                {
                    return Ok(new { Message = "Supplier deleted successfully" });
                }

                return BadRequest(new { Message = "Something went wrong trying to delete supplier." });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }
    }
}
