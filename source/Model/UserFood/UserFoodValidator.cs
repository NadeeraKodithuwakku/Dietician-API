using DotNetCore.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dietician.Model
{
    public class UserFoodValidator : Validator<UserFoodModel>
    {

        public void RuleForFoodId()
        {
            RuleFor(x => x.FoodId).GreaterThan(0);
        }

        public void RuleForUserId()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
        }

        public void RuleForRating()
        {
            RuleFor(x => x.Rating).NotEqual(0);
        }

        public void RuleForDate()
        {
            RuleFor(x => x.Date).NotEmpty();
        }
    }
}
