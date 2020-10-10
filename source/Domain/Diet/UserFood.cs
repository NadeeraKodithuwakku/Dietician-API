using DotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dietician.Domain.Diet
{
    public class UserFood : Entity<long>, IAuditable
    {
        public UserFood(long userId, long foodId, int rating, DateTime date, int dayOfWeek)
        {
            UserId = userId;
            FoodId = foodId;
            Rating = rating;
            Date = date;
            DayOfWeek = dayOfWeek;
        }

        public long UserId { get; set; }
        public long FoodId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("FoodId")]
        public Food Food { get; set; }

        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public int DayOfWeek { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
