using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model.Report
{
    public class HealthCategoryDetailModel
    {
        public int UnderWeightCount { get; set; }
        public int OverWeightCount { get; set; }
        public int HealthyCount { get; set; }

        public DateTime Date { get; set; }
    }
}
