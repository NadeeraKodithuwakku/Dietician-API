using System.Threading.Tasks;

namespace Dietician.Database
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
