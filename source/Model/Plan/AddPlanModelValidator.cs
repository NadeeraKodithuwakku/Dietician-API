using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model
{
    public class AddPlanModelValidator : PlanModelValidator
    {
        public AddPlanModelValidator()
        {
            RuleForName();
            RuleForDuration();
            RuleForTarget();
        }
    }
}
