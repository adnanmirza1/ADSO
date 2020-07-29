using Adso.Models.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adso.Models.DbModels
{
    public class MockCityRepository : ICityRepository
    {
        private List<City> _cityList;
        public MockCityRepository()
        {
            _cityList = new List<City>()
            {
                new City() { Id = 1, CountryId = 1,   CityName = "Lahore", CityCode="LHR" , Status = Enumrations.Active, },
                
            };
        }

        public City Add(City city)
        {
            city.Id = _cityList.Max(e => e.Id) + 1;
            _cityList.Add(city);
            return city;
        }

        public City Delete(int Id)
        {
            City city = _cityList.FirstOrDefault(e => e.Id == Id);
            if (city != null)
            {
                _cityList.Remove(city);
            }
            return city;
        }

        public IEnumerable<City> GetAllCities()
        {
            return _cityList;
        }

        public City GetCities(int Id)
        {
            return this._cityList.FirstOrDefault(e => e.Id == Id);
        }

        public City Update(City cityChanges)
        {
            City city = _cityList.FirstOrDefault(e => e.Id == cityChanges.Id);
            if (city != null)
            {
                city.Country = cityChanges.Country;
                city.CityName = cityChanges.CityName;
                city.CityCode = cityChanges.CityCode;
                
                city.Status = city.Status;
            }
            return city;
        }
    }

}
