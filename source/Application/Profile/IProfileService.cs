using Dietician.Model;
using DotNetCore.Objects;
using DotNetCore.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dietician.Application
{
    public interface IProfileService
    {
        Task<IResult<long>> AddAsync(ProfileModel model);

        Task<IResult> DeleteAsync(long id);

        Task<ProfileModel> GetAsync(long id);

        Task<PagedList<ProfileModel>> ListAsync(PagedListParameters parameters);

        Task<IEnumerable<ProfileModel>> ListAsync();

        Task<IResult> UpdateAsync(ProfileModel model);
    }
}
