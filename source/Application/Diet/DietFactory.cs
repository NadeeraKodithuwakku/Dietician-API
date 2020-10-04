using Dietician.Domain;
using Dietician.Domain.Diet;
using Dietician.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Application
{
    public static class DietFactory
    {
        public static DietModel CreateDiet(long userId, DateTime date, double extraCalorie, string message, IEnumerable<FoodItemModel> foodItems)
        {
            return new DietModel()
            {
                UserId = userId,
                Date = date,
                ExtraCalorieAmount = extraCalorie,
                Message = message,
                IsError = !string.IsNullOrEmpty(message),
                FoodItems = foodItems.ToList()
            };
        }

        public static IEnumerable<FoodItemModel> ConvertToFoodModel(IEnumerable<Food> foodItems)
        {
            return foodItems.Select(item => new FoodItemModel()
            {
                Carbohydrate = item.Carbohydrate,
                Fat = item.Fat,
                Id = item.Id,
                IsVeg = item.IsVeg,
                Name = item.Name,
                Protine = item.Protine,
                FoodCategory = (int)item.FoodCategory,
                FoodQuantity = 100
            });
        }
    }
}
