using Dietician.Domain.Diet;
using Dietician.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Application
{
    public static class PlanFactory
    {
        public static Plan CreatePlan(PlanModel plan)
        {
            return new Plan(
                plan.Target,
                plan.Name,
                plan.Duration
           )
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                CreatedBy = "Admin",
                ModifiedBy = "Admin"
            };
        }
    }
}
