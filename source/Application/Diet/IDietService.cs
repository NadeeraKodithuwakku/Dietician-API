using Dietician.Database;
using Dietician.Model;
using System;
using System.Threading.Tasks;

namespace Dietician.Application
{
    public interface IDietService
    {
        Task<DietModel> GetDietAsyc(DietParams @params);
    }
}
