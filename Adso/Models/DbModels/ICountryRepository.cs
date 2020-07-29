using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adso.Models.DbModels
{
    public interface ICountryRepository
    {
        Country GetCountries(int Id);
        IEnumerable<Country> GetAllCountries();
        Country Add(Country country);
        Country Update(Country countryChanges);
        Country Delete(int Id);
    }
}
