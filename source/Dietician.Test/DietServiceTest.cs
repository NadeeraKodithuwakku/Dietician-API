using Dietician.Application;
using Dietician.Application.Report;
using Dietician.Database;
using Dietician.Domain.Diet;
using Dietician.Domain.Enums;
using Dietician.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Dietician.Test
{
    public class DietServiceTest
    {
        [Fact]
        public void GetDietAsycTest()
        {
            var dietParams = GetDietParams();
            var profileRepositoryMock = new Mock<IProfileRepository>();
            var foodRepositoryMock = new Mock<IFoodRepository>();
            var reportServiceMock = new Mock<IReportService>();

            profileRepositoryMock.Setup(profile => profile.GetByUserIdAsync(dietParams.UserId)).Returns(Task.FromResult
                (new ProfileModel()
                {
                    UserId = 1,
                    Age = 28,
                    Gender = (int)Gender.Female,
                    Height = 160, //cm
                    Weight = 80, //kg
                    Id = 1,
                    IsVeg = true
                }));

            foodRepositoryMock.Setup(f => f.ListAsync()).Returns(Task.FromResult(
                new List<Food>()
                {
                    new Food("Brown Rice (cooked)",(float)0.9,(float)2.6,(float)22.95,true, FoodCategory.Rice),
                    new Food("Egg Noodles",(float)4.4,(float)14.2,(float)71.3,false, FoodCategory.Noodles),
                    new Food("Rice Noodles(cooked)",(float)0.2,(float)0.9,(float)24.9,true, FoodCategory.Noodles),
                    new Food("Roast Chicken",(float)7.75,(float)12.5,(float)0.5,false, FoodCategory.Meat),
                    new Food("Fride Rice",2,(float)4.7,31,true, FoodCategory.Rice),
                    new Food("Tuna Fish",0,25,0,false,FoodCategory.Meat),
                    new Food("Baked Fish",(float)2.6,(float)25.9,0,false, FoodCategory.Meat),
                    new Food("Fish Sandwich",(float)14.4,19,49,false, FoodCategory.Snack),
                    new Food("Vegie Soup",(float)2.1,(float)1.1,(float)8.7,true, FoodCategory.Soup),
                    new Food("String Hopper",0,(float)3.6,(float)57.1,true, FoodCategory.Snack),
                    new Food("Dhal Curry",(float)2.6,(float)2.5,(float)6.2,true, FoodCategory.Curry),
                    new Food("Salad Leaves",(float)0.3,(float)1.5,(float)3.7,true, FoodCategory.Leaves),
                    new Food("Baked Patatoes",(float)0.1,(float)2.5,(float)21.5,true, FoodCategory.Curry),
                    new Food("Boiled Carrots",0,(float)0.6,(float)8.2,true, FoodCategory.Curry),
                    new Food("Carrot (cooked)",(float)0.1,(float)0.7,(float)6.7,true, FoodCategory.Curry),
                    new Food("Carrot Salad",11,1,(float)9.4,true, FoodCategory.Leaves),
                    new Food("Seafood pasta salad",5,(float)3.9,(float)7.7,false, FoodCategory.Snack),
                    new Food("Dried Mango Slices",0,0,86,true, FoodCategory.Fruit),
                    new Food("Avacado",25,5,5,true, FoodCategory.Fruit),
                    new Food("Avacado Ice Cream",5,0,19,true, FoodCategory.Dissert),
                    new Food("Garlic Bread",(float)16.6,(float)8.4,(float)41.7,true, FoodCategory.Snack),
                    new Food("Banana Bread",(float)10.5,(float)5.4,(float)57.1,true, FoodCategory.Snack),
                    new Food("Bread",(float)1.2,(float)7.7,48,true, FoodCategory.Snack),
                    new Food("Pumkin (cooked)",(float)1.8,(float)1.1,(float)7.9,true, FoodCategory.Curry),
                    new Food("Beet (cooked)",(float)0.2,(float)1.7,10,true, FoodCategory.Curry),
                    new Food("Salmon",(float)13.4,(float)20.4,0,false, FoodCategory.Meat),
                    new Food("Banana",(float)0.3,(float)1.1,(float)22.8,true, FoodCategory.Fruit),

                }.AsEnumerable()));

            DietService service = new DietService(foodRepositoryMock.Object, profileRepositoryMock.Object, reportServiceMock.Object);

            var output = service.GetDietAsyc(dietParams);
            Assert.NotNull(output.Result);
            Console.WriteLine("--------------BreakFirst--------------");
            foreach (var item in output.Result.FoodItems.Where(f => f.Type == DietType.Breakfast).Select(f => f.Name).ToList())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------Lunch--------------");
            foreach (var item in output.Result.FoodItems.Where(f => f.Type == DietType.Lunch).Select(f => f.Name).ToList())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------Dinner--------------");
            foreach (var item in output.Result.FoodItems.Where(f => f.Type == DietType.Dinner).Select(f => f.Name).ToList())
            {
                Console.WriteLine(item);
            }
        }

        private DietParams GetDietParams()
        {
            var dietParams = new DietParams()
            {
                UserId = 1,
                Date = DateTime.Now,
                Type = (DietType)1
            };

            return dietParams;

        }
    }
}
