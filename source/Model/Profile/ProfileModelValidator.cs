using DotNetCore.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model
{
    public abstract class ProfileModelValidator : Validator<ProfileModel>
    {

        public void RuleForWeight()
        {
            RuleFor(x => x.Weight).GreaterThan(0);
        }

        public void RuleForHeight()
        {
            RuleFor(x => x.Height).GreaterThan(0);
        }

        public void RuleForId()
        {
            RuleFor(x => x.Id).NotEmpty();
        }

        public void RuleForUserId()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
