using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model.Report
{
    public class BmiModel
    {
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal BmiValue { get; set; }
        public long UserId { get; set; }
    }
}
