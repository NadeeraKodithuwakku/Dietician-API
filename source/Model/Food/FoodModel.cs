using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model
{
    public class FoodModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public float Fat { get; set; }

        public float Protine { get; set; }

        public float Carbohydrate { get; set; }

        public bool IsVeg { get; set; }

        public DietType FoodType { get; set; }
    }
}
