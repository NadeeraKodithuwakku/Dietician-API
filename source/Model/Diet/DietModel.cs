using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model
{
    public class DietModel
    {
        public long UserId { get; set; }

        public DateTime Date { get; set; }

        public string Message { get; set; }

        public double ExtraCalorieAmount { get; set; }

        public bool IsError { get; set; }

        public List<FoodItemModel> FoodItems { get; set; }
    }
}
