using Dietician.Domain.Diet;
using DotNetCore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Database
{
    public class UserFoodRepository : EFRepository<UserFood>, IUserFoodRepository
    {
        public UserFoodRepository(Context context) : base(context) { }
    }
}
