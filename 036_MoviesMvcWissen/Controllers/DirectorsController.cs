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
            return View(db.Directors.ToList());
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
                //Name = Request.Form["Name"], // 1
                //Surname = Request.Form["Surname"] // 1
                Name = formCollection["Name"], // 2
                Surname = formCollection["Surname"] // 2
            };
            //var retired = Request.Form["Retired"]; // 1
            var retired = formCollection["Retired"]; // 2
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
                db.Directors.Add(director);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(director);
        }

        // GET: Directors/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Directors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,Retired")] Director director)
        {

            //if (ModelState.IsValid)
            //{
            //    db.Entry(director).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            DirectorValidator validator = new DirectorValidator();
            ValidationResult result = validator.Validate(director);
            if (result.IsValid)
            {
                db.Entry(director).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(director);
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
