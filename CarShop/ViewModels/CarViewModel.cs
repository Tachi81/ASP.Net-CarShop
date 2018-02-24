using System.Collections.Generic;
using CarShop.Models;

namespace CarShop.ViewModels
{
    public class CarViewModel
    {
        public Car Car { get; set; }
        public List<Car> CarList { get; set; }
        public bool IsUserAuthorized { get; set; }
    }
}