using DotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Domain.Diet
{
    public class Food : Entity<long>, IAuditable
    {
        public Food(string name, float fat, float protine, float carbohydrate, bool isVeg)
        {
            Name = name;
            Fat = fat;
            Protine = protine;
            Carbohydrate = carbohydrate;
            IsVeg = isVeg;
        }

        public string Name { get; }
        public float Fat { get; private set; }
        public float Protine { get; private set; }
        public float Carbohydrate { get; private set; }
        public bool IsVeg { get; private set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public void UpdateFood(float fat, float protine, float carbohydrate, bool isVeg)
        {
            Fat = fat;
            Protine = protine;
            Carbohydrate = carbohydrate;
            IsVeg = isVeg;
            DateModified = DateTime.Now;
        }
    }
}
