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

    //  The `CategoryService` class demonstrates the use of CRUD (Create, Read, Update, Delete) operations.
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            this._context = context;
        }
        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category? GetCategoryByID(int id)
        {
            return _context.Categories.Where(c => c.CategoryID == id).FirstOrDefault();
        }

        public Category Create(Category objCategory)
        {
            _context.Categories.Add(objCategory);
            _context.SaveChanges();
            return objCategory;
        }

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
