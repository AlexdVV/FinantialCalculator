namespace FinantialCalculator.Domain.Contracts.ServiceContracts
{
    using FinantialCalculator.Domain.Common.Dtos.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAmortizationScheduleService
    {
        Task<IList<AmortizationScheduleEntiti>> GetAllAmortizationScheduleAsync();
        Task<AmortizationScheduleEntiti> GetAmortizationScheduleAsync(uint amortizationScheduleId);
    }
}
