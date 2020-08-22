using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model
{
    public class AddProfileModelValidator : ProfileModelValidator
    {
        public AddProfileModelValidator()
        {
            RuleForUserId();
            RuleForHeight();
            RuleForWeight();
        }
    }
}
