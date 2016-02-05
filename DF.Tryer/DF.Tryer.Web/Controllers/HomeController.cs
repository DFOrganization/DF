using DF.Tryer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DF.Tryer.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TryerEntities db = new TryerEntities();
            var user = new Sys_User() { ID = Guid.NewGuid().ToString(), LoginName = "llb", Birthday = DateTime.Now, Email = "llb0828@sina.com", Gender = 1, Mobile = "13902020202", Password = "123456", RealName = "李礼彬" };

            db.Sys_User.Add(user);
            db.SaveChanges();

            ViewBag.Count = db.Sys_User.Count();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}