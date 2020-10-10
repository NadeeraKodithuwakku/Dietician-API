using Dietician.Domain.Enums;
using Dietician.Model;
using DotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dietician.Domain.Diet
{
    public class Profile : Entity<long>, IAuditable
    {
        public Profile(int age, Gender gender, decimal weight, decimal height, bool isVeg)
        {
            Age = age;
            Gender = gender;
            Weight = weight;
            Height = height;
            IsVeg = isVeg;
        }

        public Profile(long id) : base(id) { }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public int Age { get; set; }
        public Gender Gender { get; set; }
        public decimal Weight { get; private set; }
        public decimal CurrentWeight { get; set; }
        public decimal TargetWeight { get; set; }
        public decimal Height { get; set; }
        public bool IsVeg { get; set; }

        public ActivityLevel ActivityLevel { get; set; }

        public Goal Goal { get; set; }
        public Pace Pace { get; set; }

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public void UpdateProfile(ProfileModel profile)
        {
            CurrentWeight = profile.CurrentWeight;
            Weight = profile.Weight;
            ActivityLevel = (ActivityLevel)profile.ActivityLevel;
            Age = profile.Age;
            Height = profile.Height;
            Gender = (Gender)profile.Gender;
            Goal = (Goal)profile.Goal;
            TargetWeight = profile.TargetWeight;
            Pace = (Pace)profile.Pace;
            IsVeg = profile.IsVeg;
            DateModified = DateTime.Now;
        }

        public void UpdateCurrentWeight(decimal currentWeight)
        {
            CurrentWeight = currentWeight;
        }
    }
}
