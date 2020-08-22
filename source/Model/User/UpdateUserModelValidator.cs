namespace Dietician.Model
{
    public sealed class UpdateUserModelValidator : UserModelValidator
    {
        public UpdateUserModelValidator()
        {
            RuleForId();
            RuleForName();
            RuleForSurname();
            RuleForEmail();
        }
    }
}
