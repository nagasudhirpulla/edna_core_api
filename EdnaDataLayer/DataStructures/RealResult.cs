using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdnaDataLayer.DataStructures
{
    public class RealResult
    {
        public double dval { get; set; } = double.NaN;
        public DateTime timestamp { get; set; }
        public string status { get; set; }
        public string desc { get; set; }
        public string units { get; set; }
    }
}
