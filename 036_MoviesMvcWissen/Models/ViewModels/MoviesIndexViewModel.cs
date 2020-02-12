using _036_MoviesMvcWissen.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _036_MoviesMvcWissen.Models.ViewModels
{
    public class MoviesIndexViewModel
    {
        public List<Movie> Movies { get; set; }
        public SelectList Years { get; set; }
        public string YearId { get; set; } = "";

        // Hüseyin
        public string Name { get; set; } = "";
        public string Min { get; set; } = "";
        public string Max { get; set; } = "";

    }
}