using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model
{
    public class DietModel
    {
        public long UserId { get; set; }

        public long PlanId { get; set; }

        public DateTime Date { get; set; }

        public List<FoodItemModel> FoodItems { get; set; }
    }
}
