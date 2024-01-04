using movieSiteApp.business.Abstract;
using movieSiteApp.data.Abstract;
using movieSiteApp.entity;
using System.Collections.Generic;

namespace movieSiteApp.business.Concrete
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public void AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovie(Movie movie)
        {
            _movieRepository.DeleteMovie(movie);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _movieRepository.GetAllMovies();
        }

        public Movie GetMovieById(int id)
        {
            return _movieRepository.GetMovieById(id);
        }
        public void AddMovieWithCategories(Movie movie, IEnumerable<int> categoryIds)
        {
            _movieRepository.AddMovieWithCategories(movie, categoryIds);
        }

        public void DeleteMovie(Movie movie, IEnumerable<int> selectedCategoryIds)
        {
            throw new NotImplementedException();
        }
        public void UpdateMovie(Movie movie, IEnumerable<int> selectedCategoryIds)
        {
            _movieRepository.UpdateMovie(movie,selectedCategoryIds);
        }

        public List<Category> GetCategoriesByMovieId(int id)
        {
            return _movieRepository.GetCategoriesByMovieId(id);
        }
    }
}
