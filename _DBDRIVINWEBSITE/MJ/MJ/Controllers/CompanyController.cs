using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MJ.Models;

namespace MJ.Controllers
{
    public class CompanyController : Controller
    {
        private MJEntities3 db = new MJEntities3();

        // GET: Company
        public ActionResult Index()
        {
            return View(db.tblCompany.ToList());
        }

        // GET: Company/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCompany tblCompany = db.tblCompany.Find(id);
            if (tblCompany == null)
            {
                return HttpNotFound();
            }
            return View(tblCompany);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,CreatedDateTime")] tblCompany tblCompany)
        {
            if (ModelState.IsValid)
            {
                db.tblCompany.Add(tblCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblCompany);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCompany tblCompany = db.tblCompany.Find(id);
            if (tblCompany == null)
            {
                return HttpNotFound();
            }
            return View(tblCompany);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,CreatedDateTime")] tblCompany tblCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblCompany);
        }

        // GET: Company/Delete/5
        public ActionResult Delete(long? id)
        { 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCompany tblCompany = db.tblCompany.Find(id);
            if (tblCompany == null)
            {
                return HttpNotFound();
            }
            return View(tblCompany);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tblCompany tblCompany = db.tblCompany.Find(id);
            db.tblCompany.Remove(tblCompany);
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
