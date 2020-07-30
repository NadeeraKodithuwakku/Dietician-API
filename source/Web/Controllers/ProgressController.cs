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
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        private readonly IProgressService _progressService;

        public ProgressController(IProgressService progressService)
        {
            _progressService = progressService;
        }
        // GET: api/Profile
        [HttpGet]
        public Task<IActionResult> ListAsync()
        {
            return _progressService.ListAsync().ResultAsync();
        }

        [HttpGet("List")]
        public Task<IActionResult> ListAsync([FromQuery]PagedListParameters parameters)
        {
            return _progressService.ListAsync(parameters).ResultAsync();
        }

        // GET: api/progress/5
        [HttpGet("{id}")]
        public Task<IActionResult> GetAsync(long id)
        {
            return _progressService.GetAsync(id).ResultAsync();
        }

        // POST: api/progress
        [HttpPost]
        public Task<IActionResult> AddAsync(ProgressModel model)
        {
            return _progressService.AddAsync(model).ResultAsync();
        }

        // PUT: api/Profile/5
        [HttpPut("{id}")]
        public Task<IActionResult> UpdateAsync(ProgressModel model)
        {
            return _progressService.UpdateAsync(model).ResultAsync();
        }

        // DELETE: api/progress/5
        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteAsync(long id)
        {
            return _progressService.DeleteAsync(id).ResultAsync();
        }
    }
}
