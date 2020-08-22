using DotNetCore.Validation;
using FluentValidation;

namespace Dietician.Model
{
    public abstract class UserModelValidator : Validator<UserModel>
    {
        public void RuleForAuth()
        {
            RuleFor(x => x.Auth).SetValidator(new AuthModelValidator());
        }

        public void RuleForEmail()
        {
            RuleFor(x => x.Email).NotEmpty();
        }

        public void RuleForId()
        {
            RuleFor(x => x.Id).NotEmpty();
        }

        public void RuleForName()
        {
            RuleFor(x => x.Name).NotEmpty();
        }

        public void RuleForSurname()
        {
            RuleFor(x => x.Surname).NotEmpty();
        }
    }
}
