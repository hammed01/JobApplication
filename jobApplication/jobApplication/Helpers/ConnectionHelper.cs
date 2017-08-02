using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Web;

namespace jobApplication.Helpers
{
    public class ConnectionHelper
    {
        public static string con( )
            {
            return WebConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        }
    }
}