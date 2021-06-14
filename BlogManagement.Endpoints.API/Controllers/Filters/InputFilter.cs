using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlogManagement.Endpoints.API.Controllers.Filters
{
    public class InputFilter: IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public  void OnActionExecuting(ActionExecutingContext context)
        {
           var stringArgs = context.ActionArguments.Where(pair => pair.Value is string).ToList();

            foreach (var keyValue in stringArgs)
            {
                var safeValue = ((string)keyValue.Value).Replace("ي", "ی").Replace("ك", "ک");
                context.ActionArguments[keyValue.Key] = safeValue;
            }
    }
    }
}
