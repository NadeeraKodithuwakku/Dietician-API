using Dietician.Domain;
using Dietician.Domain.Diet;
using Dietician.Domain.Enums;
using Dietician.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Application
{
    public static class PlanFactory
    {
        public static Plan CreatePlan(PlanModel plan, User user)
        {
            return new Plan(
                plan.Name,
                (ActivityLevel)plan.ActivityLevel,
                (Goal)plan.Goal,
                plan.Target,
                (Pace)plan.Pace,
                plan.Duration
           )
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                CreatedBy = "Admin",
                ModifiedBy = "Admin",
                UserId = user.Id
            };
        }
    }
}
