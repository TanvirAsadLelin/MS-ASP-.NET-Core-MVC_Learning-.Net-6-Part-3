using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NetCoreLearn.Models
{
    public class Place
    {   
        public int PlaceId { get; set; }
        [Required]
        public string PlaceName { get; set; }
        [Required]
        public string PlaceDescription { get; set; }
        [Required]
        public double PlaceVisitRate { get; set; }

        [ValidateNever]
        public string PlaceImageURL { get; set; }
        public int CityId { get; set; }
        [ValidateNever]
        public City CityName { get; set; }
    }
}
