namespace FinantialCalculatorApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("AmortizationSchedule")]
    [ApiController]
    public class AmortizationScheduleController : ControllerBase
    {
        [HttpGet(Name = "GetAmortizationSchedule")]
        public ActionResult GetAmortizationSchedule()
        {
            return Ok(string.Empty);
        }
    }
}