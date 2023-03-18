using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace MJ.Controllers
{
    public class GroupController : Controller
    {
        

        // GET: Group
        public ActionResult Index()
        {

            SHARED.DATA.tblGroup tblGroup = new SHARED.DATA.tblGroup();
            //tblGroup.ieGroup.In . Include(t => t.tblCompany);
            tblGroup.LoadData();
            return View(tblGroup.ieGroup);
        }

        // GET: Group/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGroup tblGroup = db.tblGroup.Find(id);
            if (tblGroup == null)
            {
                return HttpNotFound();
            }
            return View(tblGroup);
        }

        // GET: Group/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.tblCompany, "ID", "Name");
            return View();
        }

        // POST: Group/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyID,Name,Description,CreatedDateTime")] tblGroup tblGroup)
        {
            if (ModelState.IsValid)
            {
                db.tblGroup.Add(tblGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.tblCompany, "ID", "Name", tblGroup.CompanyID);
            return View(tblGroup);
        }

        // GET: Group/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGroup tblGroup = db.tblGroup.Find(id);
            if (tblGroup == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.tblCompany, "ID", "Name", tblGroup.CompanyID);
            return View(tblGroup);
        }

        // POST: Group/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyID,Name,Description,CreatedDateTime")] tblGroup tblGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.tblCompany, "ID", "Name", tblGroup.CompanyID);
            return View(tblGroup);
        }

        // GET: Group/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGroup tblGroup = db.tblGroup.Find(id);
            if (tblGroup == null)
            {
                return HttpNotFound();
            }
            return View(tblGroup);
        }

        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tblGroup tblGroup = db.tblGroup.Find(id);
            db.tblGroup.Remove(tblGroup);
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
