using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarShop.Models;

namespace CarShop.ViewModels
{
    public class CarViewModel
    {
        public Car Car { get; set; }
        public List<Car> CarList { get; set; }
        public bool ShowButton { get; set; }
    }
}