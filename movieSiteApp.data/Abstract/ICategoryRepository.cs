using System.Collections.Generic;
using movieSiteApp.entity;

namespace movieSiteApp.data.Abstract
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        List<Category> GetCategoriesById(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
