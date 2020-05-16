using Dietician.Model;
using DotNetCore.Objects;
using DotNetCore.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dietician.Application
{
    public interface IPlanService
    {
        Task<IResult<long>> AddAsync(PlanModel model);

        Task<IResult> DeleteAsync(long id);

        Task<PlanModel> GetAsync(long id);

        Task<PagedList<PlanModel>> ListAsync(PagedListParameters parameters);

        Task<IEnumerable<PlanModel>> ListAsync();

        Task<IResult> UpdateAsync(PlanModel model);
    }
}
