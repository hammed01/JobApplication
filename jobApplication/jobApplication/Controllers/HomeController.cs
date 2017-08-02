using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jobApplication.Models;


namespace jobApplication.Controllers
{
    public class HomeController : Controller
    {
        Person person = new Person();
        string name = "Hammed";

        [HttpGet]
        public ActionResult Index()
        {
            person.FirstName = "Hammed";
            person.LastName = "Shotola";
            person.Age = 20;
            person.Address = "Oyingbo";
            person.Sex = "Male";
           // name.Substring(0, 1);
            return View(person);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}