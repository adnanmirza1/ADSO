using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adso.Models.DbModels
{
    public class SQLCountryRepository : ICountryRepository
    {
        private readonly AdsoDbContext context;

        public SQLCountryRepository(AdsoDbContext context)
        {
            this.context = context;
        }

        public Country Add(Country country)
        {
            context.Countries.Add(country);
            context.SaveChanges();
            return country;
        }

        public Country Delete(int Id)
        {
            Country country = context.Countries.Find(Id);
            if (country != null)
            {
                context.Countries.Remove(country);
                context.SaveChanges();
            }
            return country;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return context.Countries;
        }

        public Country GetCountries(int Id)
        {
            return context.Countries.Find(Id);
        }

        public Country Update(Country countryChanges)
        {
            var country = context.Countries.Attach(countryChanges);
            country.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return countryChanges;
        }
    }
}
