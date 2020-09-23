namespace FinantialCalculator.Domain.Common.Dtos.Entities
{
    using FinantialCalculator.Domain.Common.Enums;
    using System.Collections.Generic;

    public class AmortizationScheduleEntiti
    {
        //[Range(1, 999)]
        public decimal LoanAmount { get; set; }
        /// <summary>
        /// este campo es el interes anual que llega en el request
        /// </summary>
        public decimal AnnualInterest { get; set; }
        public uint NumberPayments { get; set; }
        public MethodTypeEnum Method { get; set; }
        public decimal TotalAmount { get; set; }
        public IList<PeriodEntiti> PeriodsList { get; set; }
    }
}
