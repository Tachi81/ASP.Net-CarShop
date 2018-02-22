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

        public Car FullfillProperties(Car car)
        {
            if (IsUserAuthorized())
            {
                car.RecordAuthor = HttpContext.Current.User.Identity.Name;

            }
            else
            {
                car.RecordAuthor = "Unauthorized person";

            }
            car.DateCreate = DateTime.Now;
            car.Modificationdate = car.DateCreate;
            car.IsActive = true;
            car.RecordModificationAuthor = car.RecordAuthor;
            return car;
        }
    }
}