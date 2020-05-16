using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model.Food
{
    public class UpdateFoodModelValidator : FoodModelValidator
    {
        public UpdateFoodModelValidator()
        {
            RuleForId();
            RuleForName();
            RuleForCarbohydrate();
            RuleForFat();
            RuleForProtine();
            RuleForIsVeg();
        }
    }
}
