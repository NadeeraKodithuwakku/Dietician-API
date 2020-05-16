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
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProfileRepository _profileRepository;

        public ProfileService
            (
            IUnitOfWork unitOfWork,
            IProfileRepository profileRepository
            )
        {
            _unitOfWork = unitOfWork;
            _profileRepository = profileRepository;
        }

        public async Task<IResult<long>> AddAsync(ProfileModel model)
        {
            var validation = await new AddProfileModelValidator().ValidateAsync(model);
            if (validation.Failed)
            {
                return Result<long>.Fail(validation.Message);
            }
            var profile = ProfileFactory.CreateProfile(model);
            await _profileRepository.AddAsync(profile);
            await _unitOfWork.SaveChangesAsync();
            return Result<long>.Success(profile.Id);

        }

        public async Task<IResult> DeleteAsync(long id)
        {
            await _profileRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }

        public Task<ProfileModel> GetAsync(long id)
        {
            return _profileRepository.GetByIdAsync(id);
        }

        public Task<PagedList<ProfileModel>> ListAsync(PagedListParameters parameters)
        {
            return _profileRepository.Queryable.Select(ProfileExpression.Model).ListAsync(parameters);
        }

        public async Task<IEnumerable<ProfileModel>> ListAsync()
        {
            return await _profileRepository.Queryable.Select(ProfileExpression.Model).ToListAsync();
        }

        public async Task<IResult> UpdateAsync(ProfileModel model)
        {
            var validation = await new UpdateProfileModelValidator().ValidateAsync(model);

            if (validation.Failed)
            {
                return Result.Fail(validation.Message);
            }

            var profile = await _profileRepository.GetAsync(model.Id);

            if (profile == default)
            {
                return Result.Success();
            }

            profile.ChangeWeight(model.Weight);

            await _profileRepository.UpdateWeightAsync(profile);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
