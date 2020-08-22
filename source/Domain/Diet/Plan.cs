using Dietician.Domain.Enums;
using DotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dietician.Domain.Diet
{
    public class Plan : Entity<long>, IAuditable
    {
        public Plan(string name, ActivityLevel activityLevel, Goal goal, decimal target, Pace pace, int duration = 0)
        {
            Name = name;
            ActivityLevel = activityLevel;
            Goal = goal;
            Target = target;
            Pace = pace;
            Duration = duration;
            Status = Status.Inactive;
        }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public ActivityLevel ActivityLevel { get; set; }
        public Goal Goal { get; set; }
        public Pace Pace { get; set; }
        public decimal Target { get; }
        public string Name { get; }
        public DateTime? StartDate { get; private set; }
        public int Duration { get; }
        public Status Status { get; private set; }

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public void Activate()
        {
            Status = Status.Active;
            StartDate = DateTime.Now;
            DateModified = DateTime.Now;
        }

        public void Inactivate()
        {
            Status = Status.Inactive;
        }
    }
}
