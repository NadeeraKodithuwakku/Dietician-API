using Dietician.Domain.Diet;
using Dietician.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Dietician.Database
{
    public static class PlanExpression
    {
        public static Expression<Func<Plan, PlanModel>> Model => plan => new PlanModel
        {
            Id = plan.Id,
            Duration = plan.Duration,
            Status = (int)plan.Status,
            Target = plan.Target,
            Name = plan.Name
        };

        public static Expression<Func<Plan, bool>> Id(long id)
        {
            return plan => plan.Id == id;
        }
    }
}
