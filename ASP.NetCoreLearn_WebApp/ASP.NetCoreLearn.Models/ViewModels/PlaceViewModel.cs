using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NetCoreLearn.Models.ViewModels
{
    public class PlaceViewModel
    {
        public IEnumerable<Place> Places { get; set; }
    }
}
