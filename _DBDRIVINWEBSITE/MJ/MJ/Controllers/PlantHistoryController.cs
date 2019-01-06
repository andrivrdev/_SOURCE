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
    public class PlantHistoryController : Controller
    {
        private MJEntities3 db = new MJEntities3();

        // GET: PlantHistory
        public ActionResult Index()
        {
            var tblPlantHistory = db.tblPlantHistory.Include(t => t.tblEvent).Include(t => t.tblPlant);
            return View(tblPlantHistory.ToList());
        }

        // GET: PlantHistory/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPlantHistory tblPlantHistory = db.tblPlantHistory.Find(id);
            if (tblPlantHistory == null)
            {
                return HttpNotFound();
            }
            return View(tblPlantHistory);
        }

        // GET: PlantHistory/Create
        public ActionResult Create()
        {
            ViewBag.EventCategoryID = new SelectList(db.tblEventCategory, "ID", "Name");
            ViewBag.EventID = new SelectList(db.tblEvent, "ID", "Name");
            ViewBag.PlantID = new SelectList(db.tblPlant, "ID", "Name");
            return View();
        }

        // POST: PlantHistory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PlantID,EventID,Data,EventDateTime,CreatedDateTime")] tblPlantHistory tblPlantHistory)
        {
            if (ModelState.IsValid)
            {
                db.tblPlantHistory.Add(tblPlantHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventID = new SelectList(db.tblEvent, "ID", "Name", tblPlantHistory.EventID);
            ViewBag.PlantID = new SelectList(db.tblPlant, "ID", "Name", tblPlantHistory.PlantID);
            return View(tblPlantHistory);
        }

        // GET: PlantHistory/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPlantHistory tblPlantHistory = db.tblPlantHistory.Find(id);
            if (tblPlantHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventID = new SelectList(db.tblEvent, "ID", "Name", tblPlantHistory.EventID);
            ViewBag.PlantID = new SelectList(db.tblPlant, "ID", "Name", tblPlantHistory.PlantID);
            return View(tblPlantHistory);
        }

        // POST: PlantHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PlantID,EventID,Data,EventDateTime,CreatedDateTime")] tblPlantHistory tblPlantHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPlantHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.tblEvent, "ID", "Name", tblPlantHistory.EventID);
            ViewBag.PlantID = new SelectList(db.tblPlant, "ID", "Name", tblPlantHistory.PlantID);
            return View(tblPlantHistory);
        }

        // GET: PlantHistory/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPlantHistory tblPlantHistory = db.tblPlantHistory.Find(id);
            if (tblPlantHistory == null)
            {
                return HttpNotFound();
            }
            return View(tblPlantHistory);
        }

        // POST: PlantHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tblPlantHistory tblPlantHistory = db.tblPlantHistory.Find(id);
            db.tblPlantHistory.Remove(tblPlantHistory);
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
