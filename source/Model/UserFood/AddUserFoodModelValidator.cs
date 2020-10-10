using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model.UserFood
{
    public class AddUserFoodModelValidator : UserFoodValidator
    {
        public AddUserFoodModelValidator()
        {
            RuleForFoodId();
            RuleForUserId();
            RuleForDate();
            RuleForRating();
        }
    }
}
