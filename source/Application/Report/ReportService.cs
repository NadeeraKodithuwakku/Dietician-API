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
        private readonly IUserRepository userRepository;

        public ReportService(IProgressRepository progressRepository, IProfileRepository profileRepository, IUserRepository userRepository)
        {
            this.progressRepository = progressRepository;
            this.profileRepository = profileRepository;
            this.userRepository = userRepository;
        }
        public async Task<IEnumerable<HealthCategoryDetailModel>> GetHealthCategories(int days, DateTime reportDate)
        {
            List<HealthCategoryDetailModel> result = new List<HealthCategoryDetailModel>();
            List<ProfileModel> profiles = new List<ProfileModel>();
            for (int i = 0; i < days; i++)
            {
                var date = reportDate.AddDays(-i);
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
                        var BMI = (double)item.Weight / Math.Pow((double)(profile.Height / 100), 2);

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

        public async Task<IEnumerable<TopGainLossModel>> GetTopGainers(DateTime date, int count)
        {
            return await GetRange(date, count, true);
        }


        public async Task<IEnumerable<TopGainLossModel>> GetTopLoosers(DateTime date, int count)
        {
            return await GetRange(date, count, false);
        }

        private async Task<IEnumerable<TopGainLossModel>> GetRange(DateTime date, int count, bool isGainers)
        {
            List<TopGainLossModel> result = new List<TopGainLossModel>();
            var lastDay = date.AddDays(-1);
            var dayBeforeLastDay = date.AddDays(-2);

            var progressLast = await progressRepository.GetByDateAync(lastDay);
            var progressBeforeLast = await progressRepository.GetByDateAync(dayBeforeLastDay);

            foreach (var item in progressLast)
            {
                var progressBefore = progressBeforeLast.Where(p => p.UserId == item.UserId).SingleOrDefault();

                if (progressBefore != null)
                {
                    var change = item.Weight - progressBefore.Weight;

                    if ((change > 0 && isGainers) || (change < 0 && !isGainers))
                    {
                        var precentage = change / progressBefore.Weight * 100;
                        var user = await userRepository.GetByIdAsync(item.UserId);

                        TopGainLossModel model = ReportFactory.CreateTopGainerLooserModel(
                            item.UserId, user.Name, user.Surname, change, precentage, item.Weight);
                        result.Add(model);

                    }
                }
            }
            result.Sort((a, b) => { return a.Percentage.CompareTo(b.Percentage); });
            if (result.Count > count)
            {
                result.RemoveRange(count, result.Count - count);
            }
            return result;
        }

    }
}