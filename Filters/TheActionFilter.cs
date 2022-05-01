using Microsoft.AspNetCore.Mvc.Filters;

namespace skm_back_dotnet.Filters
{
    public class TheActionFilter : IActionFilter
    {
        private readonly ILogger<TheActionFilter> logger;
        public TheActionFilter(ILogger<TheActionFilter> logger)
        {
            this.logger = logger;

        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogWarning("Antes - OnActionExecuting");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogWarning("Depois - OnActionExecuted");
        }


    }
}