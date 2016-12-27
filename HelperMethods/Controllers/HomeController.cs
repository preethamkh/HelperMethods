using System;
using System.Web.Mvc;
using HelperMethods.Models;

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

        public ActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult CreatePerson(Person person)
        {
            return View(person);
            //return View("DisplayPerson", person);
        }
    }
}