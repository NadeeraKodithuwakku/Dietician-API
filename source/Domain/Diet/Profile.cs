using Dietician.Domain.Enums;
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

        public int Age { get; }
        public Gender Gender { get; }
        public decimal Weight { get; private set; }
        public decimal Height { get; }
        public bool IsVeg { get; }

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public void ChangeWeight(decimal weight)
        {
            Weight = weight;
            DateModified = DateTime.Now;
        }
    }
}
