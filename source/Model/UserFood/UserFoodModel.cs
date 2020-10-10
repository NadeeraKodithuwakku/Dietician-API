using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model
{
    public class UserFoodModel
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long FoodId { get; set; }

        public int Rating { get; set; }

        public DateTime Date { get; set; }
    }
}
