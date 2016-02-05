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
    public class Sys_FuncController : Controller
    {
        private TryerEntities db = new TryerEntities();

        // GET: Admin/Sys_Func
        public ActionResult Index()
        {
            return View(db.Sys_Func.ToList());
        }

        // GET: Admin/Sys_Func/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Func sys_Func = db.Sys_Func.Find(id);
            if (sys_Func == null)
            {
                return HttpNotFound();
            }
            return View(sys_Func);
        }

        // GET: Admin/Sys_Func/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sys_Func/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Sys_PageID,ParentID,FuncName,Description,IsAsc,IsDelete")] Sys_Func sys_Func)
        {
            if (ModelState.IsValid)
            {
                db.Sys_Func.Add(sys_Func);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sys_Func);
        }

        // GET: Admin/Sys_Func/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Func sys_Func = db.Sys_Func.Find(id);
            if (sys_Func == null)
            {
                return HttpNotFound();
            }
            return View(sys_Func);
        }

        // POST: Admin/Sys_Func/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Sys_PageID,ParentID,FuncName,Description,IsAsc,IsDelete")] Sys_Func sys_Func)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sys_Func).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sys_Func);
        }

        // GET: Admin/Sys_Func/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Func sys_Func = db.Sys_Func.Find(id);
            if (sys_Func == null)
            {
                return HttpNotFound();
            }
            return View(sys_Func);
        }

        // POST: Admin/Sys_Func/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sys_Func sys_Func = db.Sys_Func.Find(id);
            db.Sys_Func.Remove(sys_Func);
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
