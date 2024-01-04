using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movieSiteApp.business;
using movieSiteApp.business.Abstract;
using movieSiteApp.entity;
using movieSiteApp.webui.Models;

namespace movieSiteApp.webui.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICategoryService _categoryService;

        public MoviesController(IMovieService movieService, ICategoryService categoryService)
        {
            _movieService = movieService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var movies = _movieService.GetAllMovies();
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _movieService.GetMovieById(id);

            var categories = _categoryService.GetCategoriesById(id);

            var viewModel = new MovieCategoryViewModel
            {
                Movie = movie,
                Categories = categories
            };
            return View(viewModel);
        }

        public IActionResult Create()
        {
            var categories = _categoryService.GetAllCategories();
            var viewModel = new MovieCategoryViewModel
            {
                Categories = (List<Category>)categories
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieCategoryViewModel viewModel)
        {
            if (viewModel.Movie != null)
            {
                var newMovie = viewModel.Movie;

                var selectedCategoryIds = viewModel.SelectedCategoryIds;

                _movieService.AddMovieWithCategories(newMovie, selectedCategoryIds);

                foreach (var item in selectedCategoryIds)
                {
                    System.Console.WriteLine(item);
                }

                return RedirectToAction(nameof(Index));
            }
            viewModel.Categories = (List<Category>)_categoryService.GetAllCategories();

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var movie = _movieService.GetMovieById(id);
            var categories = _categoryService.GetAllCategories();
            var viewModel = new MovieCategoryViewModel
            {
                Movie = movie,
                Categories = (List<Category>)categories,
                SelectedCategoryIds = _movieService.GetCategoriesByMovieId(id).Select(c => c.Id).ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MovieCategoryViewModel viewModel)
        {
            if(viewModel.Movie != null)
            {
                var editedMovie = viewModel.Movie;
                var selectedCategoryIds = viewModel.SelectedCategoryIds;

                _movieService.UpdateMovie(editedMovie, selectedCategoryIds);

                return RedirectToAction(nameof(Index));
            }
            viewModel.Categories = (List<Category>)_categoryService.GetAllCategories();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _movieService.GetMovieById(id);
            System.Console.WriteLine("GetID");
            return View(movie);
            
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _movieService.DeleteMovie(movie);
            return RedirectToAction("Index");
        }
    }
}