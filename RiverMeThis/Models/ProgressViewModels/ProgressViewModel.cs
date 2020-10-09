using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RiverMeThis.Models.ProgressViewModels
{
    public class ProgressViewModel
    {
        public ApplicationUser User { get; set; }
        public River River1 { get; set; }
        public float ?DistanceTraveledOnRiver1 { get; set; }
        public River River2 { get; set; }
        public float ?DistanceTraveledOnRiver2 { get; set; }
        public River River3 { get; set; }
        public float ?DistanceTraveledOnRiver3 { get; set; }
        public River River4 { get; set; }
        public float ?DistanceTraveledOnRiver4 { get; set; }
        public River River5 { get; set; }
        public float ?DistanceTraveledOnRiver5 { get; set; }
        public string PercentofRiver1 { get; set; }
        public string PercentofRiver2 { get; set; }
        public string PercentofRiver3 { get; set; }
        public string PercentofRiver4 { get; set; }
        public string PercentofRiver5 { get; set; }

    }
}
