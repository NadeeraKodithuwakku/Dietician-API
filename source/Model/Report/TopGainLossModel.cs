using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model.Report
{
    public class TopGainLossModel
    {
        public long UserId { get; set; }

        public string FullName { get; set; }

        public decimal Weight { get; set; }

        public decimal Change { get; set; }

        public decimal Percentage { get; set; }
    }
}
