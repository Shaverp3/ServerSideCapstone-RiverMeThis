using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiverMeThis.Models.FloatTripViewModels
{
    public class FloatTripCreateViewModel
    {
        public FloatTrip floatTrip
        { 
            get; set; 
        }
       
        public List<SelectListItem> rivers
        {
            get; set;
        } = new List<SelectListItem>();

        public List<SelectListItem> devices
        {
            get; set;
        } = new List<SelectListItem>();
    }
}
