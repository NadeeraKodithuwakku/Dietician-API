using Dietician.Domain.Diet;
using Dietician.Model;
using DotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dietician.Database
{
    public interface IFoodRepository : IRepository<Food>
    {
        Task<FoodModel> GetByIdAsync(long id);
    }
}
