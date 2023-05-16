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
        void Add(Category category);
        Category Update(int id, Category newCategory);
        void Delete(int id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context) // Contructor injection
        {

            this._context = context;

        }
        public void Add(Category category)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllCategories()
        {
            var result = _context.Categories.ToList();
            return result;
        }

        public Category GetCategoryByID(int id)
        {
            throw new NotImplementedException();
        }

        public Category Update(int id, Category newCategory)
        {
            throw new NotImplementedException();
        }
    }
}
