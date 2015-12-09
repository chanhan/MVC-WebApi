using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Filter;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
      //  [CustAuthorizeAttribute(CustUser="Hello")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
