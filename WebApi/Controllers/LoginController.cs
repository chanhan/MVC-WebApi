using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.System;
using Service;
using Models.System.ViewModel;
using Common.ClassExpand;

namespace WebApi.Controllers
{
    public class LoginController : Controller
    {
        private WebApiContext db = new WebApiContext();
        private IService.IRepository<User, int> userRep = new Repository<User, int>();
        //
        // GET: /Login/
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                User user = userRep.GetAll().FirstOrDefault(r => r.UserName == userModel.UserName);
                if (user != null)
                {
                    this.ControllerContext.SetSession("UserInfo", user);
                    //   User u = this.ControllerContext.GetSession<User>("UserInfo");
                    return Redirect(Url.Action("Index", "Home"));
                }
            }
            return Redirect(Url.Action("Login", "Login"));
        }
        
        public ActionResult Logout()
        {
            this.ControllerContext.ClearSession();
            return Redirect(Url.Action("Login", "Login"));
        }
        //public ActionResult Index()
        //{
        //    return View(db.Users.ToList());
        //}

        ////
        //// GET: /Login/Details/5

        //public ActionResult Details(int id = 0)
        //{
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        ////
        //// GET: /Login/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /Login/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Users.Add(user);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(user);
        //}

        ////
        //// GET: /Login/Edit/5

        //public ActionResult Edit(int id = 0)
        //{
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        ////
        //// POST: /Login/Edit/5

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(user).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(user);
        //}

        ////
        //// GET: /Login/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        ////
        //// POST: /Login/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    User user = db.Users.Find(id);
        //    db.Users.Remove(user);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}