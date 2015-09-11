using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beer2Go.WebSite.Controllers
{
    public class RootController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Beers()
        {
            ViewBag.Message = "Page to display all the brew";

            return View();
        }

        public ActionResult Cart()
        {
            ViewBag.Message = "Page to display the cart";

            return View();
        }

        public ActionResult Wines()
        {
            ViewBag.Message = "Page to display all the wines";

            return View();
        }

        public ActionResult Trucks()
        {
            ViewBag.Message = "Page to display where the trucks are";

            return View();
        }
    }
}