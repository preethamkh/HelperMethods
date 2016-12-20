using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelperMethods.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Fruits = new String[] {"Apple", "Orange", "Pear"};
            ViewBag.Cities = new String[] {"New York", "London", "Paris"};
            string message = "This is an HTML element: <input>";
            return View((object)message);
        }
    }
}