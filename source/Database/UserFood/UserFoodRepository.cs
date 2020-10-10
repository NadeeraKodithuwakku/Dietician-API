using Dietician.Domain.Diet;
using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietician.Database
{
    public class UserFoodRepository : EFRepository<UserFood>, IUserFoodRepository
    {
        public UserFoodRepository(Context context) : base(context) { }

        public Task<List<UserFood>> ListByDayAsync(int day)
        {
            return Queryable.Where(r => r.DayOfWeek == day).ToListAsync();
        }

        public Task<List<UserFood>> ListByUserAndDayAsync(long userId, int day)
        {
            return Queryable.Where(r => r.DayOfWeek == day && r.UserId == userId).ToListAsync();
        }

        public Task<List<UserFood>> ListByUserIdAsync(long userId)
        {
            return Queryable.Where(r => r.UserId == userId).ToListAsync();
        }
    }
}
