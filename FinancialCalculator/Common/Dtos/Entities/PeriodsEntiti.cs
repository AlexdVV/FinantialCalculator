namespace FinantialCalculator.Domain.Common.Dtos.Entities
{
    public class PeriodEntiti
    {
        public uint NumPeriod { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal Cuota { get; set; }
        public decimal Intereses { get; set; }
        public decimal AbonoCapital { get; set; }
        public decimal SaldoFinal { get; set; }
    }
}
