using Adso.Models.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adso.Models.DbModels
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                    new Country
                    {
                        Id = 1,
                        CountryName = "Africa",
                        CallingCode = "+54",
                        ShortName = "Afr",
                        Currency = "Rs",
                        Status = Enumrations.Active
                    }
                );
            modelBuilder.Entity<City>().HasData(
                    new City
                    {
                        Id = 1,
                        CountryId = 1,
                        
                        CityName = "Lahore",
                        CityCode = "LHR",
                        Status = Enumrations.Active
                    }
                );
        }
    }
}
