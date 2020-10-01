using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RiverMeThis.Models
{
    public class Device
    {
        [Key]
        public int DeviceId { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
