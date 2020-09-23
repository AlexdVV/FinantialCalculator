namespace FinantialCalculator.Domain.Validations.AmortizationScheduleDomain
{
    using FinantialCalculator.Domain.Common.Dtos.Request;
    using FluentValidation;
    public class FrenchValidator : AbstractValidator<AmortizationScheduleRequestDto>
    {
        public FrenchValidator() 
        {
            RuleFor(RequestValidator => RequestValidator.AmortizationSchedule.LoanAmount)
                    //.Cascade(CascadeMode.StopOnFirstFailure)
                    .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0 but got {PropertyValue}");

            RuleFor(RequestValidator => RequestValidator.AmortizationSchedule.AnnualInterest)
                    .InclusiveBetween(5, 20).WithMessage("{PropertyName} should be between than 6-20 but got {PropertyValue}");

            RuleFor(RequestValidator => (int)RequestValidator.AmortizationSchedule.NumberPayments)
                    .InclusiveBetween(12, 240)
                    .WithMessage("{PropertyName} should be between than 12 - 240 but got {PropertyValue}");

            RuleFor(RequestValidator => RequestValidator.AmortizationSchedule.Method)
                    .IsInEnum().WithMessage("{PropertyName} should be an Enum but got {PropertyValue}");
        }
    }
}
