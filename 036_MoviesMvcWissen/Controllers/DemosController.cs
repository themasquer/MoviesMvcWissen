using _036_MoviesMvcWissen.Models.Demos.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _036_MoviesMvcWissen.Controllers
{
    #region Razor Demos
    public static class NameUtil
    {
        public static string GetName()
        {
            return "Name: Çağıl Alsaç";
        }
    }
    #endregion

    public class DemosController : Controller
    {
        #region Razor Demos
        public ActionResult Razor1() // kodlar için view'a gidilmelidir.
        {
            return View();
        }

        public ActionResult Razor2() // kodlar için view'a gidilmelidir.
        {
            return View();
        }
        #endregion

        #region Route Values
        public string FromRoute(int id)
        {
            return id.ToString();
        }
        #endregion

        #region Query String
        //public string FromQueryString(string name, string surname)
        public string FromQueryString()
        {
            var name = Request.QueryString["name"];
            var surname = Request.QueryString["surname"];
            return name + " " + surname;
        }
        #endregion

        #region Templates
        public ActionResult GetPeople()
        {
            List<Person> people = new List<Person>()
            {
                new Person()
                {
                    Id = 1,
                    FullName = "Çağıl Alsaç",
                    IdentityNo = "123456",
                    GraduatedFromUniversity = true,
                    BirthDate = DateTime.Parse("19.06.1980")
                },
                new Person()
                {
                    Id = 2,
                    FullName = "Leo Alsaç",
                    IdentityNo = "654321",
                    GraduatedFromUniversity = false,
                    BirthDate = DateTime.Parse("25.05.2015")
                }
            };
            Session["people"] = people;
            return View(people);
        }

        public ActionResult GetPersonDetails(int id)
        {
            List<Person> people = Session["people"] as List<Person>;
            Person person = people.SingleOrDefault(e => e.Id == id);
            return View(person);
        }
        #endregion
    }
}