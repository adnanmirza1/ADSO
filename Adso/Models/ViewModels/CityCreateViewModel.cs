using Adso.Models.ApplicationModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Adso.Models.ViewModels
{
    public class CityCreateViewModel
    {
        public int Id { get; set; }
        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public Enumrations? Status { get; set; } = Enumrations.Active;
    }
}
