using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model
{
    public class ProgressModel
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public DateTime Date { get; set; }

        public decimal Weight { get; set; }
    }
}
