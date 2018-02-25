using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarWithWebApi2.Models
{
    public class EmailApiModel
    {
        public string Topic { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
    }
}