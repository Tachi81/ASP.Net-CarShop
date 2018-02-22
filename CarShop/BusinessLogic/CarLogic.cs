using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarShop.Interfaces;
using CarShop.Models;

namespace CarShop.BusinessLogic
{
    public class CarLogic : ICarLogic
    {
        public bool IsUserAuthorized()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
       
    }
}