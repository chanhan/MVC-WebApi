using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Filter
{
    public class CustAuthorizeAttribute : AuthorizeAttribute
    {
        public string CustUser { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            User user = httpContext.Session["user"] as User;
            if (user != null)
            {
                return user.UserName == CustUser;
            }
            return base.AuthorizeCore(httpContext);
        }

    }
}