using Dietician.Domain.Enums;
using DotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Domain.Diet
{
    public class Menu : Entity<long>, IAuditable
    {
        public Menu(MealType mealType, DateTime date)
        {
            MealType = mealType;
            Date = date;
        }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public MealType MealType { get; }
        public DateTime Date { get; }
    }
}
