using Dietician.Domain.Diet;
using Dietician.Domain.Enums;
using Dietician.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Dietician.Database
{
    public static class ProfileExpression
    {
        public static Expression<Func<Profile, long>> UserId => profile => profile.User.Id;

        public static Expression<Func<Profile, ProfileModel>> Model => profile => new ProfileModel
        {
            Id = profile.Id,
            Age = profile.Age,
            Gender = (int)profile.Gender,
            Weight = profile.Weight,
            Height = profile.Height,
            IsPregnant = profile.IsPregnant,
            IsVeg = profile.IsVeg
        };

        public static Expression<Func<Profile, bool>> Id(long id)
        {
            return profile => profile.Id == id;
        }
    }
}
