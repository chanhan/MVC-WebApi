using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using Common.ClassExpand;

namespace Common.Filters
{
    public class CustomApiAuthorizationFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (!actionContext.Request.RequestUri.IsLoopback)
            {
                string ip = actionContext.Request.RequestUri.Authority;
                if (ip != "") actionContext.Response = actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, new Exception("没有权限"));
                else actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.OK);
            }
            else
            {
          //      actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.OK);
            }
        }
    }
}
