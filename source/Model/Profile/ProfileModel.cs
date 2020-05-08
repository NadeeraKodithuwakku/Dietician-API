using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Model
{
    public class ProfileModel
    {

        public long Id { get; set; }

        public int Age { get; set; }
        public int Gender { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public bool IsVeg { get; set; }
        public bool IsPregnant { get; set; }

        public long UserId { get; set; }
    }
}
