using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyProject.Models
{
    public class Error
    {
        public int ErrorId { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public string DateOfLogin { get; set; }
    }
}