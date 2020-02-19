using _036_MoviesMvcWissen.Models.Demos.Ajax;
using _036_MoviesMvcWissen.Models.Demos.Templates;
using _036_MoviesMvcWissen.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            List<PersonModel> people;
            if (Session["people"] == null)
            {
                people = new List<PersonModel>()
                {
                    new PersonModel()
                    {
                        Id = 1,
                        FullName = "Çağıl Alsaç",
                        IdentityNo = "123456",
                        GraduatedFromUniversity = true,
                        BirthDate = DateTime.Parse("19.06.1980")
                    },
                    new PersonModel()
                    {
                        Id = 2,
                        FullName = "Leo Alsaç",
                        IdentityNo = "654321",
                        GraduatedFromUniversity = false,
                        BirthDate = DateTime.Parse("25.05.2015")
                    }
                };
                Session["people"] = people;
            }
            else
            {
                people = Session["people"] as List<PersonModel>;
            }
            return View(people);
        }

        public ActionResult GetPersonDetails(int id)
        {
            List<PersonModel> people = Session["people"] as List<PersonModel>;
            PersonModel person = people.SingleOrDefault(e => e.Id == id);
            return View(person);
        }

        public ActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPerson(PersonModel personModel)
        {
            List<PersonModel> people = Session["people"] as List<PersonModel>;
            personModel.Id = people.Max(e => e.Id) + 1;
            people.Add(personModel);
            Session["people"] = people;
            return RedirectToAction("GetPeople");
        }
        #endregion

        #region HandleError Action Filter
        [HandleError]
        public ActionResult DivideByZero()
        {
            var no1 = 14;
            var no2 = 0;
            var result = no1 / no2;
            ViewBag.Result = result;
            return View();
        }
        #endregion

        #region AJAX
        public ActionResult GetPeopleAjax()
        {
            List<PersonModel> people;
            if (Session["people"] == null)
            {
                people = new List<PersonModel>()
                {
                    new PersonModel()
                    {
                        Id = 1,
                        FullName = "Çağıl Alsaç",
                        IdentityNo = "123456",
                        GraduatedFromUniversity = true,
                        BirthDate = DateTime.Parse("19.06.1980")
                    },
                    new PersonModel()
                    {
                        Id = 2,
                        FullName = "Leo Alsaç",
                        IdentityNo = "654321",
                        GraduatedFromUniversity = false,
                        BirthDate = DateTime.Parse("25.05.2015")
                    }
                };
                Session["people"] = people;
            }
            else
            {
                people = Session["people"] as List<PersonModel>;
            }
            DemosGetPeopleAjaxViewModel model = new DemosGetPeopleAjaxViewModel()
            {
                PeopleModel = people,
                PersonModel = new PersonModel()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddPersonAjax(PersonModel personModel)
        {
            //Thread.Sleep(3000);
            List<PersonModel> people = Session["people"] as List<PersonModel>;
            personModel.Id = people.Max(e => e.Id) + 1;
            people.Add(personModel);
            Session["people"] = people;
            return PartialView("_PeopleList", people);
        }

        public ActionResult DeletePersonAjax(int id)
        {
            //Thread.Sleep(3000);
            List<PersonModel> people = Session["people"] as List<PersonModel>;
            var person = people.FirstOrDefault(e => e.Id == id);
            people.Remove(person);
            Session["people"] = people;
            return PartialView("_PeopleList", people);
        }

        public ActionResult GetPeopleJson()
        {
            if (Request.IsAjaxRequest())
            {
                var people = new List<PersonModel>()
                {
                    new PersonModel()
                    {
                        Id = 1,
                        FullName = "Çağıl Alsaç",
                        IdentityNo = "123456",
                        GraduatedFromUniversity = true,
                        BirthDate = DateTime.Parse("19.06.1980")
                    },
                    new PersonModel()
                    {
                        Id = 2,
                        FullName = "Leo Alsaç",
                        IdentityNo = "654321",
                        GraduatedFromUniversity = false,
                        BirthDate = DateTime.Parse("25.05.2015")
                    }
                };
                var model = people.Select(e => new PersonModelClientModel()
                {
                    Id = e.Id,
                    FullName = e.FullName,
                    IdentityNo = e.IdentityNo,
                    GraduatedFromUniversity = e.GraduatedFromUniversity,
                    BirthDate = e.BirthDate.HasValue ? e.BirthDate.Value.ToShortDateString() : ""
                });
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            return new EmptyResult();
        }

        public RedirectResult GetPeopleHtml()
        {
            return RedirectPermanent("~/DemosPeople.html");
        }
        #endregion

        #region Route Attribute
        [Route("addtwonumbers/{no1}/{no2}")]
        public ActionResult AddNumbers(int no1, int no2)
        {
            return Content((no1 + no2).ToString());
        }
        #endregion
    }
}