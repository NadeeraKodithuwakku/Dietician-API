using Dietician.Domain;
using Dietician.Domain.Diet;
using Dietician.Domain.Enums;
using Dietician.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Application
{
    public static class ProgressFactory
    {
        public static Progress CreateProgress(ProgressModel progress, User user)
        {
            var result = new Progress(
                progress.Weight,
                progress.Date)
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                CreatedBy = "Admin",
                ModifiedBy = "Admin",
                User = user
            };

            return result;
        }
    }
}
