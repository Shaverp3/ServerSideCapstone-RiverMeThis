using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiverMeThis.Models
{
    public class River
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float TotalLength { get; set; }
        public int NumAPs { get; set; }
        public string MapPath { get; set; }
    }
}
