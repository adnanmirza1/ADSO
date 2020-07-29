using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adso.Models.DbModels
{
    public class SQLCityRepository : ICityRepository
    {
        private readonly AdsoDbContext context;
        public SQLCityRepository(AdsoDbContext context)
        {
            this.context = context;
        }
        public City Add(City city)
        {
            context.Cities.Add(city);
            context.SaveChanges();
            return city;
        }

        public City Delete(int Id)
        {
            City city = context.Cities.Find(Id);
            if (city != null)
            {
                context.Cities.Remove(city);
                context.SaveChanges();
            }
            return city;
        }

        public IEnumerable<City> GetAllCities()
        {
            return context.Cities;
        }

        public City GetCities(int Id)
        {
            return context.Cities.Find(Id);
        }

        public City Update(City cityChanges)
        {
            var city = context.Cities.Attach(cityChanges);
            city.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return cityChanges;
        }
    }
}
