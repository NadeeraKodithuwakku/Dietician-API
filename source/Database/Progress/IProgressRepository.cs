using Dietician.Domain.Diet;
using Dietician.Model;
using DotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dietician.Database
{
    public interface IProgressRepository : IRepository<Progress>
    {
        Task<List<ProgressModel>> GetByUserIdAync(long id);

        Task<ProgressModel> GetByIdAsync(long id);

        Task UpdateWeightAsync(Progress progress);
    }
}
