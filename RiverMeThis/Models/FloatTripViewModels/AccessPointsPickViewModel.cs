using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RiverMeThis.Models.FloatTripViewModels
{
    public class AccessPointsPickViewModel
    {
       
        public FloatTrip floatTrip
        {
            get; set;
        }

        public River river
        {
            get; set;
        }

        public int riverId
        {
            get;set;
        }
        public AccessPoint accessPoint
        {
            get; set;
        }

        public List<SelectListItem> putIns
        {
            get; set;
        } = new List<SelectListItem>();

        
        public List<SelectListItem> takeOuts
        {
            get; set;
        } = new List<SelectListItem>();
    }
}
