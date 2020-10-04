using Dietician.Application.Report;
using DotNetCore.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dietician.Web.Controllers
{
    [Route("Report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IBmiService _bmiService;

        public ReportController(IBmiService bmiService)
        {
            _bmiService = bmiService;
        }

        [HttpGet]
        public Task<IActionResult> ListAsync()
        {
            return _bmiService.GetUserBmi().ResultAsync();
        }
    }
}
