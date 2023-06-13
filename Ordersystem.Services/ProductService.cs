using Microsoft.EntityFrameworkCore;
using Ordersystem.DataAccess;
using Ordersystem.DataObjects;

namespace Ordersystem.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product? GetProductByID(int id);
        Product Create(Product product);
        Product Update(int id, Product newProduct);
        bool Delete(int id);
    }

    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context) // Contructor injection
        {
            this._context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.Include(u=>u.Category).Include(u=>u.Supplier).ToList();
        }

        public Product? GetProductByID(int id)
        {
            return _context.Products.Where(c => c.ProductID == id).FirstOrDefault();
        }

        public Product Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product Update(int id, Product newProduct)
        {
            var productToUpdate = _context.Products.Where(c => c.ProductID == id).FirstOrDefault();

            if (productToUpdate != null)
            {
                // Update only properties that were changed
                productToUpdate.Title = newProduct.Title;
                productToUpdate.Description = newProduct.Description;
                productToUpdate.Price = newProduct.Price;
                productToUpdate.UnitInStock = newProduct.UnitInStock;
                if (productToUpdate.ImageUrl != null)
                {
                    productToUpdate.ImageUrl = newProduct.ImageUrl;
                }

                _context.Update(productToUpdate);
                _context.SaveChanges();

                return productToUpdate;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var result = _context.Products.ToList().FirstOrDefault(c => c.ProductID == id, null);
            if (result != null)
            {
                _context.Products.Remove(result);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}