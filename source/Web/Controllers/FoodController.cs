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

    [Route("Foods")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }
        // GET: api/foods
        [HttpGet]
        public Task<IActionResult> ListAsync()
        {
            return _foodService.ListAsync().ResultAsync();
        }

        [HttpGet("List")]
        public Task<IActionResult> ListAsync([FromQuery] PagedListParameters parameters)
        {
            return _foodService.ListAsync(parameters).ResultAsync();
        }

        // GET: api/foods/5
        [HttpGet("{id}")]
        public Task<IActionResult> GetAsync(long id)
        {
            return _foodService.GetAsync(id).ResultAsync();
        }

        // POST: api/foods
        [HttpPost]
        public Task<IActionResult> AddAsync(FoodModel model)
        {
            return _foodService.AddAsync(model).ResultAsync();
        }

        // PUT: api/foods/5
        [HttpPut("{id}")]
        public Task<IActionResult> UpdateAsync(FoodModel model)
        {
            return _foodService.UpdateAsync(model).ResultAsync();
        }

        // DELETE: api/foods/5
        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteAsync(long id)
        {
            return _foodService.DeleteAsync(id).ResultAsync();
        }


    }
}
