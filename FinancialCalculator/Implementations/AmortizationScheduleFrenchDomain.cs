namespace FinantialCalculator.Domain.Implementations
{
    using FinantialCalculator.Domain.Common.Dtos.Entities;
    using FinantialCalculator.Domain.Common.Dtos.Request;
    using FinantialCalculator.Domain.Common.Dtos.Response;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using FinantialCalculator.Domain.Common.CommonResources;
    using FinantialCalculator.Domain.Contracts.IDomainContracts;
    using FinantialCalculator.Domain.Validations.AmortizationScheduleDomain;
    using FluentValidation.Results;
    using FinantialCalculator.Domain.Extensions.Methods;
    using FinantialCalculator.Domain.Contracts.ServiceContracts;
    using System.Xml;

    internal class AmortizationScheduleFrenchDomain: IAmortizationScheduleDomain
    {
        public IAmortizationScheduleService DependenceInjection { get; set; }

        public AmortizationScheduleFrenchDomain(IAmortizationScheduleService dependenceInjection)
        {
            DependenceInjection = dependenceInjection;
        }

        public AmortizationScheduleResponseDto Calculate(AmortizationScheduleRequestDto request)
        {
            var response = new AmortizationScheduleResponseDto();

            var validator = new FrenchValidator();
            
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid) 
            {
                response = validationResult.ToErrorEntiti<ValidationResult, AmortizationScheduleResponseDto>();

                return response;
            }
            response.Status = 200;

            InitPeriods(ref response, request.AmortizationSchedule.NumberPayments);

            var previousPeriod = new PeriodEntiti();

            response.AmortizationSchedule.PeriodsList.ToList().ForEach(period =>
            {
                CalculatePeriod(ref period, request, previousPeriod);
                
                previousPeriod = period;
            });

            return response;
        }

        private void InitPeriods(ref AmortizationScheduleResponseDto response, uint NumberPayments) 
        {
            response.AmortizationSchedule = new AmortizationScheduleEntiti() {  PeriodsList = new List<PeriodEntiti>() };

            for (int iteration = 1; iteration <= NumberPayments; iteration++)
            {
                response.AmortizationSchedule.PeriodsList.Add(new PeriodEntiti() { NumPeriod = (uint) iteration });
            }    
        }

        private void CalculatePeriod(ref PeriodEntiti period, AmortizationScheduleRequestDto request, PeriodEntiti previousPeriod)
        {
            var interesMensual = (request.AmortizationSchedule.AnnualInterest / int.Parse(FinantialDefinitionsResource.Porcent)) / int.Parse(FinantialDefinitionsResource.MonthsInAYear);

            if (period.NumPeriod == int.Parse(FinantialDefinitionsResource.InitialPeriod))
            {
                previousPeriod.SaldoFinal = request.AmortizationSchedule.LoanAmount;

                var numberOne = int.Parse(FinantialDefinitionsResource.OneNumber);
                var baseNumber = (double)(numberOne + interesMensual);
                var pow = (decimal)Math.Pow(baseNumber, request.AmortizationSchedule.NumberPayments);

                previousPeriod.Cuota = request.AmortizationSchedule.LoanAmount * ((pow * interesMensual) / (pow - numberOne));
                
            }

            period.SaldoInicial = previousPeriod.SaldoFinal;
            period.Cuota = previousPeriod.Cuota;
            period.Intereses = period.SaldoInicial * interesMensual;           
            period.AbonoCapital = period.Cuota - period.Intereses;
            period.SaldoFinal = period.SaldoInicial - period.AbonoCapital;
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
