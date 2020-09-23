namespace FinantialCalculator.Domain.Contracts.IDomainContracts
{
    using FinantialCalculator.Domain.Common.Dtos.Request;
    using FinantialCalculator.Domain.Common.Dtos.Response;
    using FinantialCalculator.Domain.Contracts.ServiceContracts;

    internal interface IAmortizationScheduleDomain
    {
        IAmortizationScheduleService DependenceInjection { get; set; }
        AmortizationScheduleResponseDto Calculate(AmortizationScheduleRequestDto request);
        uint Recalculate(uint price, uint tasa);
        uint ExtendTerm(uint price, uint termMounths, uint tasa);
    }
}
