using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
namespace NadeeraKodithuwakku.Dietician.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
         // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            MyCircuitBreakerCommand cb = new MyCircuitBreakerCommand("PlanMyDiet");
            cb.IsFallbackUserDefined = true;
            string a = await cb.ExecuteAsync();
            return new string[] { a };
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
