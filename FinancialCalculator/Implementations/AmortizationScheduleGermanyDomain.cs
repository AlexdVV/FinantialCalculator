namespace FinantialCalculator.Domain.Implementations
{
    using FinantialCalculator.Domain.Common.CommonResources;
    using FinantialCalculator.Domain.Common.Dtos.Entities;
    using FinantialCalculator.Domain.Common.Dtos.Request;
    using FinantialCalculator.Domain.Common.Dtos.Response;
    using FinantialCalculator.Domain.Contracts.IDomainContracts;
    using FinantialCalculator.Domain.Contracts.ServiceContracts;
    using FinantialCalculator.Domain.Extensions.Methods;
    using FinantialCalculator.Domain.Validations.AmortizationScheduleDomain;
    using FluentValidation.Results;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class AmortizationScheduleGermanyDomain: IAmortizationScheduleDomain
    {
        public IAmortizationScheduleService DependenceInjection { get; set; }

        public AmortizationScheduleGermanyDomain(IAmortizationScheduleService dependenceInjection)
        {
            DependenceInjection = dependenceInjection;
        }

        public AmortizationScheduleResponseDto Calculate(AmortizationScheduleRequestDto request)
        {
            var response = new AmortizationScheduleResponseDto();

            var validator = new GermanyValidator();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                response = validationResult.ToErrorEntiti<ValidationResult, AmortizationScheduleResponseDto>();

                return response;
            }
            response.Status = 200;

            InitPeriods( ref response, request.AmortizationSchedule.NumberPayments);

            var previousPeriod = new PeriodEntiti();

            response.AmortizationSchedule.PeriodsList.ToList().ForEach(period=>
            {
                CalculatePeriod(ref period, request, previousPeriod);

                previousPeriod = period;
            });

            return response;
        }

        private void InitPeriods(ref AmortizationScheduleResponseDto response, uint NumberPayments) 
        {
            response.AmortizationSchedule = new AmortizationScheduleEntiti() { PeriodsList = new List<PeriodEntiti>() };
            for (int iteration = 1; iteration <= NumberPayments; iteration++)
            {
                response.AmortizationSchedule.PeriodsList.Add(new PeriodEntiti() { NumPeriod = (uint)iteration });
            }
        }

        private void CalculatePeriod(ref PeriodEntiti period, AmortizationScheduleRequestDto request, PeriodEntiti previousPeriod)
        {
            var interesMensual = (request.AmortizationSchedule.AnnualInterest / int.Parse(FinantialDefinitionsResource.Porcent)) / int.Parse(FinantialDefinitionsResource.MonthsInAYear);

            if (period.NumPeriod == int.Parse(FinantialDefinitionsResource.InitialPeriod))
            {
                previousPeriod.SaldoFinal = request.AmortizationSchedule.LoanAmount;
                previousPeriod.AbonoCapital= request.AmortizationSchedule.LoanAmount / request.AmortizationSchedule.NumberPayments;
                period.Intereses = Math.Truncate( 100 * (previousPeriod.SaldoFinal * interesMensual) ) / 100;
            }

            period.SaldoInicial = previousPeriod.SaldoFinal;
            period.Intereses = Math.Truncate(100 * (period.SaldoInicial* interesMensual)) / 100;
            period.AbonoCapital = Math.Truncate(100 * (previousPeriod.AbonoCapital)) / 100;
            period.Cuota = Math.Truncate(100 * (period.Intereses + period.AbonoCapital)) / 100;
            period.SaldoFinal = period.SaldoInicial - previousPeriod.AbonoCapital;
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
