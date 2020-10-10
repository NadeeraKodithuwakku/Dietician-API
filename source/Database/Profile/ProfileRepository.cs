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
    public sealed class ProfileRepository : EFRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(Context context) : base(context)
        {
        }

        public Task<ProfileModel> GetByIdAsync(long id)
        {
            return Queryable.Where(ProfileExpression.Id(id)).Select(ProfileExpression.Model).SingleOrDefaultAsync();
        }

        public Task<ProfileModel> GetByUserIdAsync(long userId)
        {
            return Queryable.Where(ProfileExpression.UserId(userId)).Select(ProfileExpression.Model).SingleOrDefaultAsync();
        }

        public Task UpdateWeightAsync(Profile profile)
        {
            return UpdatePartialAsync(profile.Id, new
            {
                profile.Weight,
                profile.CurrentWeight,
                profile.DateModified,
                profile.ActivityLevel,
                profile.Age,
                profile.Height,
                profile.Gender,
                profile.Goal,
                profile.TargetWeight,
                profile.Pace,
                profile.IsVeg
            });
        }
    }
}
