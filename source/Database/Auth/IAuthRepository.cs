using Dietician.Domain;
using DotNetCore.Repositories;
using System.Threading.Tasks;

namespace Dietician.Database
{
    public interface IAuthRepository : IRepository<Auth>
    {
        Task<bool> AnyByLoginAsync(string login);

        Task<Auth> GetByLoginAsync(string login);
    }
}
