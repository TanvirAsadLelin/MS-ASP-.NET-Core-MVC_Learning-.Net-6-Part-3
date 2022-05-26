using ASP.NetCoreLearn.DataAccessLayer;
using ASP.NetCoreLearn.DataAccessLayer.Infrastructure.IRepository;
using ASP.NetCoreLearn.Models;
using ASP.NetCoreLearn.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NetCoreLearn_WebApp.Controllers
{   
    [Area("Admin")]
    public class CityController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public CityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {   
            CityViewModel cityViewModel = new CityViewModel();  
           cityViewModel.cities = _unitOfWork.City.GetAll();
            return View(cityViewModel);
        }

        //Add city start

        //[HttpGet]
        //public IActionResult AddCity()
        //{
        //    return View();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult AddCity(City city)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.City.Add(city);
        //        _unitOfWork.Save();
        //        TempData["succcess"] = "New city added!";
        //        return RedirectToAction("Index");
        //    }
        //    return View(city);
        //}


        //Add city End


        //Edit city start
        [HttpGet]
        public IActionResult AddCityUpdate(int? id)
        {   
            CityViewModel cityViewModel = new CityViewModel();
            if(id == null || id == 0)
            {
                return View(cityViewModel);
            }
            else
            {
                var EditCity = _unitOfWork.City.GetT(x=>x.Id == id);    
                if (EditCity == null)
                {
                    return NotFound();
                }

                else
                {
                    return View(EditCity);
                }
                
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCityUpdate(CityViewModel cityViewModel)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.City.Add(cityViewModel.City);
                _unitOfWork.Save();

                TempData["succcess"] = "Updated city Successfuly";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        //Edit city End



        //Delete city start
        [HttpGet]
        public IActionResult DeleteCity(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cities = _unitOfWork.City.GetT(x => x.Id == id);
            if (cities == null)
            {
                return NotFound();
            }

            return View(cities);
        }


        [HttpPost, ActionName("DeleteCity")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var cities = _unitOfWork.City.GetT(x => x.Id == id);
            if (cities == null)
            {
                return NotFound();
            }
            _unitOfWork.City.Delete(cities);
            _unitOfWork.Save();
            TempData["succcess"] = "Deleted city Successfuly";
            return RedirectToAction("Index");
        }

        //Delete city End
    }
}
