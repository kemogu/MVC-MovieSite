using movieSiteApp.entity;
using System.Collections.Generic;

namespace movieSiteApp.business.Abstract
{
    public interface IMovieService
    {
        Movie GetMovieById(int id);
        IEnumerable<Movie> GetAllMovies();
        List<Category> GetCategoriesByMovieId(int id);
        void AddMovie(Movie movie);
        void AddMovieWithCategories(Movie movie,  IEnumerable<int> categoryIds);
        void UpdateMovie(Movie movie, IEnumerable<int> selectedCategoryIds);
        void DeleteMovie(Movie movie);
    }
}
