using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _036_MoviesMvcWissen.Models.Demos.Templates
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public bool GraduatedFromUniversity { get; set; }
        public string IdentityNo { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}