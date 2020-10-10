using Dietician.Domain.Diet;
using Dietician.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Application
{
    public class UserFoodFactory
    {
        public static UserFoodModel CreateModel(UserFood userFood)
        {
            return new UserFoodModel
            {
                Date = userFood.Date,
                FoodId = userFood.FoodId,
                Id = userFood.Id,
                Rating = userFood.Rating,
                UserId = userFood.UserId
            };
        }

        public static UserFood CreateEntity(UserFoodModel userFood)
        {
            return new UserFood(userFood.UserId, userFood.FoodId, userFood.Rating, userFood.Date)
            {
                CreatedBy = "Admin",
                ModifiedBy = "Admin",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };
        }
    }
}
