using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RiverMeThis.Models
{
    public class River
    {
        [Key]
        public int RiverId { get; set; }
        public string Name { get; set; }
        public float TotalLength { get; set; }
        public int NumAPs { get; set; }
        public string MapPath { get; set; }
        public List<AccessPoint> AvailableAPs { get; set; } = new List<AccessPoint>();
    }
}
