namespace FinantialCalculator.Domain.Implementations
{
    using FinantialCalculator.Domain.Common.Enums;
    using FinantialCalculator.Domain.Contracts.IDomainContracts;
    using FinantialCalculator.Domain.Factory;
    using FinantialCalculator.Domain.Common.Dtos.Request;
    using FinantialCalculator.Domain.Common.Dtos.Response;
    using FinantialCalculator.Domain.Contracts.ServiceContracts;

    public sealed class AmortizationScheduleDomain 
    {
        private readonly IAmortizationScheduleDomain AmortizationScheduleContract;

        public AmortizationScheduleDomain(IAmortizationScheduleService dependenceInjection, MethodTypeEnum method)
        {
            AmortizationScheduleContract = method.GetAmortizationScheduleInstance(dependenceInjection);
        }

        public AmortizationScheduleResponseDto GetAmortizationSchedule(AmortizationScheduleRequestDto request)
        {          
            return AmortizationScheduleContract.Calculate(request);
        }

    }
}
