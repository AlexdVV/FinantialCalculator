namespace FinantialCalculator.Api.Controllers
{
    using Domain.Common.Dtos.Request;
    using Domain.Implementations;
    using FinantialCalculator.Domain.Contracts.ServiceContracts;
    using FinantialCalculator.Infrastructure.Extensions.ActionResult;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class AmortizationScheduleController : ControllerBase
    {
        private readonly IAmortizationScheduleService amortizationScheduleService;

        public AmortizationScheduleController(IAmortizationScheduleService dependenceInjection)
        {
            amortizationScheduleService = dependenceInjection;
        }

        [HttpPost("GetAmortizationSchedule")]
        public IActionResult GetAmortizationSchedule([FromBody] AmortizationScheduleRequestDto request)
        {
            var response = new AmortizationScheduleDomain(amortizationScheduleService, request.AmortizationSchedule.Method).GetAmortizationSchedule(request);

            return response.GetActionResult((uint)response.Status);
        }

        [HttpGet("GetAmortizationScheduleDB/{amortizationScheduleId}")]
        public async Task<IActionResult> GetDBAmortizationSchedule([FromRoute] int amortizationScheduleId)
        {
            var response = await amortizationScheduleService.GetAmortizationScheduleAsync((uint)amortizationScheduleId).ConfigureAwait(false);

            return Ok(response);
        }

        [HttpGet("GetAllAmortizationSchedule")]
        public async Task<IActionResult> GetAllAmortizationSchedule() 
        {
            var response = await amortizationScheduleService.GetAllAmortizationScheduleAsync().ConfigureAwait(false);
            return Ok(response);
        }
    }
}