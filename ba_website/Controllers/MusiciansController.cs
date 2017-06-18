using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ba_website.database;
using ba_website.model;

namespace ba_website.Controllers
{
    public class MusiciansController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Musicians
        public ActionResult Index()
        {
            return View(db.Musicians.ToList());
        }

        // GET: Musicians/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musicians musicians = db.Musicians.Find(id);
            if (musicians == null)
            {
                return HttpNotFound();
            }
            return View(musicians);
        }

        // GET: Musicians/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Musicians/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastName,FirstName,Birthday,BirthPlace,StageName")] Musicians musicians)
        {
            if (ModelState.IsValid)
            {
                db.Musicians.Add(musicians);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(musicians);
        }

        // GET: Musicians/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musicians musicians = db.Musicians.Find(id);
            if (musicians == null)
            {
                return HttpNotFound();
            }
            return View(musicians);
        }

        // POST: Musicians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstName,Birthday,BirthPlace,StageName")] Musicians musicians)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musicians).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musicians);
        }

        // GET: Musicians/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musicians musicians = db.Musicians.Find(id);
            if (musicians == null)
            {
                return HttpNotFound();
            }
            return View(musicians);
        }

        // POST: Musicians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Musicians musicians = db.Musicians.Find(id);
            db.Musicians.Remove(musicians);
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
