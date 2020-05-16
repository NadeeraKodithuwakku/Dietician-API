using Dietician.Model;
using DotNetCore.Objects;
using DotNetCore.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dietician.Application
{
    public interface IFoodService
    {
        Task<IResult<long>> AddAsync(FoodModel model);

        Task<IResult> DeleteAsync(long id);

        Task<FoodModel> GetAsync(long id);

        Task<PagedList<FoodModel>> ListAsync(PagedListParameters parameters);

        Task<IEnumerable<FoodModel>> ListAsync();

        Task<IResult> UpdateAsync(FoodModel model);
    }
}
