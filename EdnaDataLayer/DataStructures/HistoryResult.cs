using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdnaDataLayer.DataStructures
{
    public class HistoryResult
    {
        public double dval { get; set; }
        public DateTime timestamp { get; set; }
        public string status { get; set; }
    }
}
