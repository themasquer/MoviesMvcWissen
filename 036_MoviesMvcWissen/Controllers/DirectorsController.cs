using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _036_MoviesMvcWissen.Contexts;
using _036_MoviesMvcWissen.Entities;
using _036_MoviesMvcWissen.Models.ViewModels;
using _036_MoviesMvcWissen.Validations.FluentValidation;
using FluentValidation.Results;

namespace _036_MoviesMvcWissen.Controllers
{
    public class DirectorsController : Controller
    {
        private MoviesContext db = new MoviesContext();

        // GET: Directors
        public ActionResult Index()
        {
            //return View(db.Directors.ToList());
            var model = new DirectorsIndexViewModel()
            {
                Directors = db.Directors.ToList()
            };
            return View(model);
        }

        // GET: Directors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = db.Directors.Find(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        // GET: Directors/Create
        public ActionResult Create()
        {
            var movies = db.Movies.Select(e => new SelectListItem()
            {
                Value = e.Id.ToString(),
                Text = e.Name
            }).ToList();
            ViewBag.Movies = new MultiSelectList(movies, "Value", "Text");
            return View();
        }

        // POST: Directors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,Surname,Retired")] Director director)
        [ActionName("Create")]
        //public ActionResult CreateNew() // 1
        public ActionResult CreateNew(FormCollection formCollection) // 2
        {
            var director = new Director()
            {
                Id = 0,
                //Name = Request.Form["Name"], // 1
                //Surname = Request.Form["Surname"] // 1
                Name = formCollection["Name"], // 2
                Surname = formCollection["Surname"] // 2
            };
            //var retired = Request.Form["Retired"]; // 1
            var retired = formCollection["Retired"]; // 2
            var movieIds = formCollection["movieIds"].Split(',');
            director.Retired = true;
            if (retired.Equals("false"))
                director.Retired = false;
            if (String.IsNullOrWhiteSpace(director.Name))
                ModelState.AddModelError("Name", "Director Name is required!");
            if (String.IsNullOrWhiteSpace(director.Surname))
                ModelState.AddModelError("Surname", "Director Surname is required!");
            if (director.Name.Length > 100)
                ModelState.AddModelError("Name", "Director Name must be maximum 100 characters!");
            if (director.Surname.Length > 100)
                ModelState.AddModelError("Surname", "Director Surname must be maximum 100 characters!");
            if (ModelState.IsValid)
            {
                director.MovieDirectors = movieIds.Select(e => new MovieDirector()
                {
                    MovieId = Convert.ToInt32(e),
                    DirectorId = director.Id
                }).ToList();
                db.Directors.Add(director);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(director);
        }

        // GET: Directors/Edit/5
        #region Edit Get 1
        //public ActionResult Edit(int? id) // 1
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Director director = db.Directors.Find(id);
        //    if (director == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    var movies = db.Movies.Select(e => new SelectListItem()
        //    {
        //        Value = e.Id.ToString(),
        //        Text = e.Name
        //    }).ToList();
        //    var movieIds = director.MovieDirectors.Select(e => e.MovieId).ToList();
        //    ViewBag.Movies = new MultiSelectList(movies, "Value", "Text", movieIds);
        //    return View(director);
        //}
        #endregion

        public ActionResult Edit(int? id) // 2
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var movies = db.Movies.Select(e => new SelectListItem()
            {
                Value = e.Id.ToString(),
                Text = e.Name
            }).ToList();
            var director = db.Directors.Find(id.Value);
            //List<int> _movieIds = db.MovieDirectors.Where(e => e.DirectorId == id.Value).Select(e => e.MovieId).ToList();
            List<int> _movieIds = director.MovieDirectors.Select(e => e.MovieId).ToList();
            DirectorsEditViewModel model = new DirectorsEditViewModel();
            model.Director = director;
            model.movieIds = _movieIds;
            model.Movies = new MultiSelectList(movies, "Value", "Text", model.movieIds);
            return View("EditNew", model);
        }

        // POST: Directors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        #region Edit Post 1
        //public ActionResult Edit([Bind(Include = "Id,Name,Surname,Retired")] Director director, List<int> movieIds) // 1
        //{
        //    var dbDirector = db.Directors.Find(director.Id);
        //    dbDirector.Name = director.Name;
        //    dbDirector.Surname = director.Surname;
        //    dbDirector.Retired = director.Retired;
        //    var dbMovieDirectors = db.MovieDirectors.Where(e => e.DirectorId == director.Id).ToList();
        //    foreach (var dbMovieDirector in dbMovieDirectors)
        //    {
        //        db.MovieDirectors.Remove(dbMovieDirector);
        //    }
        //    dbDirector.MovieDirectors = movieIds.Select(e => new MovieDirector()
        //    {
        //        MovieId = e,
        //        DirectorId = director.Id
        //    }).ToList();
        //    //if (ModelState.IsValid)
        //    //{
        //    //    db.Entry(director).State = EntityState.Modified;
        //    //    db.SaveChanges();
        //    //    return RedirectToAction("Index");
        //    //}
        //    DirectorValidator validator = new DirectorValidator();
        //    ValidationResult result = validator.Validate(director);
        //    if (result.IsValid)
        //    {
        //        db.Entry(dbDirector).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(director);
        //}
        #endregion
        public ActionResult Edit(DirectorsEditViewModel directorEditViewModel) // 2
        {
            if (ModelState.IsValid)
            {
                var director = db.Directors.Find(directorEditViewModel.Director.Id);
                director.Name = directorEditViewModel.Director.Name;
                director.Surname = directorEditViewModel.Director.Surname;
                director.Retired = directorEditViewModel.Director.Retired;
                var movieDirectors = db.MovieDirectors.Where(e => e.DirectorId == director.Id).ToList();
                foreach (var movieDirector in movieDirectors)
                {
                    db.MovieDirectors.Remove(movieDirector);
                }
                director.MovieDirectors = directorEditViewModel.movieIds.Select(e => new MovieDirector()
                {
                    DirectorId = director.Id,
                    MovieId = e
                }).ToList();
                db.Entry(director).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(directorEditViewModel);
        }

        // GET: Directors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = db.Directors.Find(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        // POST: Directors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Director director = db.Directors.Find(id);
            db.Directors.Remove(director);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
