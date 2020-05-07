using DotNetCore.Validation;
using FluentValidation;

namespace Dietician.Model
{
    public sealed class SignInModelValidator : Validator<SignInModel>
    {
        public SignInModelValidator()
        {
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
