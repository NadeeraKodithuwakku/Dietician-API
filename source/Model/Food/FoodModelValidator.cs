using DotNetCore.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model
{
    public class FoodModelValidator : Validator<FoodModel>
    {
        public void RuleForId()
        {
            RuleFor(f => f.Id).NotEmpty();
        }

        public void RuleForName()
        {
            RuleFor(f => f.Name).NotEmpty();
        }

        public void RuleForFat()
        {
            RuleFor(f => f.Fat).NotNull();
        }

        public void RuleForCarbohydrate()
        {
            RuleFor(f => f.Carbohydrate).NotNull();
        }

        public void RuleForProtine()
        {
            RuleFor(f => f.Protine).NotNull();
        }

        public void RuleForIsVeg()
        {
            RuleFor(f => f.IsVeg).NotNull();
        }
    }
}
