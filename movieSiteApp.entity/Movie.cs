using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieSiteApp.entity
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double ImdbRating { get; set; }
        public string Description { get; set; }
        public ICollection<MovieCategory> MovieCategories { get; set; }
    }
}