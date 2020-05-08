using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model
{
    public class UpdateProfileModelValidator : ProfileModelValidator
    {
        public UpdateProfileModelValidator()
        {
            RuleForUserId();
            RuleForId();
            RuleForHeight();
            RuleForWeight();
        }
    }
}
