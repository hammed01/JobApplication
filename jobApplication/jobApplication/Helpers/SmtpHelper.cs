using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace jobApplication.Helpers
{
    public class SmtpHelper
    {
        public static string SMTPUser = WebConfigurationManager.AppSettings.Get("SMTPUser");
        public static string SMTPHost = WebConfigurationManager.AppSettings.Get("SMTPHost");
        public static string SMTPPort = WebConfigurationManager.AppSettings.Get("SMTPPort");
        public static string SMTPPassword = WebConfigurationManager.AppSettings.Get("SMTPPassword");

    }
}