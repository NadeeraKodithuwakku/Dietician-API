using Dietician.Database;
using Dietician.Domain.Diet;
using Dietician.Model;
using Dietician.Model.Food;
using DotNetCore.Objects;
using DotNetCore.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dietician.Application
{
    public class DietService : IDietService
    {
        private readonly IFoodRepository foodRepository;
        private readonly IPlanRepository planRepository;
        private readonly IUserRepository userRepository;
        private readonly IProgressRepository progressRepository;

        public DietService(
            IFoodRepository foodRepository,
            IPlanRepository planRepository,
            IUserRepository userRepository,
            IProgressRepository progressRepository)
        {
            this.foodRepository = foodRepository;
            this.planRepository = planRepository;
            this.userRepository = userRepository;
            this.progressRepository = progressRepository;
        }

        public async Task<DietModel> GetDietAsyc(DietParams @params)
        {
            var validation = await new DietParamValidator().ValidateAsync(@params);
            if (validation.Failed)
            {
                throw new ArgumentException(validation.Message);
            }

            var user = await userRepository.GetAsync(@params.UserId);
            var plan = await planRepository.GetAsync(@params.PlanId);
            var foods = await foodRepository.ListAsync();
            var progress = await progressRepository.GetByUserIdAync(@params.UserId);
            // TODO: implement filter logic
            Console.WriteLine(progress.Count);

            return DietFactory.CreateDiet(user, @params.Date, plan.Id, foods);
        }
    }
}
