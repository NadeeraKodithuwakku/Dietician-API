using Dietician.Domain.Diet;
using DotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Database
{
    public interface IUserFoodRepository : IRepository<UserFood>
    {
    }
}
