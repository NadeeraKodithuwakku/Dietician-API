using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model
{
    public class UpdatePlanModelValidator : PlanModelValidator
    {
        public UpdatePlanModelValidator()
        {
            RuleForId();
            RuleForName();
            RuleForDuration();
            RuleForTarget();
        }
    }
}
