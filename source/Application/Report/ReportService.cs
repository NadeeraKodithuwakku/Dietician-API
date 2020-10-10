using Dietician.Database;
using Dietician.Model;
using Dietician.Model.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietician.Application.Report
{
    public class ReportService : IReportService
    {
        private readonly IProgressRepository progressRepository;
        private readonly IProfileRepository profileRepository;

        public ReportService(IProgressRepository progressRepository, IProfileRepository profileRepository)
        {
            this.progressRepository = progressRepository;
            this.profileRepository = profileRepository;
        }
        public async Task<IEnumerable<HealthCategoryDetailModel>> GetHealthCategories(int days)
        {
            List<HealthCategoryDetailModel> result = new List<HealthCategoryDetailModel>();
            List<ProfileModel> profiles = new List<ProfileModel>();
            for (int i = 0; i < days; i++)
            {
                var date = DateTime.Now.AddDays(-i);
                var progress = await progressRepository.GetByDateAync(date);
                var underWeightCount = 0;
                var healthyCount = 0;
                var OverWeightCount = 0;
                foreach (var item in progress)
                {
                    var profile = profiles.Where(p => p.UserId == item.UserId).SingleOrDefault();

                    if (profile == null)
                    {
                        profile = await profileRepository.GetByUserIdAsync(item.UserId);
                        profiles.Add(profile);
                    }
                    if (profile != null)
                    {
                        var BMI = (double)profile.Weight / Math.Pow((double)(profile.Height / 100), 2);

                        // healthy range : 18.5 and 24.9
                        if (BMI < 18.5)
                        {
                            underWeightCount++;
                        }
                        else if (BMI > 24.9)
                        {
                            OverWeightCount++;
                        }
                        else
                        {
                            healthyCount++;
                        }

                    }
                }

                result.Add(ReportFactory.CreatehealthCategoryDetailModel(underWeightCount, healthyCount, OverWeightCount, date));

            }

            return result;
        }
    }
}
