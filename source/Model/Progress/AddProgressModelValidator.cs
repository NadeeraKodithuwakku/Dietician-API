using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model
{
    public class AddProgressModelValidator : ProgressModelValidator
    {
        public AddProgressModelValidator()
        {
            RuleForUserId();
            RuleForDate();
            RuleForWeight();
        }
    }
}
