using EdnaDataLayer.DataStructures;
using InStep.eDNA.EzDNAApiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdnaDataLayer
{
    public class EdnaDataAdapter
    {
        public List<HistoryResult> GetHistData(string pnt, DateTime strtime, DateTime endtime, string type = "snap", int secs = 60)
        {
            // Get history values
            int nret = 0;
            List<HistoryResult> historyResults = new List<HistoryResult>();
            try
            {
                uint s = 0;
                double dval = 0;
                DateTime timestamp = DateTime.Now;
                string status = "";
                TimeSpan period = TimeSpan.FromSeconds(secs);

                // History request initiation
                if (type == "raw")
                { nret = History.DnaGetHistRaw(pnt, strtime, endtime, out s); }
                else if (type == "snap")
                { nret = History.DnaGetHistSnap(pnt, strtime, endtime, period, out s); }
                else if (type == "average")
                { nret = History.DnaGetHistAvg(pnt, strtime, endtime, period, out s); }
                else if (type == "min")
                { nret = History.DnaGetHistMin(pnt, strtime, endtime, period, out s); }
                else if (type == "max")
                { nret = History.DnaGetHistMax(pnt, strtime, endtime, period, out s); }

                while (nret == 0)
                {
                    nret = History.DnaGetNextHist(s, out dval, out timestamp, out status);
                    if (status != null)
                    {
                        historyResults.Add(new HistoryResult { dval = dval, timestamp = timestamp, status = status });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while fetching history results " + ex.Message);
                historyResults = new List<HistoryResult>();
            }
            return historyResults;
        }

        public RealResult GetRealData(string pnt)
        {
            int nret = 0;
            double dval = 0;
            DateTime timestamp = DateTime.Now;
            string status = "";
            string desc = "";
            string units = "";
            RealResult realVal = new RealResult();
            RealResult fallbackRes = new RealResult();
            try
            {
                nret = RealTime.DNAGetRTAll(pnt, out dval, out timestamp, out status, out desc, out units);//get RT value
                if (nret == 0)
                {
                    realVal = new RealResult { dval = dval, timestamp = timestamp, status = status, units = units };
                    return realVal;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while fetching realtime result " + ex.Message);
                return fallbackRes;
            }
            return fallbackRes;
        }
    }
}
