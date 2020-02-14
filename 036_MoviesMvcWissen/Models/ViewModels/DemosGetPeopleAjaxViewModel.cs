using _036_MoviesMvcWissen.Models.Demos.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _036_MoviesMvcWissen.Models.ViewModels
{
    public class DemosGetPeopleAjaxViewModel
    {
        public List<PersonModel> PeopleModel { get; set; }
        public PersonModel PersonModel { get; set; }
    }
}