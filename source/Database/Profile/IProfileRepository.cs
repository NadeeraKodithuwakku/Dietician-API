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
        Task<ProfileModel> GetByUserIdAsync(long userId);

        Task<ProfileModel> GetByIdAsync(long id);

        Task UpdateProfileAsync(Profile profile);
    }
}
