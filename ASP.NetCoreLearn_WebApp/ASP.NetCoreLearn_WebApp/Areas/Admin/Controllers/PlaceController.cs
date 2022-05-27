using ASP.NetCoreLearn.DataAccessLayer;
using ASP.NetCoreLearn.DataAccessLayer.Infrastructure.IRepository;
using ASP.NetCoreLearn.Models;
using ASP.NetCoreLearn.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP.NetCoreLearn_WebApp.Controllers
{   
    [Area("Admin")]
    public class PlaceController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public PlaceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {   
            PlaceViewModel placeVM = new PlaceViewModel();
            placeVM.Places = _unitOfWork.Place.GetAll();
            return View(placeVM);
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
        public IActionResult AddPlaceUpdate(int? id)
        {   
         
            PlaceViewModel placeVM = new PlaceViewModel()
            {
                Place = new(),
                Cities = _unitOfWork.City.GetAll().Select(x=> 
                new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };
            if (id == null || id == 0)
            {
                return View(placeVM);
            }
            else
            {
                placeVM.Place = _unitOfWork.Place.GetT(x=>x.PlaceId == id);
                if (placeVM.Place == null)
                {
                    return NotFound();
                }

                else
                {
                    return View(placeVM);
                }
                
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPlaceUpdate([Bind] PlaceViewModel placeVM)
        {
            if (ModelState.IsValid)
            {   

                if(placeVM.Place.PlaceId == 0)
                {
                    _unitOfWork.Place.Add(placeVM.Place);
                    TempData["succcess"] = "Add Place Successfuly";
                }

                else
                {
                    _unitOfWork.Place.Update (placeVM.Place);
                    TempData["succcess"] = "Update Place Successfuly";
                }
             
                _unitOfWork.Save();
                
                return RedirectToAction("Index");
            }
         
                return RedirectToAction("Index");   
        }

        //Edit city End



        //Delete city start
        [HttpGet]
        public IActionResult DeletePlace(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var places = _unitOfWork.Place.GetT(x => x.PlaceId == id);
            if (places == null)
            {
                return NotFound();
            }

            return View(places);
        }


        [HttpPost, ActionName("DeletePlace")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var places = _unitOfWork.Place.GetT(x => x.PlaceId == id);
            if (places == null)
            {
                return NotFound();
            }
            _unitOfWork.Place.Delete(places);
            _unitOfWork.Save();
            TempData["succcess"] = "Deleted Place Successfuly";
            return RedirectToAction("Index");
        }

        //Delete city End
    }
}
