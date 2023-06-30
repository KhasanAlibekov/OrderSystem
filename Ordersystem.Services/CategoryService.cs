using Ordersystem.DataAccess;
using Ordersystem.DataObjects;

namespace Ordersystem.Services
{
    // Interface to define the contract for the CategoryService class
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        Category? GetCategoryByID(int id);
        Category Create(Category category);
        Category Update(int id, Category newCategory);
        bool Delete(int id);
    }

    /// <summary>
    /// The `CategoryService` class demonstrates the use of CRUD (Create, Read, Update, Delete)
    /// operations.
    /// It implements the `ICategoryService` interface and provides the necessary methods for working
    /// with categories.
    /// </summary>
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Retrieves all categories from the database.
        /// </summary>
        /// <returns>
        /// A list of Category objects representing all categories in the database.
        /// </returns>
        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        /// <summary>
        /// Retrieves a category from the database based on the specified ID.
        /// </summary>
        /// <param name="id">The ID of the category to retrieve.</param>
        /// <returns>The Category object corresponding to the specified ID, or null if not found.</returns>
        public Category? GetCategoryByID(int id)
        {
            return _context.Categories.Where(c => c.CategoryID == id).FirstOrDefault();
        }

        /// <summary>
        /// Creates a new category in the database.
        /// </summary>
        /// <param name="objCategory">The Category object representing the category to create.</param>
        /// <returns>The Category object representing the created category.</returns>
        public Category Create(Category objCategory)
        {
            _context.Categories.Add(objCategory);
            _context.SaveChanges();
            return objCategory;
        }

        /// <summary>
        /// Updates an existing category in the database with the provided data.
        /// </summary>
        /// <param name="id">The ID of the category to update.</param>
        /// <param name="newCategory">The Category object containing the updated data for the category.</param>
        /// <returns>The Category object representing the updated category, or null if the category with the specified ID is not found.</returns>
        public Category Update(int id, Category newCategory)
        {
            var categoryToUpdate = _context.Categories.Where(c => c.CategoryID == id).FirstOrDefault();

            if (categoryToUpdate != null)
            {
                categoryToUpdate.CategoryName = newCategory.CategoryName;

                _context.Update(categoryToUpdate);
                _context.SaveChanges();

                return categoryToUpdate;
            }

            return null;
        }

        /// <summary>
        /// Deletes a category from the database based on the specified ID.
        /// </summary>
        /// <param name="id">The ID of the category to delete.</param>
        /// <returns>True if the category was successfully deleted, false otherwise.</returns>
        public bool Delete(int id)
        {
            var result = _context.Categories.ToList().FirstOrDefault(c => c.CategoryID == id, null);
            if (result != null)
            {
                _context.Categories.Remove(result);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
