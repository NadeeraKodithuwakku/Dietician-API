using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model.Report
{
    public class RatingModel
    {
        public long FoodId { get; set; }

        public FoodModel Food { get; set; }

        public long? UserId { get; set; }

        public int Rating { get; set; }

        public DateTime? Date { get; set; }
    }
}
