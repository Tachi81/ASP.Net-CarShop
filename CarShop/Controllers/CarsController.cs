using System.Linq;
using System.Net;
using System.Web.Mvc;
using CarShop.Interfaces;
using CarShop.ViewModels;

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
            var carVM = new CarViewModel()
            {
                IsUserAuthorized = HttpContext.User.Identity.IsAuthenticated
            };
            if (_carLogic.IsUserAuthorized())
            {
                carVM.CarList = _carRepository.GetWhere(x => x.Id > 0);
            }
            else
            {
                carVM.CarList = _carRepository.GetWhere(x => x.Id > 0 && x.IsActive);
            }
            return View("Index", carVM);

        }





        // GET: Cars/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var carVM = new CarViewModel
            {
                Car = _carRepository.GetWhere(x => x.Id == id).FirstOrDefault()
            };
            if (carVM.Car == null)
            {
                return HttpNotFound();
            }
            return View(carVM);
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
        public ActionResult Create(CarViewModel car)
        {

            if (ModelState.IsValid)
            {

                _carRepository.Create(car.Car);

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
            var carVM = new CarViewModel
            {
                Car = _carRepository.GetWhere(x => x.Id == id).FirstOrDefault()
            };
            if (carVM.Car == null)
            {
                return HttpNotFound();
            }
            return View(carVM);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarViewModel car)
        {
            if (ModelState.IsValid)
            {
                _carRepository.Update(car.Car);

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

            var carVM = new CarViewModel
            {
                Car = _carRepository.GetWhere(x => x.Id == id).FirstOrDefault()
            };
            if (carVM.Car == null)
            {
                return HttpNotFound();
            }
            return View(carVM);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var carVM = new CarViewModel();
             carVM.Car = _carRepository.GetWhere(x => x.Id == id).FirstOrDefault();

            _carRepository.Delete(carVM.Car);
            return RedirectToAction("Index");
        }


    }
}
