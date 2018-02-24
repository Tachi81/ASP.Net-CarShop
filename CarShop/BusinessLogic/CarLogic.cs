using System.Web;
using CarShop.Interfaces;

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