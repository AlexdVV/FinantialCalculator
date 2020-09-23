namespace FinantialCalculator.Domain.Implementations
{
    using FinantialCalculator.Domain.Common.Dtos.Request;
    using FinantialCalculator.Domain.Common.Dtos.Response;
    using FinantialCalculator.Domain.Contracts.IDomainContracts;
    using FinantialCalculator.Domain.Contracts.ServiceContracts;
    using System;

    public class AmortizationScheduleMexicanDomain : IAmortizationScheduleDomain
    {
        public IAmortizationScheduleService DependenceInjection { get; set; }

        public AmortizationScheduleMexicanDomain(IAmortizationScheduleService dependenceInjection)
        {
            DependenceInjection = dependenceInjection;
        }

        public AmortizationScheduleResponseDto Calculate(AmortizationScheduleRequestDto request) 
        {
            var response = new AmortizationScheduleResponseDto();
            return response;
        }

        public uint Recalculate(uint price, uint tasa)
        {
            throw new NotImplementedException();
        }

        public uint ExtendTerm(uint price, uint termMounths, uint tasa)
        {
            throw new NotImplementedException();
        }
    }
}
