using Dietician.Database;
using Dietician.Model;
using Dietician.Model.Food;
using DotNetCore.Objects;
using DotNetCore.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietician.Application
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FoodService(IFoodRepository foodRepository, IUnitOfWork unitOfWork)
        {
            _foodRepository = foodRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IResult<long>> AddAsync(FoodModel model)
        {
            var validation = await new AddFoodModelValidator().ValidateAsync(model);
            if (validation.Failed)
            {
                return Result<long>.Fail(validation.Message);
            }

            var food = FoodFactory.CreateFood(model);
            await _foodRepository.AddAsync(food);
            await _unitOfWork.SaveChangesAsync();

            return Result<long>.Success(food.Id);
        }

        public async Task<IResult> DeleteAsync(long id)
        {
            await _foodRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }

        public Task<FoodModel> GetAsync(long id)
        {
            return _foodRepository.GetByIdAsync(id);
        }

        public Task<PagedList<FoodModel>> ListAsync(PagedListParameters parameters)
        {
            return _foodRepository.Queryable.Select(FoodExpression.Model).ListAsync(parameters);
        }

        public async Task<IEnumerable<FoodModel>> ListAsync()
        {
            return await _foodRepository.Queryable.Select(FoodExpression.Model).ToListAsync();
        }

        public async Task<IResult> UpdateAsync(FoodModel model)
        {
            var validation = await new UpdateFoodModelValidator().ValidateAsync(model);
            if (validation.Failed)
            {
                return Result<long>.Fail(validation.Message);
            }

            var food = _foodRepository.Get(model.Id);
            food.UpdateFood(model.Fat, model.Protine, model.Carbohydrate, model.IsVeg);

            await _foodRepository.UpdateAsync(model.Id, food);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
