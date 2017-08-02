using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jobApplication.Models
{
    public class FileLogModel
    {
        public string FileDate { get; set; }
        public string FileContent { get; set; }
        public string LogDate { get; set; }
        public string LogDescription { get; set; }
    }
}