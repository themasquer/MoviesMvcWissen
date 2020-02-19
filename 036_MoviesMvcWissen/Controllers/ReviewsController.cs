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

namespace _036_MoviesMvcWissen.Controllers
{
    [Authorize]
    public class ReviewsController : Controller
    {
        private MoviesContext db = new MoviesContext();

        // GET: Reviews
        [AllowAnonymous]
        public ActionResult Index()
        {
            var reviews = db.Reviews.Include(r => r.Movie);
            return View(reviews.ToList());
        }

        // GET: Reviews/Details/5
        [Route("Reviews/Details/{no?}")]
        [AllowAnonymous]
        public ActionResult Details(int? no)
        {
            if (no == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(no);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Reviews/Create
        [Route("CreateReview")]
        public ActionResult Create()
        {
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Name");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content,Rating,Reviewer,MovieId")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Name", review.MovieId);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Name", review.MovieId);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,Rating,Reviewer,MovieId")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Name", review.MovieId);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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
