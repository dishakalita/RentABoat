using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModels
{
    public class BoatModel
    {
        public int BoatId { get; set; }
        public string Name { get; set; }
        public decimal HourlyRate { get; set; }
        public bool IsAvailable { get; set; }
    }
}
