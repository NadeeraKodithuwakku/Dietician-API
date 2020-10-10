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

        [HttpGet("Health/{days}/{date}")]
        public Task<IActionResult> GetHealthCategories([FromRoute] int days, [FromRoute] DateTime date)
        {
            return _reportService.GetHealthCategories(days, date).ResultAsync();
        }

        [HttpGet("TopGainers/{date}/{count}")]
        public Task<IActionResult> GetTopGainers([FromRoute] DateTime date, [FromRoute] int count)
        {
            return _reportService.GetTopGainers(date, count).ResultAsync();
        }

        [HttpGet("TopLoosers/{date}/{count}")]
        public Task<IActionResult> GetTopLoosers([FromRoute] DateTime date, [FromRoute] int count)
        {
            return _reportService.GetTopLoosers(date, count).ResultAsync();
        }
    }
}
