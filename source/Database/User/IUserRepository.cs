using Dietician.Domain;
using Dietician.Model;
using DotNetCore.Repositories;
using System.Threading.Tasks;

namespace Dietician.Database
{
    public interface IUserRepository : IRepository<User>
    {
        Task<long> GetAuthIdByUserIdAsync(long id);

        Task<UserModel> GetByIdAsync(long id);

        Task UpdateStatusAsync(User user);
        Task<UserModel> GetByLoginAsync(string email);
    }
}
