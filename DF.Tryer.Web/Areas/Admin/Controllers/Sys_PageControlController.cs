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
    public class Sys_PageControlController : Controller
    {
        private TryerEntities db = new TryerEntities();

        // GET: Admin/Sys_PageControl
        public ActionResult Index()
        {
            return View(db.Sys_PageControl.ToList());
        }

        // GET: Admin/Sys_PageControl/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_PageControl sys_PageControl = db.Sys_PageControl.Find(id);
            if (sys_PageControl == null)
            {
                return HttpNotFound();
            }
            return View(sys_PageControl);
        }

        // GET: Admin/Sys_PageControl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sys_PageControl/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ControlName,PageUrl,PageControlID,Description")] Sys_PageControl sys_PageControl)
        {
            if (ModelState.IsValid)
            {
                db.Sys_PageControl.Add(sys_PageControl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sys_PageControl);
        }

        // GET: Admin/Sys_PageControl/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_PageControl sys_PageControl = db.Sys_PageControl.Find(id);
            if (sys_PageControl == null)
            {
                return HttpNotFound();
            }
            return View(sys_PageControl);
        }

        // POST: Admin/Sys_PageControl/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ControlName,PageUrl,PageControlID,Description")] Sys_PageControl sys_PageControl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sys_PageControl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sys_PageControl);
        }

        // GET: Admin/Sys_PageControl/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_PageControl sys_PageControl = db.Sys_PageControl.Find(id);
            if (sys_PageControl == null)
            {
                return HttpNotFound();
            }
            return View(sys_PageControl);
        }

        // POST: Admin/Sys_PageControl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sys_PageControl sys_PageControl = db.Sys_PageControl.Find(id);
            db.Sys_PageControl.Remove(sys_PageControl);
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
