using DotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public decimal Weight { get; private set; }
        public DateTime Date { get; }

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public void ChangeWeight(decimal weight)
        {
            Weight = weight;
            DateModified = DateTime.Now;
        }
    }
}
