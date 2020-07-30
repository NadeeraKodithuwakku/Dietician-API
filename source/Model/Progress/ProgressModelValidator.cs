using DotNetCore.Validation;
using FluentValidation;

namespace Dietician.Model
{
    public class ProgressModelValidator : Validator<ProgressModel>
    {
        public void RuleForUserId()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }

        public void RuleForDate()
        {
            RuleFor(x => x.Date).NotEmpty();
        }

        public void RuleForWeight()
        {
            RuleFor(x => x.Weight).NotEmpty().GreaterThan(0);
        }
    }
}
