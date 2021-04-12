using Microsoft.AspNetCore.Mvc.Filters;

namespace Emp.WebAPI.Filter
{
    /// <summary>
    /// Class for adding extra header by extending IResultFilter
    /// </summary>
    public class HeaderFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add(
                "Name",
                "Aarsh");
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
        }
    }
}
