using Dietician.Domain.Diet;
using Dietician.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Application
{
    public static class FoodFactory
    {
        public static Food CreateFood(FoodModel model)
        {
            return new Food(model.Name, model.Fat, model.Protine, model.Carbohydrate, model.IsVeg, (Domain.Enums.FoodCategory)model.FoodCategory);
        }

        public static FoodModel CreateFood(Food food)
        {
            return new FoodModel
            {
                Id = food.Id,
                Name = food.Name,
                Protine = food.Protine,
                Carbohydrate = food.Carbohydrate,
                Fat = food.Fat,
                FoodCategory = (int)food.FoodCategory,
                IsVeg = food.IsVeg
            };
        }
    }
}
