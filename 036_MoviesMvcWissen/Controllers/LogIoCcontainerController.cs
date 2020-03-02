using _036_MoviesMvcWissen.Models.LogDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _036_MoviesMvcWissen.Controllers
{
    public class LogIoCcontainerController : Controller
    {
        private ILogger _logger;

        public LogIoCcontainerController(ILogger logger)
        {
            _logger = logger;
        }
        
        public ActionResult Index()
        {
            _logger.Log("Home Controller -> Index Action executed.");
            return Content("Home Controller -> Index Action executed.");
        }
    }
}