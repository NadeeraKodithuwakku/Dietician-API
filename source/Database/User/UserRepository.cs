using Dietician.Domain;
using Dietician.Model;
using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dietician.Database
{
    public sealed class UserRepository : EFRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context) { }

        public Task<long> GetAuthIdByUserIdAsync(long id)
        {
            return Queryable.Where(UserExpression.Id(id)).Select(UserExpression.AuthId).SingleOrDefaultAsync();
        }

        public Task<UserModel> GetByIdAsync(long id)
        {
            return Queryable.Where(UserExpression.Id(id)).Select(UserExpression.Model).SingleOrDefaultAsync();
        }

        public Task<UserModel> GetByLoginAsync(string email)
        {
            return Queryable.Where(UserExpression.Email(email)).Select(UserExpression.Model).SingleOrDefaultAsync();
        }

        public Task UpdateStatusAsync(User user)
        {
            return UpdatePartialAsync(user.Id, new { user.Status });
        }
    }
}
