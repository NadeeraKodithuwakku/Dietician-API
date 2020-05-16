using Dietician.Domain;
using Dietician.Domain.Diet;
using Dietician.Model;
using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dietician.Database
{
    public sealed class FoodRespository : EFRepository<Food>, IFoodRepository
    {
        public FoodRespository(Context context) : base(context)
        {
        }
        public Task<FoodModel> GetByIdAsync(long id)
        {
            return Queryable.Where(FoodExpression.Id(id)).Select(FoodExpression.Model).SingleOrDefaultAsync();
        }
    }
}
