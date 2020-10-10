using Dietician.Database;
using Dietician.Model;
using Dietician.Model.UserFood;
using DotNetCore.Objects;
using DotNetCore.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dietician.Application
{
    public class UserFoodService : IUserFoodService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserFoodRepository _userFoodRepository;

        public UserFoodService(IUnitOfWork unitOfWork, IUserFoodRepository userFoodRepository)
        {
            _unitOfWork = unitOfWork;
            _userFoodRepository = userFoodRepository;
        }
        public async Task<IResult<long>> AddAsync(UserFoodModel model)
        {
            var validation = await new AddUserFoodModelValidator().ValidateAsync(model);
            if (validation.Failed)
            {
                return Result<long>.Fail(validation.Message);
            }
            var entity = UserFoodFactory.CreateEntity(model);
            await _userFoodRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<long>.Success(entity.Id);
        }
    }
}
