using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adso.Models.DbModels
{
    public interface ICityRepository
    {
        City GetCities(int Id);
        IEnumerable<City> GetAllCities();
        City Add(City city);
        City Update(City cityChanges);
        City Delete(int Id);
    }
}
