using DotNetCore.Validation;
using FluentValidation;

namespace Dietician.Model
{
    public class DietParamValidator : Validator<DietParams>
    {

        public DietParamValidator()
        {
            RuleForUserId();
            RuleForDate();

        }

        public void RuleForUserId()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }

        public void RuleForDate()
        {
            RuleFor(x => x.Date).NotEmpty();
        }

        public void RuleForType()
        {
            RuleFor(x => x.Type).NotEmpty();
        }
    }
}
