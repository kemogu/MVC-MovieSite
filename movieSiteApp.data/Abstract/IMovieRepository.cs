using System.Collections.Generic;
using movieSiteApp.entity;

namespace movieSiteApp.data.Abstract
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        Movie GetMovieWithCategories(int id);
        void AddMovie(Movie movie);
        void AddMovieWithCategories(Movie movie, IEnumerable<int> categoryIds);
        void UpdateMovie(Movie movie, IEnumerable<int> selectedCategoryIds);
        void DeleteMovie(Movie movie);
        List<Category> GetCategoriesByMovieId(int id);
    }
}
