using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adso.Models
{
    public class City
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CityCode { get; set; }
        public string CityNmae { get; set; }
        public Status? Status { get; set; }
    }
}
