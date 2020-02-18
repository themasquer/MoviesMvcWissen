using _036_MoviesMvcWissen.Contexts;
using _036_MoviesMvcWissen.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _036_MoviesMvcWissen.Areas.Admin.Controllers
{
    //[Authorize(Users = "admin")]
    public class HomeController : Controller
    {
        MoviesContext db = new MoviesContext();

        // GET: Admin/Home
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (db.Users.Any(e => e.UserName == User.Identity.Name && e.RoleId == (int)RoleEnum.Admin))
                {
                    return View(db.vwUsers.ToList());
                }
            }
            return new HttpUnauthorizedResult();
        }
    }
}