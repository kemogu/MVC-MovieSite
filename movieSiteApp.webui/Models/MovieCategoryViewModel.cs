using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movieSiteApp.entity;

namespace movieSiteApp.webui.Models
{
    public class MovieCategoryViewModel
    {
        public Movie Movie { get; set; }
        public List<Category> Categories { get; set; }
        public List<int> SelectedCategoryIds { get; set; }
    }
}