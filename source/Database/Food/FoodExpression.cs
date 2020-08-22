using Dietician.Domain.Diet;
using Dietician.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Dietician.Database
{
    public static class FoodExpression
    {
        public static Expression<Func<Food, FoodModel>> Model => food => new FoodModel
        {
            Id = food.Id,
            Name = food.Name,
            Protine = food.Protine,
            Fat = food.Fat,
            Carbohydrate = food.Carbohydrate,
            IsVeg = food.IsVeg,
            FoodCategory = (int)food.FoodCategory

        };

        public static Expression<Func<Food, bool>> Id(long id)
        {
            return food => food.Id == id;
        }
    }
}
