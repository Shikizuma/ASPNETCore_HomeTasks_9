using Microsoft.AspNetCore.Mvc.Filters;

namespace ASPNETCore_HomeTasks_9.Infrastructure
{
    public class UniqueUserFilter : ActionFilterAttribute
    {
        private static HashSet<string> uniqueIps = new HashSet<string>();
        private static object lockObj = new object();
    
        public override void OnActionExecuted(ActionExecutedContext context)
        {

            var ip = context.HttpContext.Connection.RemoteIpAddress.ToString();
            lock (lockObj)
            {
                uniqueIps.Add(ip);
                StreamWriter streamWriter = new StreamWriter("App_Data/log.txt", true);
                streamWriter.WriteLine(uniqueIps.Count.ToString());
                streamWriter.Close();
            }
        }

    }
}
