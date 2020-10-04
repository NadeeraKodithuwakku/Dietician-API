using Dietician.Database;
using Dietician.Model;
using Dietician.Model.Report;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietician.Application.Report
{
    public class BmiService : IBmiService
    {
        private readonly IProfileRepository _profileRepository;

        public BmiService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<IEnumerable<BmiModel>> GetUserBmi()
        {
            List<BmiModel> result = new List<BmiModel>();
            var profileList = await _profileRepository.Queryable.Select(ProfileExpression.Model).ToListAsync();
            //BMI = weight(kg) / [height(m)]2
            foreach (ProfileModel profie in profileList)
            {
                BmiModel model = new BmiModel()
                {
                    UserId = profie.UserId,
                    Weight = profie.Weight,
                    Height = profie.Height,
                    BmiValue = (decimal)((double)profie.Weight / Math.Pow((double)(profie.Height / 100), 2))
                };

                result.Add(model);
            }
            return result;
        }
    }
}
