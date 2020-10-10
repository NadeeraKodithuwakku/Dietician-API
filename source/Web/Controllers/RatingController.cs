using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dietician.Application;
using Dietician.Model;
using DotNetCore.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dietician.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IUserFoodService _userFoodService;

        public RatingController(IUserFoodService userFoodService)
        {
            _userFoodService = userFoodService;
        }

        [HttpPost]
        public Task<IActionResult> AddAsync(UserFoodModel model)
        {
            return _userFoodService.AddAsync(model).ResultAsync();
        }

        [HttpGet]
        public Task<IActionResult> ListAsync()
        {
            return _userFoodService.ListAsync().ResultAsync();
        }
    }
}
