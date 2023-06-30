using Microsoft.EntityFrameworkCore;
using Ordersystem.DataAccess;
using Ordersystem.DataObjects;

namespace Ordersystem.Services
{
    // Interface to define the contract for the ProductService class
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product? GetProductByID(int id);
        Product Create(Product product);
        Product Update(int id, Product newProduct);
        bool Delete(int id);
    }

    /// <summary>
    /// The `ProductService` class demonstrates the use of CRUD (Create, Read, Update, Delete)
    /// operations.
    /// It implements the `IProductService` interface and provides the necessary methods for working
    /// with products.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Retrieves all products from the database.
        /// </summary>
        /// <returns>A list of Product objects representing all products in the database.</returns>
        public List<Product> GetAllProducts()
        {
            return _context.Products.Include(u => u.Category).Include(u => u.Supplier).ToList();
        }

        /// <summary>
        /// Retrieves a product from the database based on the specified ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>The Product object corresponding to the specified ID, or null if not found.</returns>
        public Product? GetProductByID(int id)
        {
            return _context.Products.Where(c => c.ProductID == id).FirstOrDefault();
        }

        /// <summary>
        /// Creates a new product in the database.
        /// </summary>
        /// <param name="product">The Product object representing the product to create.</param>
        /// <returns>The Product object representing the created product.</returns>
        public Product Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        /// <summary>
        /// Updates an existing product in the database with the provided data.
        /// </summary>
        /// <param name="id">The ID of the product to update.</param>
        /// <param name="newProduct">The Product object containing the updated data for the product.</param>
        /// <returns>The Product object representing the updated product, or null if the product with the specified ID is not found.</returns>
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

        /// <summary>
        /// Deletes a product from the database based on the specified ID.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <returns>True if the product was successfully deleted, false otherwise.</returns>
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
