using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using InStep.eDNA.EzDNAApiNet;
using System.Globalization;
using EdnaDataLayer.DataStructures;
using EdnaDataLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EdnaCoreApi.Controllers
{
    [Route("api/[controller]")]
    public class EdnaController : Controller
    {
        // GET api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/<controller>/history
        [HttpGet("history")]
        public List<HistoryResult> GetHistoryData([BindRequired, FromQuery] string pnt, [BindRequired, FromQuery] string strtime, [BindRequired, FromQuery] string endtime, [FromQuery] string type = "snap", [FromQuery] int secs = 60)
        {
            EdnaDataAdapter adapter = new EdnaDataAdapter();
            // Get history values
            string format = "dd/MM/yyyy/HH:mm:ss";
            List<HistoryResult> historyResults;
            try
            {
                DateTime startTime = DateTime.ParseExact(strtime, format, CultureInfo.InvariantCulture);
                DateTime endTime = DateTime.ParseExact(endtime, format, CultureInfo.InvariantCulture);
                historyResults = adapter.GetHistData(pnt, startTime, endTime, type, secs);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while fetching history results " + ex.Message);
                historyResults = new List<HistoryResult>();
            }

            return historyResults;
        }

        // GET: api/<controller>/real
        [HttpGet("real")]
        public RealResult GetRealTimeData([BindRequired, FromQuery] string pnt)
        {
            // Get real time value
            EdnaDataAdapter adapter = new EdnaDataAdapter();
            RealResult realResult = adapter.GetRealData(pnt);
            return realResult;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
