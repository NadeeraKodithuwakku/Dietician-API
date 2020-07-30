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
        public static DietModel CreateDiet(User user, DateTime date, long planId, IEnumerable<Food> foodItems)
        {
            return new DietModel()
            {
                UserId = user.Id,
                Date = date,
                PlanId = planId,
                FoodItems = foodItems.AsQueryable().Select(item => new FoodItemModel()
                {
                    Carbohydrate = item.Carbohydrate,
                    Fat = item.Fat,
                    Id = item.Id,
                    IsVeg = item.IsVeg,
                    Name = item.Name,
                    Protine = item.Protine,
                    Type = DietType.All
                }).ToList()
            };
        }
    }
}
