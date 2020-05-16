using Dietician.Domain.Diet;
using Dietician.Model;
using DotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dietician.Database
{
    public interface IPlanRepository : IRepository<Plan>
    {
        Task<PlanModel> GetByIdAsync(long id);

        Task UpdateStatusAsync(Plan plan);
    }
}
