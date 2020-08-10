using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dietician.Application;
using Dietician.Model;
using DotNetCore.AspNetCore;
using DotNetCore.Objects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dietician.Web.Controllers
{

    [Route("Plans")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IPlanService _planService;

        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }
        // GET: api/Profile
        [HttpGet]
        public Task<IActionResult> ListAsync()
        {
            return _planService.ListAsync().ResultAsync();
        }

        [HttpGet("List")]
        public Task<IActionResult> ListAsync([FromQuery] PagedListParameters parameters)
        {
            return _planService.ListAsync(parameters).ResultAsync();
        }

        [HttpGet("User/{id}")]
        public Task<IActionResult> ListByUserIdAsync([FromQuery] PagedListParameters parameters, [FromRoute] long id)
        {
            return _planService.ListByUserIdAsync(parameters, id).ResultAsync();
        }

        // GET: api/Profile/5
        [HttpGet("{id}")]
        public Task<IActionResult> GetAsync(long id)
        {
            return _planService.GetAsync(id).ResultAsync();
        }

        // POST: api/Profile
        [HttpPost]
        public Task<IActionResult> AddAsync(PlanModel model)
        {
            return _planService.AddAsync(model).ResultAsync();
        }

        // PUT: api/Profile/5
        [HttpPut("{id}")]
        public Task<IActionResult> UpdateAsync(PlanModel model)
        {
            return _planService.UpdateAsync(model).ResultAsync();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteAsync(long id)
        {
            return _planService.DeleteAsync(id).ResultAsync();
        }


    }
}
