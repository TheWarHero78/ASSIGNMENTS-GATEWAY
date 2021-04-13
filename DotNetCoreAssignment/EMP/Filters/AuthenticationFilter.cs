using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace EMP.MVC.Filters
{
    public  class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetString("Message") == null)
            {
                var redirectTargetDictionary = new RouteValueDictionary();
                redirectTargetDictionary.Add("action", "Login");
                redirectTargetDictionary.Add("controller", "Authentication");
                redirectTargetDictionary.Add("area", "");
                filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);
            }
            base.OnActionExecuting(filterContext);
        }

    }
}
