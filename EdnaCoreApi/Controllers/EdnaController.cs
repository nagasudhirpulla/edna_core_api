using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EdnaCoreApi.Controllers
{
    [Route("api/[controller]")]
    public class EdnaController : Controller
    {
        // GET: api/<controller>/5
        [HttpGet("{id}")]
        public IEnumerable<string> Get(int id)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>
        [HttpGet]
        public string Get([BindRequired, FromQuery] string pnt, [BindRequired, FromQuery] string strtime, [BindRequired, FromQuery] string endtime, [BindRequired, FromQuery] string type)
        {
            return "value";
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
