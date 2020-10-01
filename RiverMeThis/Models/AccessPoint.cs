using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RiverMeThis.Models
{
    public class AccessPoint
    {
        [Key]
        public int AccessPointId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int APIndex { get; set; }
        public string ClassRapids { get; set; }
        public int RiverId { get; set; }
        public River River { get; set; }
    }
}
