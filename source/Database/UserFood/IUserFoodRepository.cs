using Dietician.Domain.Diet;
using DotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dietician.Database
{
    public interface IUserFoodRepository : IRepository<UserFood>
    {
        Task<List<UserFood>> ListByUserIdAsync(long userId);
        Task<List<UserFood>> ListByDayAsync(int day);
        Task<List<UserFood>> ListByUserAndDayAsync(long userId, int day);
    }
}
