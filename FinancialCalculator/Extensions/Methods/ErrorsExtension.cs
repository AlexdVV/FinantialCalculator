namespace FinantialCalculator.Domain.Extensions.Methods
{
    using FinantialCalculator.Domain.Common.Dtos.Entities;
    using FluentValidation.Results;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class ErrorsExtension 
    {
        internal static TOut ToErrorEntiti<TIn, TOut>(this TIn validationResult) where TIn : ValidationResult where TOut : ErrorsEntiti
        {
            var response = (TOut)Activator.CreateInstance(typeof(TOut));
            var ValidationMessages = new List<string>();
            validationResult.Errors.ToList().ForEach(error => ValidationMessages.Add(error.ErrorMessage));

            response.Title = "something went wrong!!!!";
            response.Status = 400;
            response.Errors.Error = ValidationMessages.ToArray();

            return response;
        }
    }
}
