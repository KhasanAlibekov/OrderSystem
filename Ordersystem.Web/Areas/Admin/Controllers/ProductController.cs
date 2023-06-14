using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ordersystem.DataObjects;
using Ordersystem.Services;
using System.Data;

namespace Ordersystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = ApplicationRoles.Role_Admin)]
    public class ProductController : Controller
    {
        IProductService _serviceProduct;
        ICategoryService _serviceCategory;
        ISupplierService _serviceSupplier;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductService serviceProduct, ICategoryService serviceCategory, ISupplierService serviceSupplier, IWebHostEnvironment webHostEnvironment)
        {
            _serviceProduct = serviceProduct;
            _serviceCategory = serviceCategory;
            _serviceSupplier = serviceSupplier;
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("Product")]
        public IActionResult Index()
        {
            var productList = _serviceProduct.GetAllProducts();

            return View(productList);
        }

        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> CategoryList = _serviceCategory.GetAllCategories().Select(u => new SelectListItem
            {
                Text = u.CategoryName,
                Value = u.CategoryID.ToString(),
            });

            ViewBag.CategoryList = CategoryList;

            IEnumerable<SelectListItem> SupplierList = _serviceSupplier.GetAllSuppliers().Select(u => new SelectListItem
            {
                Text = u.SupplierName,
                Value = u.SupplierID.ToString(),
            });

            ViewBag.SupplierList = SupplierList;

            if (id == null)
            {
                // Create
                return View(new Product());
            }
            else
            {
                // Edit
                var data = _serviceProduct.GetProductByID(id.Value);
                if (data == null)
                {
                    return NotFound();
                }
                return View(data);
            }
        }

        [HttpPost]
        public IActionResult Upsert(int? id, Product objProduct, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    // Gives a random name for a file and extension
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images/product");

                    if (!string.IsNullOrEmpty(objProduct.ImageUrl))
                    {
                        // Delete the old image
                        var oldImage = Path.Combine(wwwRootPath, objProduct.ImageUrl);

                        // Check if old image does exist
                        if (System.IO.File.Exists(oldImage))
                        {
                            System.IO.File.Delete(oldImage);
                        }
                    }

                    // Upload a new image
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    // Update image URL
                    objProduct.ImageUrl = @"images/product/" + fileName;
                }

                if (id == null)
                {
                    // Create product
                    _serviceProduct.Create(objProduct);
                    TempData["succes"] = "Product created succesfully";
                }
                else
                {
                    // Edit product
                    var existingProduct = _serviceProduct.GetProductByID(id.Value);
                    if (existingProduct == null)
                    {
                        return NotFound();
                    }

                    existingProduct.Title = objProduct.Title;
                    existingProduct.Description = objProduct.Description;
                    existingProduct.Price = objProduct.Price;
                    existingProduct.UnitInStock = objProduct.UnitInStock;
                    existingProduct.ImageUrl = objProduct.ImageUrl;

                    _serviceProduct.Update(id.Value, existingProduct);
                    TempData["succes"] = "Product updated succesfully";
                }
                return RedirectToAction("Index");
            }

            // If model state is not valid, re-render the view with validation errors

            IEnumerable<SelectListItem> CategoryList = _serviceCategory.GetAllCategories().Select(u => new SelectListItem
            {
                Text = u.CategoryName,
                Value = u.CategoryID.ToString(),
            });

            ViewBag.CategoryList = CategoryList;

            IEnumerable<SelectListItem> SupplierList = _serviceSupplier.GetAllSuppliers().Select(u => new SelectListItem
            {
                Text = u.SupplierName,
                Value = u.SupplierID.ToString(),
            });

            ViewBag.SupplierList = SupplierList;

            return View(objProduct);
        }

        public IActionResult Delete(int id)
        {
            var data = _serviceProduct.GetProductByID(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(int id, Product objProduct)
        {
            _serviceProduct.Delete(id);
            TempData["succes"] = "Product deleted succesfully";
            return RedirectToAction("Index");
        }

        #region API
        [HttpGet]
        public IActionResult Get()
        {
            var productList = _serviceProduct.GetAllProducts();
            return Json(new { data = productList });
        }
        #endregion
    }
}
