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
        public string PlaceImageURL { get; set; }
        public int CityId { get; set; }
        public City CityName { get; set; }
    }
}
