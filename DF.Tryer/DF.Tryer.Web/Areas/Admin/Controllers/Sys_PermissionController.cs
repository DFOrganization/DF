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
    public class Sys_PermissionController : Controller
    {
        private TryerEntities db = new TryerEntities();

        // GET: Admin/Sys_Permission
        public ActionResult Index()
        {
            return View(db.Sys_Permission.ToList());
        }

        // GET: Admin/Sys_Permission/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Permission sys_Permission = db.Sys_Permission.Find(id);
            if (sys_Permission == null)
            {
                return HttpNotFound();
            }
            return View(sys_Permission);
        }

        // GET: Admin/Sys_Permission/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sys_Permission/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PermissionName,Description")] Sys_Permission sys_Permission)
        {
            if (ModelState.IsValid)
            {
                db.Sys_Permission.Add(sys_Permission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sys_Permission);
        }

        // GET: Admin/Sys_Permission/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Permission sys_Permission = db.Sys_Permission.Find(id);
            if (sys_Permission == null)
            {
                return HttpNotFound();
            }
            return View(sys_Permission);
        }

        // POST: Admin/Sys_Permission/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PermissionName,Description")] Sys_Permission sys_Permission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sys_Permission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sys_Permission);
        }

        // GET: Admin/Sys_Permission/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Permission sys_Permission = db.Sys_Permission.Find(id);
            if (sys_Permission == null)
            {
                return HttpNotFound();
            }
            return View(sys_Permission);
        }

        // POST: Admin/Sys_Permission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sys_Permission sys_Permission = db.Sys_Permission.Find(id);
            db.Sys_Permission.Remove(sys_Permission);
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
