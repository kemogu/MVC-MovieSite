using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using movieSiteApp.data.Abstract;
using movieSiteApp.entity;

namespace movieSiteApp.data.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            var categories = _dbContext.MovieCategories
                                            .Where(mc => mc.MovieId == id)
                                            .Select(mc => mc.Category)
                                            .FirstOrDefault();
            return categories;
        }

        public void AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _dbContext.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);

            if(category != null)
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
            }
        }

        public List<Category> GetCategoriesById(int id)
        {
            var categories = _dbContext.MovieCategories
                            .Where(mc => mc.MovieId == id)
                            .Select(mc => mc.Category)
                            .ToList();
            return categories;    
        }
    }
}