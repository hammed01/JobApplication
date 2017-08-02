using EfueliteSolutionsMailHandler;
using jobApplication.Helpers;
using jobApplication.Models;
using EfueliteSolutionsFileLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jobApplication.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        [HttpGet]
        public ActionResult SendMail()
        {
            EmailModel email = new EmailModel();
            return View(email);
        }
        [HttpPost]
        public ActionResult SendMail(EmailModel email)
        {
            if (!ModelState.IsValid)
            {
               // email.ActionStatus = false;
                email.ActionMessage = "Error. Please enter correct value";

                return View(email);

            }
            else
            {
                //email.ActionStatus = true;
                email.SMTPHost = SmtpHelper.SMTPHost;
                email.SMTPPort = SmtpHelper.SMTPPort;
                email.SMTPUser = SmtpHelper.SMTPUser;
                email.SMTPPassword = SmtpHelper.SMTPPassword;
                email.EnableSSL = true;

                email.ActionMessage = MailServer.SendMailSync("Shotolahammed01@gmail.com", "Shotola Hammed", email.ToEMailAddress, email.ccEMailAddress, email.bccEMailAddress, email.Subject, email.Message, email.SMTPHost, email.SMTPPort, email.SMTPUser,
                    email.SMTPPassword, email.EnableSSL, true);
            }
            if (email.ActionMessage == "Mail sent successfully")
            {
                email.ActionStatus = true;
                FileLog.Write(email.ActionMessage);

            } else
            { 
                email.ActionStatus = false;
            email.ActionMessage = "Mail not Sent Successfully";
            FileLog.Write(email.ActionMessage);
        }
            return View(email);
        }
    }
}