using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Text;
namespace Hotels_WebApi_AarshModi.AuthenticationFilters
{
    public class AuthenticationFilter : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
               
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string userName = decodedToken.Substring(0, decodedToken.IndexOf(":"));
                string userPassword = decodedToken.Substring(decodedToken.IndexOf(":") + 1);
                if(userName=="abcd" && userPassword == "1234")
                {
                    //Authorized
                }
                else
                {
                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}