using IService;
using Models.System;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Common.ClassExpand;

namespace Common.Filters
{
    public class CustemAuthorizeAttributeFilter : AuthorizeAttribute
    {
        private AreaControllerAction areaControllerAction;
        private User user;
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null) return false;
                //throw new ArgumentNullException("HttpContext", "HTTP请求为空");
            if (user == null) return false;
                //throw new ArgumentNullException("User", "用户信息为空");
            return user.Level >= areaControllerAction.Level;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            //string actionName = filterContext.ActionDescriptor.ActionName;
            areaControllerAction = new AreaControllerAction()
            {
                Area = filterContext.RouteData.DataTokens["area"] == null ? null : filterContext.RouteData.DataTokens["area"].ToString(),
                Controller = filterContext.RouteData.Values["controller"].ToString(),
                Action = filterContext.RouteData.Values["action"].ToString()
            };
            areaControllerAction.Level = GetLevel(areaControllerAction);
            user = filterContext.Controller.ControllerContext.GetSession<User>("UserInfo");
            base.OnAuthorization(filterContext);
         }

        //
        // 摘要: 
        //     处理未能授权的 HTTP 请求。
        //
        // 参数: 
        //   filterContext:
        //     封装有关使用 System.Web.Mvc.AuthorizeAttribute 的信息。filterContext 对象包括控制器、HTTP 上下文、请求上下文、操作结果和路由数据。
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //filterContext.HttpContext.Response.Redirect("~/Home/Error");
            ContentResult result = new ContentResult();
             result.Content = "<script>alert('Unauthorized')</script>";
             filterContext.Result = result;
          //  filterContext.Controller.ViewBag.msg = "没有权限";
          //  result.ExecuteResult(filterContext.Controller.ControllerContext);
          //  filterContext.Result = new RedirectResult("~/Home/Msg?msg=没有权限");// new JavaScriptResult();
        }
        private int GetLevel(AreaControllerAction areaControllerAction)
        {
            IRepository<AreaControllerAction, int> rep = new Repository<AreaControllerAction, int>();
            AreaControllerAction aCA = rep.GetAll().FirstOrDefault(p => p.Action == areaControllerAction.Action && p.Controller == areaControllerAction.Controller && string.IsNullOrEmpty(areaControllerAction.Area) ? true : p.Area == areaControllerAction.Area);
            return aCA == null ? 0 : aCA.Level;
        }
    }
}
