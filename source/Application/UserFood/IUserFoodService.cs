using Dietician.Model;
using DotNetCore.Objects;
using DotNetCore.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dietician.Application
{
    public interface IUserFoodService
    {
        Task<IResult<long>> AddAsync(UserFoodModel model);

        Task<IEnumerable<UserFoodModel>> ListAsync();
    }
}
