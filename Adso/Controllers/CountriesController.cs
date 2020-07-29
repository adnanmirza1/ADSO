using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Adso.Models;
using Adso.Models.DbModels;
using Adso.Models.ViewModels;

namespace Adso.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly AdsoDbContext _context;

        public CountriesController(ICountryRepository countryRepository, AdsoDbContext context)
        {
            _countryRepository = countryRepository;
            _context = context;
        }

        public IActionResult Index(string searchString)
        {
            // retrieve all the countries
            var model = _countryRepository.GetAllCountries();

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(s => s.CountryName.Contains(searchString));
            }

            // Pass the list of countries to the view
            return View(model);

        }

        public ViewResult Details(int? id)
        {
            CountryDetailsViewModel countryDetailsViewModel = new CountryDetailsViewModel()
            {
                Country = _countryRepository.GetCountries(id ?? 1),
                PageTitle = "Country Details"
            };

            return View(countryDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                Country newCountry = _countryRepository.Add(country);
                return RedirectToAction("details", new { id = newCountry.Id });
            }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Country country = _countryRepository.GetCountries(id);
            CountryEditViewModel countryEditViewModel = new CountryEditViewModel
            {
                Id = country.Id,
                CountryName = country.CountryName,
                ShortName = country.ShortName,
                Currency = country.Currency,
                CallingCode = country.CallingCode,
                Status = country.Status
            };
            return View(countryEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(CountryEditViewModel model)
        {
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (ModelState.IsValid)
            {
                // Retrieve the employee being edited from the database
                Country country = _countryRepository.GetCountries(model.Id);
                // Update the employee object with the data in the model object
                country.CountryName = model.CountryName;
                country.ShortName = model.ShortName;
                country.Currency = model.Currency;
                country.CallingCode = model.CallingCode;
                country.Status = model.Status;

                // Call update method on the repository service passing it the
                // employee object to update the data in the database table
                Country updatedCountry = _countryRepository.Update(country);

                return RedirectToAction("index");
            }

            return View(model);
        }

        // GET: Countries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        //public async Task<IActionResult> IndexAsync(string searchString)
        //{
        //    // retrieve all the employees
        //    var countries = from m in _context.Countries
        //                    select m;
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        countries = countries.Where(s => s.CountryName.Contains(searchString));
        //    }

        //    return View(await countries.ToListAsync());

        //}

    }
}
