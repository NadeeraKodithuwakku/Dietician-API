using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model
{
    public class DietParams
    {
        public long UserId { get; set; }
        public DateTime Date { get; set; }
        public DietType Type { get; set; }
    }
}
