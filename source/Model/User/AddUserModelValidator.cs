namespace Dietician.Model
{
    public sealed class AddUserModelValidator : UserModelValidator
    {
        public AddUserModelValidator()
        {
            RuleForName();
            RuleForSurname();
            RuleForEmail();
            RuleForAuth();
        }
    }
}
