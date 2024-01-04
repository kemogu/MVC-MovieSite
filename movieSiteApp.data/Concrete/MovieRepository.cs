using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using movieSiteApp.data.Abstract;
using movieSiteApp.entity;

namespace movieSiteApp.data.Concrete
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _dbContext;

        public MovieRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _dbContext.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _dbContext.Movies.FirstOrDefault(m => m.Id == id);
        }

        public void AddMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }
        public void DeleteMovie(Movie movie)
        {
            var _movie = movie;

            if(_movie != null)
            {
                _dbContext.Movies.Remove(_movie);
                _dbContext.SaveChanges();

                var movieCategories = _dbContext.MovieCategories.Where(mc => mc.MovieId == _movie.Id);
                _dbContext.MovieCategories.RemoveRange(movieCategories);
            }
        }
        public void AddMovieWithCategories(Movie movie, IEnumerable<int> categoryIds)
        {
            using (var context = _dbContext)
            {
                context.Movies.Add(movie);
                context.SaveChanges();

                int movieId = movie.Id;

                foreach (var categoryId in categoryIds)
                {

                    var category = context.Categories.FirstOrDefault(c => c.Id == categoryId);


                    if (category != null)
                    {
                        context.MovieCategories.Add(new MovieCategory { MovieId = movieId, CategoryId = categoryId });
                    }
                }

                context.SaveChanges();
            }
        }

        public Movie GetMovieWithCategories(int id)
        {
            return _dbContext.Movies
            .Include(m => m.MovieCategories)
            .ThenInclude(mc => mc.Category)
            .FirstOrDefault(m => m.Id == id);
        }

        public void UpdateMovie(Movie movie, IEnumerable<int> selectedCategoryIds)
        {
            var existingMovie = _dbContext.Movies
                                .Include(m => m.MovieCategories)
                                .FirstOrDefault(m => m.Id == movie.Id);

            if(existingMovie != null)
            {
                existingMovie.MovieCategories.Clear();
                existingMovie.Title = movie.Title;
                existingMovie.Duration = movie.Duration;
                existingMovie.ReleaseDate = movie.ReleaseDate;
                existingMovie.ImdbRating = movie.ImdbRating;
                existingMovie.Description = movie.Description;

                var selectedCategories = _dbContext.Categories
                                        .Where(c => selectedCategoryIds.Contains(c.Id))
                                        .ToList();
                foreach (var category in selectedCategories)
                {
                    existingMovie.MovieCategories.Add(new MovieCategory
                    {
                        Movie = existingMovie,
                        Category = category
                    });
                }
                _dbContext.SaveChanges();
            }

        }

        public List<Category> GetCategoriesByMovieId(int id)
        {
            return _dbContext.MovieCategories
                                    .Where(mc => mc.MovieId == id)
                                    .Select(mc => mc.Category)
                                    .ToList();
        }
    }
}