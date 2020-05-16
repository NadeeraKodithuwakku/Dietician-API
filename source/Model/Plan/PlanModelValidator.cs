using DotNetCore.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model
{
    public class PlanModelValidator : Validator<PlanModel>
    {
        public void RuleForId()
        {
            RuleFor(x => x.Id).NotEmpty();
        }

        public void RuleForName()
        {
            RuleFor(x => x.Name).NotEmpty();
        }

        public void RuleForDuration()
        {
            RuleFor(x => x.Duration).GreaterThan(0);
        }

        public void RuleForTarget()
        {
            RuleFor(x => x.Target).GreaterThan(0);
        }
    }
}
