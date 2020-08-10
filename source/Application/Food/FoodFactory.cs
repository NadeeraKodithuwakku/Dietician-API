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
    }
}
