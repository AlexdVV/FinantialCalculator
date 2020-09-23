namespace FinantialCalculator.Domain.Common.Dtos.Entities
{
    public class Errors
    {
        public string[] Error { get; set; }
    }

    public class ErrorsEntiti
    {
        public Errors Errors { get; set; } = new Errors();
        public string Title { get; set; }
        public int Status { get; set; }
        public string TraceId { get; set; }
    }
}
