using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adso.Models;
using Adso.Models.DbModels;
using Adso.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Adso.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityRepository _cityRepository;
        private readonly AdsoDbContext _context;

        public CitiesController(ICityRepository cityRepository, AdsoDbContext context)
        {
            _cityRepository = cityRepository;
            _context = context;
        }
        public IActionResult Index(string searchString)
        {
            // retrieve all the countries
            var model = _cityRepository.GetAllCities();

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(s => s.CityName.Contains(searchString));
            }

            // Pass the list of countries to the view
            return View(model);
        }
        public ViewResult Details(int? id)
        {
            CityDetailsViewModel cityDetailsViewModel = new CityDetailsViewModel()
            {
                City = _cityRepository.GetCities(id ?? 1),
                PageTitle = "City Details"
            };

            return View(cityDetailsViewModel);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(City city)
        {
            if (ModelState.IsValid)
            {
                City newCity = _cityRepository.Add(city);
                return RedirectToAction("details", new { id = newCity.Id });
            }
            return View();
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            City city = _cityRepository.GetCities(id);
            CityEditViewModel cityEditViewModel = new CityEditViewModel
            {
                Id = city.Id,
                Country = city.Country,
                CityName = city.CityName,
                CityCode = city.CityCode,
                Status = city.Status
            };
            return View(cityEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(CityEditViewModel model)
        {
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (ModelState.IsValid)
            {
                // Retrieve the employee being edited from the database
                City city = _cityRepository.GetCities(model.Id);
                // Update the employee object with the data in the model object
                city.Country = model.Country;
                city.CityName = model.CityName;
                city.CityCode = model.CityCode;
                city.Status = model.Status;

                // Call update method on the repository service passing it the
                // employee object to update the data in the database table
                City updatedCity = _cityRepository.Update(city);

                return RedirectToAction("index");
            }

            return View(model);
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.Cities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
