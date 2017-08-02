using jobApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jobApplication.Helpers;
using EfueliteSolutionsFileLogger;
using EfueliteSolutionsDbLogger;
using System.ComponentModel.DataAnnotations;
using jobApplication.DataAccess;


namespace jobApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminDataServices _ads;

        public AdminController(IAdminDataServices ads)
        {
            _ads = ads;

        }


        // GET: Admin
        [HttpGet]
        public ActionResult AdminReg()
        {
            Person Admin = new Person();

            return View(Admin);

        }
        [HttpPost]
        public ActionResult AdminReg(Person admin)
        {
            
            
            if (!ModelState.IsValid)
            {
                admin.ActionStatus = false;
                admin.ActionMessage = "Error. Please enter correct value";
                return View(admin);
            }
            admin.Id = RandomHelpers.GenerateApplicantId();

            bool result = _ads.AdminReg(admin);

            Person admin1 = new Person();
            var error = ModelState.Values.SelectMany(v => v.Errors);
            if (result)
           {
                admin1.ActionStatus = true;
                admin1.ActionMessage = "Registration Successful";
            }
                 
            else
            {
                admin1.ActionMessage = "An error occured while trying to process your result, Please try again";
                admin1.ActionStatus = false;
            }

            
            return View(admin1);

        }
        [HttpGet]
        public ActionResult ListOfAdmin()
        {
            Person Admin2 = new Person();
            Admin2.PersonList = _ads.ListOfAdmin();

            return View(Admin2);
        }
        public ActionResult Detail(string Id)
        {
            Person Admin = new Person();
            Admin = _ads.SelectSingleRec(Id);
            return View(Admin);

        }
        [HttpGet]
        public ActionResult Edit(string Id)
        {
            Person Admin = new Person();
            Admin = _ads.SelectSingleRec(Id);
            return View(Admin);

        }
        [HttpPost]
        public ActionResult Edit(Person model)
        {
            bool Success =  _ads.Update(model);
            Person Admin2 = new Person();
            Admin2.PersonList = _ads.ListOfAdmin();           
            if (Success)
            {
                Admin2.ActionStatus = true;
                Admin2.ActionMessage = "Edit was successful for " + model.Id;
            }
            else
            {
                Admin2.ActionStatus = false;
                Admin2.ActionMessage = "Edit was not successful for " + model.Id;
            }
            return View("ListOfAdmin", Admin2);
        }

        public ActionResult ViewErrorLog()
        {
            ViewBag.FileLog = FileLog.Read(false);
            return View();

        }
        public ActionResult ViewDbLog()
        {
            ViewBag.DbLog = DbLogger.ReadAllLog(ConnectionHelper.con());
            return View();

        }
      

    }
}




