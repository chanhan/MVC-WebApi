using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Common.Filters
{
    public class CustemHandleErrorFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext) 
        {
            filterContext.Exception.Message.ToString();
        }
    }
}
