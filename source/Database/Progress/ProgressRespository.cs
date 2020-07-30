using Dietician.Domain;
using Dietician.Domain.Diet;
using Dietician.Model;
using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dietician.Database
{
    public sealed class ProgressRespository : EFRepository<Progress>, IProgressRepository
    {
        public ProgressRespository(Context context) : base(context)
        {
        }

        public Task<ProgressModel> GetByIdAsync(long id)
        {
            return Queryable.Where(ProgressExpression.Id(id)).Select(ProgressExpression.Model).SingleOrDefaultAsync();
        }

        public Task<List<ProgressModel>> GetByUserIdAync(long id)
        {
            return Queryable.Where(ProgressExpression.UserId(id)).Select(ProgressExpression.Model).ToListAsync();
        }

        public Task UpdateWeightAsync(Progress progress)
        {
            return UpdatePartialAsync(progress.Id, new { progress.Weight, progress.DateModified });
        }
    }
}
