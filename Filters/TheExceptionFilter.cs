using Microsoft.AspNetCore.Mvc.Filters;

namespace skm_back_dotnet.Filters
{
    public class TheExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<TheExceptionFilter> logger;
        public TheExceptionFilter(ILogger<TheExceptionFilter> logger)
        {
            this.logger = logger;

        }

        public override void OnException(ExceptionContext context)
        {
            logger.LogError(context.Exception, context.Exception.Message);
            base.OnException(context);
        }

    }
}