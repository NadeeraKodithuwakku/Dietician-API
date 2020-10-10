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
        private readonly IProfileRepository profileRepository;

        public double calorieBalance = 0.0;
        public string message = string.Empty;

        public DietService(
            IFoodRepository foodRepository,
            IProfileRepository profileRepository)
        {
            this.foodRepository = foodRepository;
            this.profileRepository = profileRepository;
        }

        public async Task<DietModel> GetDietAsyc(DietParams @params)
        {
            var validation = await new DietParamValidator().ValidateAsync(@params);
            if (validation.Failed)
            {
                throw new ArgumentException(validation.Message);
            }

            var profile = await profileRepository.GetByUserIdAsync(@params.UserId);
            var foods = await foodRepository.ListAsync();

            var bmrValue = GetBMRValue((double)profile.Weight, (double)profile.Height, profile.Age, (Gender)profile.Gender);
            var levelFactor = GetActivityLevelValue((ActivityLevel)profile.ActivityLevel);
            var totalEnergyExpenditure = bmrValue * levelFactor;
            var calorieIntakePerDay = totalEnergyExpenditure;

            if ((Goal)profile.Goal == Goal.Change_Weight)
            {
                double requiredCalorieChangePerDay = GetTargetGainOrLossCaloriePerDay(profile.Pace, (double)profile.TargetWeight, (double)profile.Weight, 0);
                calorieIntakePerDay = GetCalorieIntakePerDay((double)profile.TargetWeight, (double)profile.Weight, requiredCalorieChangePerDay, totalEnergyExpenditure);
            }
            var foodList = GetFoodList(calorieIntakePerDay, DietFactory.ConvertToFoodModel(foods), profile.IsVeg);

            ShowDietOutput(foodList);//Testing Purpose Only

            return DietFactory.CreateDiet(@params.UserId, @params.Date, calorieBalance, message, foodList);
        }

        #region Helper Methods
        private double GetBMRValue(double currentWeight, double height, int age, Gender gender)
        {
            //based on Mifflin-St Jeor Equation
            double bmr = (10 * currentWeight) + (6.25 * height) - (5 * age);
            bmr = gender == 0 ? bmr + 5 : bmr - 161;
            return bmr;
        }

        private double GetTargetGainOrLossCaloriePerDay(int pace, double targetWeight, double currentWeight, int targetPeriod)
        {
            double requiredCalorieChangePerDay;
            if (pace == 0)
            {
                requiredCalorieChangePerDay = 250; // 0.25kg per week ~ 1750Kcal, 250Kcal per week
            }
            else if (pace == 1)
            {
                requiredCalorieChangePerDay = 500; //0.5kg per week ~ 3500Kcal , 500Kcal per day
            }
            else if (pace == 2)
            {
                requiredCalorieChangePerDay = 750; //0.75kg per week ~ 5250Kcal,  750Kcal per week
            }
            else if (pace == 3)
            {
                requiredCalorieChangePerDay = 1000; //1kg per week ~ 7000Kcal, 1000Kcal per day
            }
            else
            {
                //if user enter duration manually
                double weightGap = Math.Abs(currentWeight - targetWeight);
                double requiredWeightChangePerDay;
                if (targetPeriod == (weightGap * 4))//targetPeriod is taking as weeks
                {
                    requiredCalorieChangePerDay = 250;
                }
                else if (targetPeriod == (weightGap * 2))
                {
                    requiredCalorieChangePerDay = 500;
                }
                else if (targetPeriod == (weightGap * 1.3))
                {
                    requiredCalorieChangePerDay = 750;
                }
                else if (targetPeriod == weightGap)
                {
                    requiredCalorieChangePerDay = 1000;
                }
                else
                {
                    requiredWeightChangePerDay = weightGap / (targetPeriod * 7);
                    requiredCalorieChangePerDay = requiredWeightChangePerDay * 7716.179;//1kg = 7716.179 calorie
                }
            }
            return requiredCalorieChangePerDay;
        }

        private double GetCalorieIntakePerDay(double targetWeight, double currentWeight, double requiredCalorieChangePerDay, double totalEnergyExpenditure)
        {
            double calorieIntakePerDay = 0.0;
            var defaultCalorieChangePerDay = 1000;// recommended minimum calorie reduction per day
            var defaultCalorieIntakePerDay = 1200;// recommended maximum calorie intake per day

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
                        message = "You can't achieve target by given duration without doing exercise, please do exercise to burn extra calories";
                    }
                }
                if (calorieIntakePerDay < defaultCalorieIntakePerDay)
                {
                    calorieIntakePerDay = defaultCalorieIntakePerDay;
                    calorieBalance = requiredCalorieChangePerDay - (totalEnergyExpenditure - calorieIntakePerDay);
                    message = "You can't achieve target by given duration without doing exercise, please do exercise to burn extra calories";
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
                foodList = GenerateFoodList(calorieIntakePerDay, vegList).ToList();
            }
            else
            {
                foodList = GenerateFoodList(calorieIntakePerDay, fullList).ToList();
            }
            return foodList;
        }

        private IEnumerable<FoodItemModel> GenerateFoodList(double calorieIntakePerDay, IEnumerable<FoodItemModel> foods)
        {
            var foodList = new List<FoodItemModel>();
            var bFCal = calorieIntakePerDay * 0.325;
            var tempBfCal = bFCal;
            var lCal = calorieIntakePerDay * 0.375;
            var tempLcal = lCal;
            var dCal = calorieIntakePerDay * 0.3;
            var tempDcal = dCal;
            var bFFoodCalSum = 0.0;
            var lFoodCalSum = 0.0;
            var dFoodCalSum = 0.0;

            foreach (var food in foods)
            {
                var foodCalorie = GetFoodCalorieAmount(food);
                if (tempBfCal > 0 && tempBfCal > foodCalorie && !foodList.Exists(x => x.FoodCategory == food.FoodCategory && x.Type == DietType.Breakfast))//TODO: handle white and red rice
                {
                    food.Type = DietType.Breakfast;
                    foodList.Add(food);
                    bFFoodCalSum += foodCalorie;
                    tempBfCal -= foodCalorie;
                }
                if (tempLcal > 0 && tempLcal > foodCalorie && !foodList.Exists(x => x.Name == food.Name) && !foodList.Exists(x => x.FoodCategory == food.FoodCategory && x.Type == DietType.Lunch))
                {
                    food.Type = DietType.Lunch;
                    foodList.Add(food);
                    lFoodCalSum += foodCalorie;
                    tempLcal -= foodCalorie;
                }
                if (tempDcal > 0 && tempDcal > foodCalorie && !foodList.Exists(x => x.Name == food.Name) && !foodList.Exists(x => x.FoodCategory == food.FoodCategory && x.Type == DietType.Dinner))
                {
                    food.Type = DietType.Dinner;
                    foodList.Add(food);
                    dFoodCalSum += foodCalorie;
                    tempDcal -= foodCalorie;
                }
            }
            CheckBalanceCalorie(bFCal, lCal, dCal, bFFoodCalSum, lFoodCalSum, dFoodCalSum);//Testing Purpose Only

            FillBalanceFoodCalorieByQty(foodList, DietType.Breakfast, bFCal - bFFoodCalSum);
            FillBalanceFoodCalorieByQty(foodList, DietType.Lunch, lCal - lFoodCalSum);
            FillBalanceFoodCalorieByQty(foodList, DietType.Dinner, dCal - dFoodCalSum);

            return foodList;
        }

        private void FillBalanceFoodCalorieByQty(IEnumerable<FoodItemModel> foodList, DietType type, double balanceCalorie)
        {
            var foods = foodList.Where(f => f.Type == type).ToList();
            var foodCount = foods.Count;
            var calPortaion = balanceCalorie / foodCount;

            foreach (var item in foods)
            {
                var foodCalorie = GetFoodCalorieAmount(item);
                var extraFoodQuantity = 100 * calPortaion / foodCalorie;
                item.FoodQuantity += extraFoodQuantity;
            }
        }

        private double GetFoodCalorieAmount(FoodItemModel foodItem)
        {
            var foodCalorie = (foodItem.Fat * 9) + (foodItem.Protine * 4) + (foodItem.Carbohydrate * 4);

            return foodCalorie;
        }

        private void ShowDietOutput(IEnumerable<FoodItemModel> foodList)
        {
            Console.WriteLine("--------------BreakFirst--------------");
            foreach (var item in foodList.Where(f => f.Type == DietType.Breakfast).Select(f => new { f.Name, f.FoodQuantity }).ToList())
            {
                Console.WriteLine("{0}:{1}", item.Name, item.FoodQuantity);
            }
            Console.WriteLine("--------------Lunch--------------");
            foreach (var item in foodList.Where(f => f.Type == DietType.Lunch).Select(f => new { f.Name, f.FoodQuantity }).ToList())
            {
                Console.WriteLine("{0}:{1}", item.Name, item.FoodQuantity);
            }
            Console.WriteLine("--------------Dinner--------------");
            foreach (var item in foodList.Where(f => f.Type == DietType.Dinner).Select(f => new { f.Name, f.FoodQuantity }).ToList())
            {
                Console.WriteLine("{0}:{1}", item.Name, item.FoodQuantity);
            }
        }

        private static void CheckBalanceCalorie(double bFCal, double lCal, double dCal, double bFFoodCalSum, double lFoodCalSum, double dFoodCalSum)
        {
            Console.WriteLine("Initial Balance BF Calorie: {0}", bFCal - bFFoodCalSum);
            Console.WriteLine("Initial Balance Lunch Calorie: {0}", lCal - lFoodCalSum);
            Console.WriteLine("Initial Balance Dinner Calorie: {0}", dCal - dFoodCalSum);
        }

        #endregion Helper Methods
    }
}
