using Dietician.Model.Report;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dietician.Application.Report
{
    public interface IReportService
    {
        Task<IEnumerable<HealthCategoryDetailModel>> GetHealthCategories(int days);
        Task<IEnumerable<TopGainLossModel>> GetTopGainers(DateTime date, int count);
        Task<IEnumerable<TopGainLossModel>> GetTopLoosers(DateTime date, int count);
    }
}
