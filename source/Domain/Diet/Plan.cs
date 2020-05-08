using DotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Domain.Diet
{
    public class Plan : Entity<long>, IAuditable
    {
        public Plan(decimal target, string name, DateTime startDate, TimeSpan duration)
        {
            Target = target;
            Name = name;
            StartDate = startDate;
            Duration = duration;
        }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public decimal Target { get; }
        public string Name { get; }
        public DateTime StartDate { get; }
        public TimeSpan Duration { get; }
        public Status Status { get; private set; }

        public void Activate()
        {
            Status = Status.Active;
        }

        public void Inactivate()
        {
            Status = Status.Inactive;
        }
    }
}
