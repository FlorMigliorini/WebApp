using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProgrammersController : Controller
    {
        private AContext db = new AContext();

        // GET: Programmers
        public ActionResult Index()
        {
            return View(db.Programmers.ToList());
        }

        // GET: Programmers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programmer programmer = db.Programmers.Find(id);
            if (programmer == null)
            {
                return HttpNotFound();
            }
            return View(programmer);
        }

        // GET: Programmers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Programmers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProgrammerID,Name,Surname")] Programmer programmer)
        {
            if (ModelState.IsValid)
            {
                db.Programmers.Add(programmer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(programmer);
        }

        // GET: Programmers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programmer programmer = db.Programmers.Find(id);
            if (programmer == null)
            {
                return HttpNotFound();
            }
            return View(programmer);
        }

        // POST: Programmers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProgrammerID,Name,Surname")] Programmer programmer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programmer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(programmer);
        }

        // GET: Programmers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programmer programmer = db.Programmers.Find(id);
            if (programmer == null)
            {
                return HttpNotFound();
            }
            return View(programmer);
        }

        // POST: Programmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Programmer programmer = db.Programmers.Find(id);
            db.Programmers.Remove(programmer);
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
