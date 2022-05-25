using ASP.NetCoreLearn_WebApp.Data;
using ASP.NetCoreLearn_WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NetCoreLearn_WebApp.Controllers
{
    public class CityController : Controller
    {
        private ApplicationDbContext _Context;

        public CityController(ApplicationDbContext context)
        {
            _Context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<City> cities = _Context.Cities;
            return View(cities);
        }

        //Add city start

        [HttpGet]
        public IActionResult AddCity()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCity(City city)
        {
            if (ModelState.IsValid)
            {
                _Context.Cities.Add(city);
                _Context.SaveChanges();
                TempData["succcess"] = "New city added!";
                return RedirectToAction("Index");
            }
            return View(city);
        }


        //Add city End


        //Edit city start
        [HttpGet]
        public IActionResult EditCity(int? id)
        {   
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var cities = _Context.Cities.Find(id);
            if (cities == null)
            {
                return NotFound();
            }

            return View(cities);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCity(City city)
        {
            if (ModelState.IsValid)
            {
                _Context.Cities.Update(city);
                _Context.SaveChanges();

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
            var cities = _Context.Cities.Find(id);
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
            var cities = _Context.Cities.Find(id);
            if (cities == null)
            {
                return NotFound();
            }
            _Context.Cities.Remove(cities);
            _Context.SaveChanges();
            TempData["succcess"] = "Deleted city Successfuly";
            return RedirectToAction("Index");
        }

        //Delete city End
    }
}
