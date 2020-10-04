using Dietician.Domain;
using Dietician.Domain.Diet;
using Dietician.Domain.Enums;
using Dietician.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Application
{
    public static class ProfileFactory
    {
        public static Profile CreateProfile(ProfileModel profile, User user)
        {
            var result = new Profile(
                profile.Age,
                (Gender)profile.Gender,
                profile.Weight,
                profile.Height,
                profile.IsVeg)
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                CreatedBy = "Admin",
                ModifiedBy = "Admin",
                UserId = user.Id,
                ActivityLevel = (ActivityLevel)profile.ActivityLevel,
                Goal = (Goal)profile.Goal,
                Pace = (Pace)profile.Pace
            };

            return result;
        }
    }
}
