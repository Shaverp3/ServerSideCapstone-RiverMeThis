using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiverMeThis.Models
{
    public class Floats
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public float Distance { get; set; }
        public string Duration { get; set; }
        public string Notes { get; set; }
        public int Rating { get; set; }
        public string PicPath { get; set; }
        public bool NeedASherpa { get; set; }
        public int UserId { get; set; }
        public int RiverId { get; set; }
        public int PutInAPId { get; set; }
        public int TakeOutAPId { get; set; }
        public int DeviceId { get; set; }

    }
}
