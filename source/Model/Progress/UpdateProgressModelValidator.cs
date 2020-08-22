using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model
{
    public class UpdateProgressModelValidator : ProgressModelValidator
    {
        public UpdateProgressModelValidator()
        {
            RuleForId();
            RuleForDate();
            RuleForWeight();
        }
    }
}
