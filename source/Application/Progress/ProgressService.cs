using Dietician.Database;
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
    public class ProgressService : IProgressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProgressRepository _ProgressRepository;
        private readonly IUserRepository _userRepository;

        public ProgressService
            (
            IUnitOfWork unitOfWork,
            IProgressRepository ProgressRepository,
            IUserRepository userRepository
            )
        {
            _unitOfWork = unitOfWork;
            _ProgressRepository = ProgressRepository;
            _userRepository = userRepository;
        }

        public async Task<IResult<long>> AddAsync(ProgressModel model)
        {
            var validation = await new AddProgressModelValidator().ValidateAsync(model);
            if (validation.Failed)
            {
                return Result<long>.Fail(validation.Message);
            }
            var user = await _userRepository.GetAsync(model.UserId);
            var Progress = ProgressFactory.CreateProgress(model, user);
            await _ProgressRepository.AddAsync(Progress);
            await _unitOfWork.SaveChangesAsync();
            return Result<long>.Success(Progress.Id);

        }

        public async Task<IResult> DeleteAsync(long id)
        {
            await _ProgressRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }

        public Task<ProgressModel> GetAsync(long id)
        {
            return _ProgressRepository.GetByIdAsync(id);
        }

        public Task<PagedList<ProgressModel>> ListAsync(PagedListParameters parameters)
        {
            return _ProgressRepository.Queryable.Select(ProgressExpression.Model).ListAsync(parameters);
        }

        public async Task<IEnumerable<ProgressModel>> ListAsync()
        {
            return await _ProgressRepository.Queryable.Select(ProgressExpression.Model).ToListAsync();
        }

        public async Task<IResult> UpdateAsync(ProgressModel model)
        {
            var validation = await new UpdateProgressModelValidator().ValidateAsync(model);

            if (validation.Failed)
            {
                return Result.Fail(validation.Message);
            }

            var Progress = await _ProgressRepository.GetAsync(model.Id);

            if (Progress == default)
            {
                return Result.Success();
            }

            Progress.ChangeWeight(model.Weight);

            await _ProgressRepository.UpdateWeightAsync(Progress);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}

