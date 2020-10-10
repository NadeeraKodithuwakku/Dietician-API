using Dietician.Model.Report;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dietician.Application.Report
{
    public interface IReportService
    {
        Task<IEnumerable<RatingModel>> GetFoodRating();
        Task<IEnumerable<RatingModel>> GetFoodRatingByDayOfWeek(int dayOfWeek);
        Task<IEnumerable<RatingModel>> GetFoodRatingByUserAndDayOfWeek(long userId, int dayOfWeek);
        Task<IEnumerable<RatingModel>> GetFoodRatingByUserId(long userId);
        Task<IEnumerable<HealthCategoryDetailModel>> GetHealthCategories(int days, DateTime reportDate);
        Task<IEnumerable<TopGainLossModel>> GetTopGainers(DateTime date, int count);
        Task<IEnumerable<TopGainLossModel>> GetTopLoosers(DateTime date, int count);
    }
}
