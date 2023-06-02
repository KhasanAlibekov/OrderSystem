using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordersystem.API.Dto;
using Ordersystem.Services;
using System.ComponentModel.DataAnnotations;

namespace Ordersystem.API.Controllers
{
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
