using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarShop.API_Consumer.Models
{
    public class EmailApiModel
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
    }
}