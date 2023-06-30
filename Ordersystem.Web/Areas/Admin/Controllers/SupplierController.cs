using HtmlAgilityPack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ordersystem.DataObjects;
using Ordersystem.Services;

namespace Ordersystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ApplicationRoles.Role_Admin)]
    public class SupplierController : Controller
    {
        ISupplierService _serviceSupplier;
        public SupplierController(ISupplierService service)
        {
            _serviceSupplier = service;
        }
        [Route("Supplier")]
        public IActionResult Index()
        {
            var data = _serviceSupplier.GetAllSuppliers();
            return View(data);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null)
            {
                // Create
                return View(new Supplier());
            }
            else
            {
                // Edit
                Supplier supplierObj = _serviceSupplier.GetSupplierByID(id.Value);
                if (supplierObj == null)
                {
                    return NotFound();
                }
                return View(supplierObj);
            }
        }

        [HttpPost]
        public IActionResult Upsert(int? id, Supplier objSupplier)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    // Create
                    _serviceSupplier.Create(objSupplier);
                    TempData["succes"] = "Supplier created succesfully";
                }
                else
                {
                    // Edit
                    var existingSupplier = _serviceSupplier.GetSupplierByID(id.Value);
                    if (existingSupplier == null)
                    {
                        return NotFound();
                    }

                    existingSupplier.SupplierName = objSupplier.SupplierName;
                    existingSupplier.Address = objSupplier.Address;
                    existingSupplier.City = objSupplier.City;
                    existingSupplier.Country = objSupplier.Country;
                    existingSupplier.Phone = objSupplier.Phone;
                    existingSupplier.VATNumber = objSupplier.VATNumber;
                    existingSupplier.PostalCode = objSupplier.PostalCode;
                    existingSupplier.Email = objSupplier.Email;

                    _serviceSupplier.Update(id.Value, existingSupplier);
                    TempData["succes"] = "Supplier updated succesfully";
                }
                return RedirectToAction("Index");
            }

            return View(objSupplier);
        }

        public IActionResult Delete(int id)
        {
            var data = _serviceSupplier.GetSupplierByID(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(int id, Supplier objSupplier)
        {
            _serviceSupplier.Delete(id);
            TempData["succes"] = "Supplier deleted succesfully";
            return RedirectToAction("Index");
        }
    }

    private void ExtractCitiesAndPostalCodes(string mhtmlFilePath, out List<string> cities, out List<string> postalCodes)
    {
        string mhtmlContent = System.IO.File.ReadAllText(mhtmlFilePath);

        // Extract cities and postal codes using HTML parsing
        HtmlDocument htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(mhtmlContent);

        var trNodes = htmlDoc.DocumentNode.SelectNodes("//tr");

        cities = new List<string>();
        postalCodes = new List<string>();

        if (trNodes != null)
        {
            foreach (var trNode in trNodes)
            {
                var tdNodes = trNode.SelectNodes("./td");

                if (tdNodes != null && tdNodes.Count >= 2)
                {
                    string postalCode = tdNodes[0].InnerText.Trim();
                    string city = tdNodes[1].InnerText.Trim();

                    postalCodes.Add(postalCode);
                    cities.Add(city);
                }
            }
        }
    }

}
