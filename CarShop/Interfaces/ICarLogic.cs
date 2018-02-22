using CarShop.Models;

namespace CarShop.Interfaces
{
    public interface ICarLogic
    {
        Car FullfillProperties(Car car);
        bool IsUserAuthorized();
    }
}