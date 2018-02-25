using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarShop.API_Consumer.Interfaces;
using CarShop.API_Consumer.Models;

namespace CarShop.API_Consumer
{
    public class EmailClient : ClientAbstract<EmailApiModel>, IEmailClient
    {
        public EmailClient()
        {
            SetUrl("http://localhost:56240/api/Email");
        }
    }
}