using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TakeOrDine.Models;
using TakeOrDine.Models.DB;

namespace TakeOrDine.Controllers
{
    public class hostsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: hosts
        public ActionResult Index()
        {
            return View(db.hosts.ToList());
        }

        // GET: hosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            host host = db.hosts.Find(id);
            if (host == null)
            {
                return HttpNotFound();
            }
            return View(host);
        }

        // GET: hosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: hosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HostId,Email,Name,specialityInCsv,Bio")] host host)
        {
            if (ModelState.IsValid)
            {
                db.hosts.Add(host);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(host);
        }

        // GET: hosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            host host = db.hosts.Find(id);
            if (host == null)
            {
                return HttpNotFound();
            }
            return View(host);
        }

        // POST: hosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HostId,Email,Name,specialityInCsv,Bio")] host host)
        {
            if (ModelState.IsValid)
            {
                db.Entry(host).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(host);
        }

        // GET: hosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            host host = db.hosts.Find(id);
            if (host == null)
            {
                return HttpNotFound();
            }
            return View(host);
        }

        // POST: hosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            host host = db.hosts.Find(id);
            db.hosts.Remove(host);
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
