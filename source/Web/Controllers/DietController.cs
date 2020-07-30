using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dietician.Model;
namespace Dietician.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietController : ControllerBase
    {
        [HttpGet]
        public Task<IActionResult> ListAsync([FromQuery]DietParams parameters)
        {
            return null;
        }
    }
}
