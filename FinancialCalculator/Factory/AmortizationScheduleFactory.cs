namespace FinantialCalculator.Domain.Factory
{
    using FinantialCalculator.Domain.Common.Enums;
    using FinantialCalculator.Domain.Contracts.IDomainContracts;
    using FinantialCalculator.Domain.Contracts.ServiceContracts;
    using FinantialCalculator.Domain.Implementations;
    using System;

    internal static class AmortizationScheduleFactory
    {
        public static IAmortizationScheduleDomain GetAmortizationScheduleInstance(this MethodTypeEnum method, IAmortizationScheduleService dependenceInjection)
        {
            switch (method) 
            {
                case MethodTypeEnum.French:
                    return new AmortizationScheduleFrenchDomain(dependenceInjection);
                case MethodTypeEnum.Germany:
                    return new AmortizationScheduleGermanyDomain(dependenceInjection);
                case MethodTypeEnum.Mexican:
                    return new AmortizationScheduleMexicanDomain(dependenceInjection);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
