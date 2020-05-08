using Dietician.Domain.Diet;
using Dietician.Model;
using DotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dietician.Database
{
    public interface IProfileRepository : IRepository<Profile>
    {
        Task<long> GetByUserIdAync(long id);

        Task<ProfileModel> GetByIdAsync(long id);

        Task UpdateWeightAsync(Profile profile);
    }
}
