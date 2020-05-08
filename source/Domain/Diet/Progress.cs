using DotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Domain.Diet
{
    public class Progress : Entity<long>, IAuditable
    {
        public Progress(decimal weight, DateTime date)
        {
            Weight = weight;
            Date = date;
        }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public decimal Weight { get; }
        public DateTime Date { get; }
    }
}
