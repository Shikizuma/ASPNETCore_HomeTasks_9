using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging.Abstractions;
using System.Xml;

namespace Task2.Infrastructure
{
    public class ActionLoggingFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerName = context.Controller.GetType().Name;
            var actionName = context.ActionDescriptor.RouteValues["action"];
            var timestamp = DateTime.Now;

            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine($"Action Method: {controllerName}.{actionName}, Time: {timestamp}");
            }
        }

    }
}
