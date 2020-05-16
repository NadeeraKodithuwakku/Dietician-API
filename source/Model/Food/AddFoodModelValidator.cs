using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model
{
    public class AddFoodModelValidator : FoodModelValidator
    {
        public AddFoodModelValidator()
        {
            RuleForName();
            RuleForCarbohydrate();
            RuleForFat();
            RuleForProtine();
            RuleForIsVeg();
        }
    }
}
