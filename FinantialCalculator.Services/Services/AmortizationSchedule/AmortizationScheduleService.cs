namespace FinantialCalculator.Services.Services.AmortizationSchedule
{
    using FinantialCalculator.Domain.Common.Dtos.Entities;
    using FinantialCalculator.Domain.Contracts.ServiceContracts;
    using FinantialCalculator.Services.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AmortizationScheduleService : IAmortizationScheduleService
    {
        private readonly AmortizationScheduleRepository AmortizationScheduleRepository;

        public AmortizationScheduleService() => AmortizationScheduleRepository = new AmortizationScheduleRepository();

        public async Task<AmortizationScheduleEntiti> GetAmortizationScheduleAsync(uint amortizationScheduleId)
        {
            return await AmortizationScheduleRepository.RunReposituryAsync(async () => { return await AmortizationScheduleRepository.GetAmortizationScheduleAsync(amortizationScheduleId); });
        }

        public async Task<IList<AmortizationScheduleEntiti>> GetAllAmortizationScheduleAsync() 
        {
            return await AmortizationScheduleRepository.RunReposituryAsync(async()=> { return await AmortizationScheduleRepository.GetAllAmortizationScheduleAsync(); });
        }
    }
}
