namespace FinantialCalculator.Infrastructure.Extensions.ActionResult
{
    using Microsoft.AspNetCore.Mvc;

    internal sealed class InfrastructureController : ControllerBase
    {
        public override OkObjectResult Ok(object value)
        {
            return base.Ok(value);
        }
    }

    public static class IActionResultExtension
    {
        private static readonly InfrastructureController InfrastructureController = new InfrastructureController();

        public static IActionResult GetActionResult<TIn>(this TIn response, uint status) where TIn : class
        {
            switch (status)
            {
                case 200:
                    return InfrastructureController.Ok(response);
                case 400:
                    return InfrastructureController.BadRequest(response);
                case 404:
                    return InfrastructureController.NotFound(response);
                default:
                    return InfrastructureController.Forbid();
            }
        }
    }
}
