using Dietician.Domain.Diet;
using Dietician.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace Dietician.Database
{
    public static class ProgressExpression
    {
        public static Expression<Func<Progress, ProgressModel>> Model => progress => new ProgressModel
        {
            Id = progress.Id,
            Date = progress.Date,
            Weight = progress.Weight,
            UserId = progress.UserId
        };

        public static Expression<Func<Progress, bool>> Id(long id)
        {
            return progress => progress.Id == id;
        }

        public static Expression<Func<Progress, bool>> UserId(long id)
        {
            return progress => progress.UserId == id;
        }
    }
}
