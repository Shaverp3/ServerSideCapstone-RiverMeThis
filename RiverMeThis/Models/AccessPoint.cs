using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiverMeThis.Models
{
    public class AccessPoint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ClassRapids { get; set; }
        public int RiverId { get; set; }
    }
}
