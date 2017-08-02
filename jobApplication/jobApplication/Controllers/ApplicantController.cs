using EfueliteSolutionsFileLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jobApplication.Models;
using jobApplication.DataAccess;
using jobApplication.Helpers;
using EfueliteSolutionsDbLogger;


namespace jobApplication.Controllers
{
    public class ApplicantController : Controller

    {
        private readonly IApplicantDataServices _ads;

       public ApplicantController(IApplicantDataServices ads)
        {
            _ads = ads;

        }


        // GET: Applicant
        [HttpGet]
        public ActionResult Registration()
        {
            Person applicant = new Person();
            //FileLog.Write("I got hear");
            return View(applicant);

        }

        [HttpPost]

        public ActionResult Registration(Person applicant)
        {   
            if (!ModelState.IsValid)
            {
                applicant.ActionStatus = false;
                applicant.ActionMessage = "Error. Please enter correct value";
                return View(applicant);
            }
            applicant.Id = RandomHelpers.GenerateApplicantId();

            bool result =   _ads.Register(applicant);

            Person applicant2 = new Person();
            var error = ModelState.Values.SelectMany(v => v.Errors);
            if (result)
            
            {
                applicant2.ActionStatus = true;
                applicant2.ActionMessage = "Registration Successful";
               // DbLogger.WriteLog(ConnectionHelper.con(), applicant.Id + " was registered successfully");
            }
            else
            {
                applicant2.ActionStatus = false;
                applicant2.ActionMessage = "An error occured while trying to process your result, Please try again";
            }

            return View(applicant2);

            }
        
        [HttpGet]
        public ActionResult ListOfApplicant()
        {
            Person applicant3 = new Person();
            applicant3.PersonList = _ads.ListOfApplicant();
            

            return View(applicant3);
        }
        [HttpGet]
        public ActionResult Detail(string Id)
        {
            Person applicant = new Person();
            //applicant = _ads.SelectSingleRec(Id);
            return View(applicant);

        }
        [HttpGet]
        public ActionResult Edit(string Id)
        {
            Person applicant = new Person();
            //applicant = _ads.SelectSingleRec(Id);
            return View(applicant);

        }
        [HttpPost]
        public ActionResult Edit(Person model)
        {
            bool Success = _ads.Update(model);
            Person applicant3 = new Person();
            //applicant3.PersonList =  _ads.ListOfApplicant();
            if (Success)
            {
                applicant3.ActionStatus = true;
                applicant3.ActionMessage = "Edit was successful for " + model.Id;
            }
            else
            {
                applicant3.ActionStatus = false;
                applicant3.ActionMessage = "Edit was not successful for " + model.Id;
            }
            return View("ListOfApplicant", applicant3);

        }




    }
}
    
        