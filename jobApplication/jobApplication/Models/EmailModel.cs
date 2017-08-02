using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jobApplication.Models
{
    public class EmailModel
    { 
        public string FromEMailAddress { get; set; }
        public string ToEMailAddress { get; set; }
        public string bccEMailAddress { get; set; }
        public string ccEMailAddress { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string SMTPHost { get; set; }
        public string SMTPPort { get; set; }
        public string SMTPUser { get; set; }
        public string SMTPPassword { get; set; }
        public bool EnableSSL;
        public string ActionMessage;
        public bool ActionStatus;
    }
}