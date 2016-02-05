using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DF.Tryer.Model;

namespace DF.Tryer.Web.Areas.Admin.Controllers
{
    public class Sys_PageController : Controller
    {
        private TryerEntities db = new TryerEntities();

        // GET: Admin/Sys_Page
        public ActionResult Index()
        {
            return View(db.Sys_Page.ToList());
        }

        // GET: Admin/Sys_Page/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Page sys_Page = db.Sys_Page.Find(id);
            if (sys_Page == null)
            {
                return HttpNotFound();
            }
            return View(sys_Page);
        }

        // GET: Admin/Sys_Page/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sys_Page/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PageUrl,PageName,Sys_FuncID")] Sys_Page sys_Page)
        {
            if (ModelState.IsValid)
            {
                db.Sys_Page.Add(sys_Page);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sys_Page);
        }

        // GET: Admin/Sys_Page/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Page sys_Page = db.Sys_Page.Find(id);
            if (sys_Page == null)
            {
                return HttpNotFound();
            }
            return View(sys_Page);
        }

        // POST: Admin/Sys_Page/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PageUrl,PageName,Sys_FuncID")] Sys_Page sys_Page)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sys_Page).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sys_Page);
        }

        // GET: Admin/Sys_Page/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Page sys_Page = db.Sys_Page.Find(id);
            if (sys_Page == null)
            {
                return HttpNotFound();
            }
            return View(sys_Page);
        }

        // POST: Admin/Sys_Page/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sys_Page sys_Page = db.Sys_Page.Find(id);
            db.Sys_Page.Remove(sys_Page);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
