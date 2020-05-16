using Dietician.Domain;
using Dietician.Domain.Diet;
using Dietician.Model;
using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietician.Database
{
    public sealed class PlanRepository : EFRepository<Plan>, IPlanRepository
    {
        public PlanRepository(Context context) : base(context)
        {
        }

        public Task<PlanModel> GetByIdAsync(long id)
        {
            return Queryable.Where(PlanExpression.Id(id)).Select(PlanExpression.Model).SingleOrDefaultAsync();
        }

        public Task UpdateStatusAsync(Plan plan)
        {
            return UpdatePartialAsync(plan.Id, new { plan.Status, plan.StartDate, plan.DateModified });
        }
    }
}
