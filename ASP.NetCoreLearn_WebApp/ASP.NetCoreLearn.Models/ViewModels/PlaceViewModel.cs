using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ASP.NetCoreLearn.Models.ViewModels
{
    public class PlaceViewModel
    {
        public Place Place { get; set; }
        public IEnumerable<Place> Places { get; set; } = new List<Place>(); 

        public IEnumerable<SelectListItem> Cities { get; set; }

        
    }
}
