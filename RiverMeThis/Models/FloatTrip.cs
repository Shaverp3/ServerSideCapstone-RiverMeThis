using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RiverMeThis.Models
{
    public class FloatTrip
    {
        [Key]
        public int FloatTripId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public float? Distance { get; set; }
        public int? NumberOfFloaters { get; set; }
        public string Duration { get; set; }
        public string Notes { get; set; }
        public int? Rating { get; set; }
        public string PicPath { get; set; }
        public bool NeedASherpa { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
        public int? RiverId { get; set; }
        public River River { get; set; }
        public int? PutInAPId { get; set; }
        public AccessPoint PutInAP { get; set; }
        public int? TakeOutAPId { get; set; }
        public AccessPoint TakeOutAP { get; set; }
        public int? DeviceId { get; set; }
        public Device Device { get; set; }
        public int? SherpaId { get; set; }
        public Sherpa Sherpa { get; set; }
    }
}
