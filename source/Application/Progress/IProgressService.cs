using Dietician.Model;
using DotNetCore.Objects;
using DotNetCore.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Dietician.Application
{
    public interface IProgressService
    {
        Task<IResult<long>> AddAsync(ProgressModel model);

        Task<IResult> DeleteAsync(long id);

        Task<ProgressModel> GetAsync(long id);

        Task<PagedList<ProgressModel>> ListAsync(PagedListParameters parameters);

        Task<IEnumerable<ProgressModel>> ListAsync();

        Task<IResult> UpdateAsync(ProgressModel model);
    }
}
