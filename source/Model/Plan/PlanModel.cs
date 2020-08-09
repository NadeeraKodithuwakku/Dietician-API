using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model
{
    public class PlanModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int ActivityLevel { get; set; }
        public int Goal { get; set; }
        public int Pace { get; set; }
        public decimal Target { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }
        public int Status { get; set; }
        public long UserId { get; set; }
    }
}
