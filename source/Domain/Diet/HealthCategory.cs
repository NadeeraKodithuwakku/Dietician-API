using DotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Domain.Diet
{
    public class HealthCategory : Entity<long>, IAuditable
    {
        public HealthCategory(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
