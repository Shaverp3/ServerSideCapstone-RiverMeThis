using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RiverMeThis.Models
{
    public class Sherpa
    {
        [Key]
        public int SherpaId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PicPath { get; set; }
        //public int RiverId { get; set; }
        //public River River { get; set; }

        public List<FloatTrip> AssignedFloats { get; set; } = new List<FloatTrip>();

    }
}
