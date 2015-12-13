using Common.Filters;
using Common.ModelBinder;
using IService;
using Models.System;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Controllers
{
    [CustemActionFilter]
    public class HomeController : Controller
    {
        IRepository<User, int> rep = new Repository<User, int>();

        [CustemAuthorizeAttributeFilter]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AllUser([ModelBinder(typeof(UserBinder))]User user)
       // public ActionResult AllUser(User user)

        {
            rep.Add(user);
            return new RedirectResult(Url.Action("ShowUser", "Home", new { id=user.ID}));
        }

        public ActionResult ShowUser(int id)
        {
           User user= rep.Get(id);
           return View(user);
        }
        public ActionResult UserList()
        {
            IList<User> list = new List<User>();
            UpdateModel(list);
            return View(list);
        }
        public ActionResult UpdateUser()
        {
            User user = new User();
            UpdateModel(user);
            return View();
        }

        public ActionResult Error() 
        {
            return View();
        }
    }
}
