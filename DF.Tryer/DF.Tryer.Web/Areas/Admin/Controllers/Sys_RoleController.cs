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
    public class Sys_RoleController : Controller
    {
        private TryerEntities db = new TryerEntities();

        // GET: Admin/Sys_Role
        public ActionResult Index()
        {
            return View(db.Sys_Role.ToList());
        }

        // GET: Admin/Sys_Role/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Role sys_Role = db.Sys_Role.Find(id);
            if (sys_Role == null)
            {
                return HttpNotFound();
            }
            return View(sys_Role);
        }

        // GET: Admin/Sys_Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sys_Role/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RoleName,Description")] Sys_Role sys_Role)
        {
            if (ModelState.IsValid)
            {
                db.Sys_Role.Add(sys_Role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sys_Role);
        }

        // GET: Admin/Sys_Role/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Role sys_Role = db.Sys_Role.Find(id);
            if (sys_Role == null)
            {
                return HttpNotFound();
            }
            return View(sys_Role);
        }

        // POST: Admin/Sys_Role/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RoleName,Description")] Sys_Role sys_Role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sys_Role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sys_Role);
        }

        // GET: Admin/Sys_Role/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Role sys_Role = db.Sys_Role.Find(id);
            if (sys_Role == null)
            {
                return HttpNotFound();
            }
            return View(sys_Role);
        }

        // POST: Admin/Sys_Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sys_Role sys_Role = db.Sys_Role.Find(id);
            db.Sys_Role.Remove(sys_Role);
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
