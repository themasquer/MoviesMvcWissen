using _036_MoviesMvcWissen.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _036_MoviesMvcWissen.Models.ViewModels
{
    public class DirectorsEditViewModel
    {
        public Director Director { get; set; }
        public MultiSelectList Movies { get; set; }
        public List<int> movieIds { get; set; }
    }
}