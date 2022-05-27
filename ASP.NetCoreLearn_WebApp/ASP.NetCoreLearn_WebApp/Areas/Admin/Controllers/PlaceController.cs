﻿using ASP.NetCoreLearn.DataAccessLayer;
using ASP.NetCoreLearn.DataAccessLayer.Infrastructure.IRepository;
using ASP.NetCoreLearn.Models;
using ASP.NetCoreLearn.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult AddCityUpdate(int? id)
        {   
            CityViewModel cityViewModel = new CityViewModel();
            if(id == null || id == 0)
            {
                return View(cityViewModel);
            }
            else
            {
                cityViewModel.City = _unitOfWork.City.GetT(x=>x.Id == id);    
                if (cityViewModel.City == null)
                {
                    return NotFound();
                }

                else
                {
                    return View(cityViewModel);
                }
                
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCityUpdate([Bind]CityViewModel cityViewModel)
        {
            if (ModelState.IsValid)
            {   

                if(cityViewModel.City.Id == 0)
                {
                    _unitOfWork.City.Add(cityViewModel.City);
                    TempData["succcess"] = "Created city Successfuly";
                }

                else
                {
                    _unitOfWork.City.Update (cityViewModel.City);
                    TempData["succcess"] = "Updated city Successfuly";
                }
             
                _unitOfWork.Save();
                
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
