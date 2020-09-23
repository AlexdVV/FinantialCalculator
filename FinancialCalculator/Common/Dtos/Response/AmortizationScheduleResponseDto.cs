namespace FinantialCalculator.Domain.Common.Dtos.Response
{
    using FinantialCalculator.Domain.Common.Dtos.Entities;

    public class AmortizationScheduleResponseDto: ErrorsEntiti
    {
        public AmortizationScheduleEntiti AmortizationSchedule { get; set; }
    }
}
