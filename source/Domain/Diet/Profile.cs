using Dietician.Domain.Enums;
using DotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Domain.Diet
{
    public class Profile : Entity<long>, IAuditable
    {
        public Profile(int age, Gender gender, decimal weight, decimal height, bool isVeg, bool isPregnant)
        {
            Age = age;
            Gender = gender;
            Weight = weight;
            Height = height;
            IsVeg = isVeg;
            IsPregnant = isPregnant;
        }

        public Profile(long id) : base(id) { }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public int Age { get; }
        public Gender Gender { get; }
        public decimal Weight { get; private set; }
        public decimal Height { get; }
        public bool IsVeg { get; }
        public bool IsPregnant { get; }

        public User User { get; set; }

        public void ChangeWeight(decimal weight)
        {
            Weight = weight;
        }
    }
}
