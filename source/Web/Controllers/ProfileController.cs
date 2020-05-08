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
    [Route("Profiles")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        // GET: api/Profile
        [HttpGet]
        public Task<IActionResult> ListAsync()
        {
            return _profileService.ListAsync().ResultAsync();
        }

        [HttpGet("List")]
        public Task<IActionResult> ListAsync([FromQuery]PagedListParameters parameters)
        {
            return _profileService.ListAsync(parameters).ResultAsync();
        }

        // GET: api/Profile/5
        [HttpGet("{id}")]
        public Task<IActionResult> GetAsync(long id)
        {
            return _profileService.GetAsync(id).ResultAsync();
        }

        // POST: api/Profile
        [HttpPost]
        public Task<IActionResult> AddAsync(ProfileModel model)
        {
            return _profileService.AddAsync(model).ResultAsync();
        }

        // PUT: api/Profile/5
        [HttpPut("{id}")]
        public Task<IActionResult> UpdateAsync(ProfileModel model)
        {
            return _profileService.UpdateAsync(model).ResultAsync();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteAsync(long id)
        {
            return _profileService.DeleteAsync(id).ResultAsync();
        }


    }
}
