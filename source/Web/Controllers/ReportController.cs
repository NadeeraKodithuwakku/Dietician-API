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
        private readonly IReportService _reportService;

        public ReportController(IBmiService bmiService, IReportService reportService)
        {
            _bmiService = bmiService;
            _reportService = reportService;
        }

        [HttpGet("Bmi")]
        public Task<IActionResult> GetUserBmi()
        {
            return _bmiService.GetUserBmi().ResultAsync();
        }

        [HttpGet("Health/{days}")]
        public Task<IActionResult> GetHealthCategories([FromRoute] int days)
        {
            return _reportService.GetHealthCategories(days).ResultAsync();
        }
    }
}
