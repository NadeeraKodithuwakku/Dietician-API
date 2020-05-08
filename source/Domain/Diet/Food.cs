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
        public float Fat { get; }
        public float Protine { get; }
        public float Carbohydrate { get; }
        public bool IsVeg { get; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
