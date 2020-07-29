using Adso.Models.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adso.Models.DbModels
{
    public class MockCountryRepository : ICountryRepository
    {
        private List<Country> _countryList;
        public MockCountryRepository()
        {
            _countryList = new List<Country>()
            {
                new Country() { Id = 1, CountryName = "Pakistan", ShortName = "Pak" , CallingCode = "+92", Currency = "Rs", Status = Enumrations.Active, },
                new Country() { Id = 2, CountryName = "India", ShortName = "Ind" , CallingCode = "+91", Currency = "Rs", Status = Enumrations.Active, },
                new Country() { Id = 3, CountryName = "America", ShortName = "USA" , CallingCode = "+1", Currency = "Dollars", Status = Enumrations.Inactive, },

            };
        }
        public Country Add(Country country)
        {
            country.Id = _countryList.Max(e => e.Id) + 1;
            _countryList.Add(country);
            return country;
        }

        public Country Delete(int Id)
        {
            Country country = _countryList.FirstOrDefault(e => e.Id == Id);
            if (country != null)
            {
                _countryList.Remove(country);
            }
            return country;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _countryList;
        }

        public Country GetCountries(int Id)
        {
            return this._countryList.FirstOrDefault(e => e.Id == Id);
        }

        public Country Update(Country countryChanges)
        {
            Country country = _countryList.FirstOrDefault(e => e.Id == countryChanges.Id);
            if (country != null)
            {
                country.CountryName = countryChanges.CountryName;
                country.ShortName = countryChanges.ShortName;
                country.CallingCode = countryChanges.CallingCode;
                country.Currency = countryChanges.Currency;
                country.Status = countryChanges.Status;
            }
            return country;
        }
    }
}
