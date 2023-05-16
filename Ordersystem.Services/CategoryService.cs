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
        Category GetCategoryByID(int id);
        void Create(Category category);
        Category Update(Category newCategory);
        void Delete(int id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context) // Contructor injection
        {
            this._context = context;
        }
        public void Create(Category category)
        {
            var result = _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var result = _context.Categories.FirstOrDefault(c => c.CategoryID == id, null);
            if (result != null)
            {
                _context.Categories.Remove(result);
                _context.SaveChanges();
            }
        }

        public List<Category> GetAllCategories()
        {
            var result = _context.Categories.ToList();
            return result;
        }

        public Category GetCategoryByID(int id)
        {
            var result = _context.Categories.FirstOrDefault(c => c.CategoryID == id) ?? new Category();
            return result;
        }

        public Category Update(Category newCategory)
        {
            var result = _context.Categories.Attach(newCategory);

            var entity = _context.ChangeTracker.Entries()
                .FirstOrDefault(e => e.Entity == newCategory);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _context.SaveChanges();
            return newCategory;
        }
    }
}
