using _036_MoviesMvcWissen.Contexts;
using _036_MoviesMvcWissen.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace _036_MoviesMvcWissen.Controllers
{
    public class LoginController : Controller
    {
        MoviesContext db = new MoviesContext();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(e => e.UserName == user.UserName && e.Password == user.Password && e.Active == true))
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return returnUrl == null ? RedirectToAction("Index", "Movies") : (ActionResult)Redirect(returnUrl);
                }
                ViewBag.Message = "User Name or Password is incorrect!";
                return View(user);
            }
            ViewBag.Message = "User Name or Password is invalid!";
            return View(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Movies");
        }
    }
}