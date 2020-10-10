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
    }
}
