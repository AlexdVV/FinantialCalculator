namespace FinantialCalculator.Domain.Validations.AmortizationScheduleDomain
{
    using FinantialCalculator.Domain.Common.Dtos.Request;
    using FluentValidation;

    class GermanyValidator : AbstractValidator<AmortizationScheduleRequestDto>
    {
        public GermanyValidator() 
        {
            RuleFor(RequestValidator => RequestValidator.AmortizationSchedule.LoanAmount)
              //.Cascade(CascadeMode.StopOnFirstFailure)
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0 but got {PropertyValue}");

            RuleFor(RequestValidator => RequestValidator.AmortizationSchedule.AnnualInterest)
                .InclusiveBetween(10, 30).WithMessage("{PropertyName} should be between than 10 - 30 but got {PropertyValue}");

            RuleFor(RequestValidator => (int)RequestValidator.AmortizationSchedule.NumberPayments)
                .InclusiveBetween(3, 60)
                .WithMessage("{PropertyName} should be between than 3 - 60 but got {PropertyValue}");

            RuleFor(RequestValidator => RequestValidator.AmortizationSchedule.Method)
                .IsInEnum().WithMessage("{PropertyName} should be an Enum but got {PropertyValue}");
        }
    }
}
