using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieSiteApp.entity
{
    public class MovieCategory
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}