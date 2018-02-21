using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarShop.Interfaces;
using CarShop.Models;

namespace CarShop.Repository
{
    public class CarRepository : AbstractRepository<Car>, ICarRepository
    {

    }
}