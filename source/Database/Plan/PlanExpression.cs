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
            ActivityLevel = (int)plan.ActivityLevel,
            Goal = (int)plan.Goal,
            Target = plan.Target,
            Pace = (int)plan.Pace,
            Duration = plan.Duration,
            Status = (int)plan.Status,
            Name = plan.Name,
            UserId = plan.UserId
        };

        public static Expression<Func<Plan, bool>> UserId(long id)
        {
            return plan => plan.UserId == id;
        }

        public static Expression<Func<Plan, bool>> Id(long id)
        {
            return plan => plan.Id == id;
        }
    }
}
