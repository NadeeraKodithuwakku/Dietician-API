using Dietician.Model;
using DotNetCore.Objects;
using DotNetCore.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dietician.Application
{
    public interface IUserService
    {
        Task<IResult<long>> AddAsync(UserModel model);

        Task<IResult> DeleteAsync(long id);

        Task<UserModel> GetAsync(long id);

        Task InactivateAsync(long id);

        Task<PagedList<UserModel>> ListAsync(PagedListParameters parameters);

        Task<IEnumerable<UserModel>> ListAsync();

        Task<IResult> UpdateAsync(UserModel model);
    }
}
