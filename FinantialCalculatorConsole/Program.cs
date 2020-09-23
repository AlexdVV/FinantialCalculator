namespace FinantialCalculatorConsole
{
    using FinantialCalculator.Domain.Common.Dtos.Entities;
    using FinantialCalculator.Domain.Common.Dtos.Request;
    using FinantialCalculator.Domain.Common.Enums;
    using FinantialCalculator.Domain.Implementations;
    using System;
    using System.Linq;
    using TimeZoneConverter;

    class Program
    {
        static void Main(string[] args)
        {
            var utc = DateTime.Now;
            Console.WriteLine("UTC: "+utc);

            //var cst = TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
            var tzi = TZConvert.GetTimeZoneInfo("Mountain Standard Time (Mexico)");
            var tzi1 = TZConvert.GetTimeZoneInfo("America/New_York");
            Console.WriteLine("converted: "+TimeZoneInfo.ConvertTime(utc, tzi));

            Console.WriteLine("LINUX Format: "+tzi1);
            
            //var request = new AmortizationScheduleRequestDto
            //{
            //    AmortizationSchedule = new AmortizationScheduleEntiti()
            //    {
            //        LoanAmount = (decimal)25000.00,
            //        AnnualInterest = (decimal)8.25,
            //        NumberPayments = 12,
            //        Method = MethodTypeEnum.French
            //    }            
            //};

            //var response = new AmortizationScheduleDomain(request.AmortizationSchedule.Method).GetAmortizationSchedule(request);

            //response.AmortizationSchedule.PeriodsList.ToList().ForEach(period =>
            //{
            //    Console.WriteLine($"Periodo {period.NumPeriod}, Cuota de {period.Cuota}, intereses {period.Intereses}, saldo inicial {period.SaldoInicial}, saldo final {period.SaldoFinal}");
            //});

            Console.ReadKey();
        }
    }
}
