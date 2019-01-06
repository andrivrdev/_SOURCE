﻿using System;
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
    public class PlantController : Controller
    {
        private MJEntities3 db = new MJEntities3();

        // GET: Plant
        public ActionResult Index()
        {
            var tblPlant = db.tblPlant.Include(t => t.tblGroup);
            return View(tblPlant.ToList());
        }

        // GET: Plant/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPlant tblPlant = db.tblPlant.Find(id);
            if (tblPlant == null)
            {
                return HttpNotFound();
            }
            return View(tblPlant);
        }

        // GET: Plant/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(db.tblGroup, "ID", "Name");
            return View();
        }

        // POST: Plant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,GroupID,Name,CreatedDateTime")] tblPlant tblPlant)
        {
            if (ModelState.IsValid)
            {
                db.tblPlant.Add(tblPlant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(db.tblGroup, "ID", "Name", tblPlant.GroupID);
            return View(tblPlant);
        }

        // GET: Plant/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPlant tblPlant = db.tblPlant.Find(id);
            if (tblPlant == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(db.tblGroup, "ID", "Name", tblPlant.GroupID);
            return View(tblPlant);
        }

        // POST: Plant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GroupID,Name,CreatedDateTime")] tblPlant tblPlant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPlant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.tblGroup, "ID", "Name", tblPlant.GroupID);
            return View(tblPlant);
        }

        // GET: Plant/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPlant tblPlant = db.tblPlant.Find(id);
            if (tblPlant == null)
            {
                return HttpNotFound();
            }
            return View(tblPlant);
        }

        // POST: Plant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tblPlant tblPlant = db.tblPlant.Find(id);
            db.tblPlant.Remove(tblPlant);
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
