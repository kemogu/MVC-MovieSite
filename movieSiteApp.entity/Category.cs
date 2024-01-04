using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieSiteApp.entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MovieCategory> MovieCategories { get; set; }
    }
}