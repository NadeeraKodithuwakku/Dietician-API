using Dietician.Database;
using Dietician.Domain.Diet;
using Dietician.Domain.Enums;
using Dietician.Model;
using Dietician.Model.Food;
using DotNetCore.Objects;
using DotNetCore.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Dietician.Application
{
    public class DietService : IDietService
    {
        private readonly IFoodRepository foodRepository;
        private readonly IPlanRepository planRepository;
        private readonly IProfileRepository profileRepository;

        public bool isExerciseRequired;//TODO: to be removed if no need
        public double calorieBalance;//TODO: to be returned to the UI

        public DietService(
            IFoodRepository foodRepository,
            IPlanRepository planRepository,
            IProfileRepository profileRepository)
        {
            this.foodRepository = foodRepository;
            this.planRepository = planRepository;
            this.profileRepository = profileRepository;
        }

        public async Task<DietModel> GetDietAsyc(DietParams @params)
        {
            var validation = await new DietParamValidator().ValidateAsync(@params);
            if (validation.Failed)
            {
                throw new ArgumentException(validation.Message);
            }

            var profile = await profileRepository.GetByUserIdAync(@params.UserId);
            var plan = await planRepository.GetAsync(@params.PlanId);
            var foods = await foodRepository.ListAsync();

            var bmrValue = GetBMRValue((double)profile.Weight, (double)profile.Height, profile.Age, (Gender)profile.Gender);
            var levelFactor = GetActivityLevelValue(plan.ActivityLevel);
            var totalEnergyExpenditure = bmrValue * levelFactor;
            var calorieIntakePerDay = totalEnergyExpenditure;

            if (plan.Goal == Goal.Change_Weight)
            {
                double requiredCalorieChangePerDay = GetTargetGainOrLossCaloriePerDay((int)plan.Pace, (double)plan.Target, (double)profile.Weight, plan.Duration);
                calorieIntakePerDay = GetCalorieIntakePerDay((double)plan.Target, (double)profile.Weight, requiredCalorieChangePerDay, totalEnergyExpenditure);
            }
            var foodList = GetFoodList(calorieIntakePerDay, DietFactory.ConvertToFoodModel(foods), profile.IsVeg);

            ShowDietOutput(foodList);//Testing Purpose Only

            return DietFactory.CreateDiet(@params.UserId, @params.Date, plan.Id, foodList);
        }

        #region Helper Methods
        private double GetBMRValue(double currentWeight, double height, int age, Gender gender)
        {
            double bmr = (10 * currentWeight) + (6.25 * height) - (5 * age);
            bmr = gender == 0 ? bmr + 5 : bmr - 161;
            return bmr;
        }

        private double GetTargetGainOrLossCaloriePerDay(int pace, double targetWeight, double currentWeight, int targetPeriod)
        {
            double requiredCalorieChangePerDay;
            if (pace == 0)
            {
                requiredCalorieChangePerDay = 500;
            }
            else if (pace == 1)
            {
                requiredCalorieChangePerDay = 1000;
            }
            else
            {
                //if user enter duration manually
                double weightGap = Math.Abs(currentWeight - targetWeight);
                double requiredWeightChangePerDay;
                if (targetPeriod >= (weightGap * 2))//targetPeriod is taking as weeks
                {
                    if (targetPeriod == (weightGap * 2))
                    {
                        requiredCalorieChangePerDay = 500;
                        isExerciseRequired = false;
                    }
                    else
                    {
                        requiredWeightChangePerDay = weightGap / (targetPeriod * 7);
                        requiredCalorieChangePerDay = requiredWeightChangePerDay * (3500 / 0.45);
                        isExerciseRequired = false;
                    }
                }
                else if (targetPeriod > weightGap)
                {
                    if (targetPeriod == weightGap)
                    {
                        requiredCalorieChangePerDay = 1000;
                        isExerciseRequired = false;
                    }
                    else
                    {
                        requiredWeightChangePerDay = weightGap / (targetPeriod * 7);
                        requiredCalorieChangePerDay = requiredWeightChangePerDay * (3500 / 0.45);
                        isExerciseRequired = false;
                    }
                }
                else
                {
                    requiredWeightChangePerDay = weightGap / (targetPeriod * 7);
                    requiredCalorieChangePerDay = requiredWeightChangePerDay * (3500 / 0.45);
                    isExerciseRequired = true;
                }
            }
            return requiredCalorieChangePerDay;
        }

        private double GetCalorieIntakePerDay(double targetWeight, double currentWeight, double requiredCalorieChangePerDay, double totalEnergyExpenditure)
        {
            double calorieIntakePerDay = 0.0;
            var defaultCalorieChangePerDay = 1000;// maximum calorie reduction per day
            var defaultCalorieIntakePerDay = 1200;// maximum calorie intake per day

            if (targetWeight > currentWeight)
            {
                // calorie intake to weight gain
                calorieIntakePerDay = totalEnergyExpenditure + requiredCalorieChangePerDay;
            }
            else
            {
                //calorie intake to weight loss
                if (totalEnergyExpenditure > requiredCalorieChangePerDay)
                {
                    calorieIntakePerDay = totalEnergyExpenditure - requiredCalorieChangePerDay;
                }
                else
                {
                    if (totalEnergyExpenditure > defaultCalorieChangePerDay)
                    {
                        calorieIntakePerDay = totalEnergyExpenditure - defaultCalorieChangePerDay;
                        calorieBalance = requiredCalorieChangePerDay - defaultCalorieChangePerDay;
                    }
                }
                if (calorieIntakePerDay < defaultCalorieIntakePerDay)
                {
                    calorieIntakePerDay = totalEnergyExpenditure;
                    calorieBalance = requiredCalorieChangePerDay;
                }
            }
            return calorieIntakePerDay;
        }

        private double GetActivityLevelValue(ActivityLevel level)
        {
            var value = 0.0;
            switch (level)
            {
                case ActivityLevel.Sedentary:
                    value = 1.2;
                    break;
                case ActivityLevel.Slightly_Active:
                    value = 1.4;
                    break;
                case ActivityLevel.Moderately_Active:
                    value = 1.6;
                    break;
                case ActivityLevel.Very_Active:
                    value = 1.75;
                    break;
                case ActivityLevel.Extra_Active:
                    value = 2;
                    break;
                case ActivityLevel.Professional_Athlete:
                    value = 2.3;
                    break;
                default:
                    break;
            }

            return value;
        }

        private IEnumerable<FoodItemModel> GetFoodList(double calorieIntakePerDay, IEnumerable<FoodItemModel> fullList, bool isVeg)
        {
            var foodList = new List<FoodItemModel>();
            var vegList = new List<FoodItemModel>();
            if (isVeg)
            {
                vegList = fullList.Where(f => f.IsVeg).ToList();
                foodList = (List<FoodItemModel>)GenerateFoodList(calorieIntakePerDay, vegList);
            }
            else
            {
                foodList = (List<FoodItemModel>)GenerateFoodList(calorieIntakePerDay, (List<FoodItemModel>)fullList);
            }
            return foodList;
        }

        private IEnumerable<FoodItemModel> GenerateFoodList(double calorieIntakePerDay, List<FoodItemModel> foods)
        {
            var foodList = new List<FoodItemModel>();
            var bFCal = calorieIntakePerDay * 0.325;
            var lCal = calorieIntakePerDay * 0.375;
            var dCal = calorieIntakePerDay * 0.3;

            foreach (var food in foods)
            {
                var foodCalorie = GetFoodCalorieAmount(food);
                if (bFCal > 0 && bFCal > foodCalorie && !foodList.Exists(x => x.FoodCategory == food.FoodCategory && x.Type == DietType.Breakfast))//TODO: handle white and red rice
                {
                    food.Type = DietType.Breakfast;
                    foodList.Add(food);
                    bFCal -= foodCalorie;
                }
                if (lCal > 0 && lCal > foodCalorie && !foodList.Exists(x => x.Name == food.Name))
                {
                    food.Type = DietType.Lunch;
                    foodList.Add(food);
                    lCal -= foodCalorie;
                }
                if (dCal > 0 && dCal > foodCalorie && !foodList.Exists(x => x.Name == food.Name))
                {
                    food.Type = DietType.Dinner;
                    foodList.Add(food);
                    dCal -= foodCalorie;
                }
            }

            return foodList;
        }

        private double GetFoodCalorieAmount(FoodItemModel foodItem)
        {
            var foodCalorie = (foodItem.Fat * 9) + (foodItem.Protine * 4) + (foodItem.Carbohydrate * 4);

            return foodCalorie;
        }

        private void ShowDietOutput(IEnumerable<FoodItemModel> foodList)
        {
            Console.WriteLine("--------------BreakFirst--------------");
            foreach (var item in foodList.Where(f => f.Type == DietType.Breakfast).Select(f => f.Name).ToList())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------Lunch--------------");
            foreach (var item in foodList.Where(f => f.Type == DietType.Lunch).Select(f => f.Name).ToList())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------Dinner--------------");
            foreach (var item in foodList.Where(f => f.Type == DietType.Dinner).Select(f => f.Name).ToList())
            {
                Console.WriteLine(item);
            }
        }

        #endregion Helper Methods
    }
}
