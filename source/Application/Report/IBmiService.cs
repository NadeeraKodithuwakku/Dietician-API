using Dietician.Model.Report;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dietician.Application.Report
{
    public interface IBmiService
    {
        Task<IEnumerable<BmiModel>> GetUserBmi();
    }
}
