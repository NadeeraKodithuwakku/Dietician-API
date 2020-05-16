using Dietician.Database;
using Dietician.Domain;
using Dietician.Model;
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
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PlanService(IPlanRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IResult<long>> AddAsync(PlanModel model)
        {
            var validation = await new AddPlanModelValidator().ValidateAsync(model);
            if (validation.Failed)
            {
                return Result<long>.Fail(validation.Message);
            }

            var plan = PlanFactory.CreatePlan(model);
            await _repository.AddAsync(plan);
            await _unitOfWork.SaveChangesAsync();

            return Result<long>.Success(plan.Id);
        }

        public async Task<IResult> DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }

        public Task<PlanModel> GetAsync(long id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<PagedList<PlanModel>> ListAsync(PagedListParameters parameters)
        {
            return _repository.Queryable.Select(PlanExpression.Model).ListAsync(parameters);
        }

        public async Task<IEnumerable<PlanModel>> ListAsync()
        {
            return await _repository.Queryable.Select(PlanExpression.Model).ToListAsync();
        }

        public async Task<IResult> UpdateAsync(PlanModel model)
        {
            var validation = await new UpdatePlanModelValidator().ValidateAsync(model);

            if (validation.Failed)
            {
                return Result.Fail(validation.Message);
            }

            var plan = await _repository.GetAsync(model.Id);

            if (plan == default)
            {
                return Result.Success();
            }
            if (model.Status == (int)Status.Active)
            {
                plan.Activate();
            }
            else
            {
                plan.Inactivate();
            }

            await _repository.UpdateStatusAsync(plan);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
