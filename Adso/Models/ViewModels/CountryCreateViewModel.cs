using Adso.Models.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adso.Models.ViewModels
{
    public class CountryCreateViewModel
    {
        public string CountryName { get; set; }
        public string ShortName { get; set; }
        public string Currency { get; set; }
        public string CallingCode { get; set; }
        public Enumrations? Status { get; set; } = Enumrations.Active;
    }
}
