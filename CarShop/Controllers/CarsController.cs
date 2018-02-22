using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarShop.Interfaces;
using CarShop.Models;
using static System.Net.WebRequestMethods;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarLogic _carLogic;

        public CarsController(ICarRepository carRepository, ICarLogic carLogic)
        {
            _carRepository = carRepository;
            _carLogic = carLogic;
        }

        // GET: Cars
        public ActionResult Index()
        {
            if (_carLogic.IsUserAuthorized())
            {
                return View("Index", _carRepository.GetWhere(x => x.Id > 0));
            }
            
            return View("~/Views/Cars/IndexUnAuthorized.cshtml", _carRepository.GetWhere(x => x.Id > 0));
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Car car = _carRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {

            if (ModelState.IsValid)
            {
                _carLogic.FullfillProperties(car);
                _carRepository.Create(car);

                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = _carRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                car.Modificationdate = DateTime.Now;
                _carRepository.Update(car);

                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = _carRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = _carRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            car.IsActive = false;
            _carRepository.Delete(car);
            return RedirectToAction("Index");
        }


    }
}
