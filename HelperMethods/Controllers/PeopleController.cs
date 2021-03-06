﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HelperMethods.Models;

namespace HelperMethods.Controllers
{
    public class PeopleController : Controller
    {
        private Person[] personData = {
            new Person {FirstName = "Adam", LastName = "Freeman", Role = Role.Admin},
            new Person {FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User},
            new Person {FirstName = "John", LastName = "Smith", Role = Role.User},
            new Person {FirstName = "Anne", LastName = "Jones", Role = Role.Guest}
            };
        

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult GetPeople(string selectedRole = "All")
        {
            //return View(personData);
            return View((object) selectedRole);
        }

        //[HttpPost]
        //public ActionResult GetPeople(string selectedRole)
        //{
        //    if (selectedRole == null || selectedRole == "All")
        //    {
        //        return View(personData);
        //    }
        //    var selected = (Role) Enum.Parse(typeof(Role), selectedRole);
        //    return View(personData.Where(p => p.Role == selected));
        //}

        private IEnumerable<Person> GetData(string selectedRole)
        {
            IEnumerable<Person> data = personData;
            if (selectedRole != "All")
            {
                var selected = (Role)Enum.Parse(typeof(Role), selectedRole);
                data = personData.Where(p => p.Role == selected);
            }
            return data;
        }

        //public PartialViewResult GetPeopleData(string selectedRole = "All")
        //{
        //    IEnumerable<Person> data = personData;
        //    if (selectedRole != "All")
        //    {
        //        var selected = (Role)Enum.Parse(typeof(Role), selectedRole);
        //        data = personData.Where(p => p.Role == selected);
        //    }

        //    return PartialView(data);
        //}

        public JsonResult GetPeopleDataJson(string selectedRole = "All")
        {
            //IEnumerable<Person> data = GetData(selectedRole);
            var data = GetData(selectedRole).Select(p => new
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                Role = Enum.GetName(typeof(Role), p.Role)
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetPeopleData(string selectedRole = "All")
        {
            return PartialView(GetData(selectedRole));
        }
    }
}