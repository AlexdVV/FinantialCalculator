namespace FinantialCalculator.Domain.Validations
{
    using FinantialCalculator.Domain.Common.Dtos.Request;
    using FluentValidation;
    public class AmortizationScheduleRequestValidator : AbstractValidator<AmortizationScheduleRequestDto>
    {
        public AmortizationScheduleRequestValidator()
        {
            RuleFor(RequestValidator => RequestValidator.AmortizationSchedule.LoanAmount)
                //.Cascade(CascadeMode.StopOnFirstFailure)
                .GreaterThan(0)
                .WithMessage("{PropertyName} should be greater than 0 but got {PropertyValue}");

            RuleFor(RequestValidator => RequestValidator.AmortizationSchedule.AnnualInterest)
                .ExclusiveBetween(1, 100).WithMessage("{PropertyName} should be between than 0 - 100 but got {PropertyValue}");

            RuleFor(RequestValidator => (int) RequestValidator.AmortizationSchedule.NumberPayments)
                .ExclusiveBetween(1,100)
                .WithMessage("{PropertyName} should be between than 0 - 100 but got {PropertyValue}");

            RuleFor(RequestValidator => RequestValidator.AmortizationSchedule.Method)
                .IsInEnum().WithMessage("{PropertyName} should be an Enum but got {PropertyValue}");
        }
    }
}
