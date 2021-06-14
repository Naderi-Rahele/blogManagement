using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BlogManagement.Endpoints.API.Controllers.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogInformation(context.Exception.ToString());
            context.Result =  new ObjectResult(new {friendlyMessage= "خطا! لطفا با پشتیبانی تماس بگیرید"});
        }
    }
}