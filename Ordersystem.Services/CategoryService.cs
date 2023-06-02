using Ordersystem.DataAccess;
using Ordersystem.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordersystem.Services
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        Category? GetCategoryByID(int id);
        Category Create(Category category);
        Category Update(int id, Category newCategory);
        bool Delete(int id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context) // Contructor injection
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

        public Category Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
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
