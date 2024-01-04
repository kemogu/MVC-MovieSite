using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movieSiteApp.business;
using movieSiteApp.business.Abstract;
using movieSiteApp.entity;

namespace movieSiteApp.webui.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAllCategories();
            return View(categories);
        }
        public IActionResult Details(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _categoryService.AddCategory(category);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            System.Console.WriteLine(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _categoryService.UpdateCategory(category);
            System.Console.WriteLine(category.Name);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}