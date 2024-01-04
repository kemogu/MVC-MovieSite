using movieSiteApp.entity;
using System.Collections.Generic;

namespace movieSiteApp.business.Abstract
{
    public interface ICategoryService
    {
        Category GetCategoryById(int id);
        List<Category> GetCategoriesById(int id);
        IEnumerable<Category> GetAllCategories();
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
