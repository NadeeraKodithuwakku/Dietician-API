using Dietician.Model.Report;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Application.Report
{
    public sealed class ReportFactory
    {
        public static HealthCategoryDetailModel CreatehealthCategoryDetailModel(int underWeight, int healthy, int overWeight, DateTime date)
        {
            return new HealthCategoryDetailModel
            {
                Date = date,
                HealthyCount = healthy,
                OverWeightCount = overWeight,
                UnderWeightCount = underWeight
            };
        }
    }
}
