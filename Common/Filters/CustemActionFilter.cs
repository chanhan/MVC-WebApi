using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Common.ClassExpand;

namespace Common.Filters
{
    public class CustemActionFilter : ActionFilterAttribute
    { // 摘要: 
        //     在执行操作方法后由 ASP.NET MVC 框架调用。
        //
        // 参数: 
        //   filterContext:
        //     筛选器上下文。
        public override void OnActionExecuted(ActionExecutedContext filterContext) 
        {
            base.OnActionExecuted(filterContext);
        }
        //
        // 摘要: 
        //     在执行操作方法之前由 ASP.NET MVC 框架调用。
        //
        // 参数: 
        //   filterContext:
        //     筛选器上下文。
        public override void OnActionExecuting(ActionExecutingContext filterContext) 
        {
            Models.System.User user = filterContext.Controller.ControllerContext.GetSession<Models.System.User>("UserInfo");
            if (user == null) filterContext.Result = new RedirectResult("~/Login/Login");
        }
        //
        // 摘要: 
        //     在执行操作结果后由 ASP.NET MVC 框架调用。
        //
        // 参数: 
        //   filterContext:
        //     筛选器上下文。
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
        //
        // 摘要: 
        //     在执行操作结果之前由 ASP.NET MVC 框架调用。
        //
        // 参数: 
        //   filterContext:
        //     筛选器上下文。
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }
    }
}
