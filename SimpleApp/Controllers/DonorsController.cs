﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SimpleApp.DataLayer.Model;
using SimpleApp.Models;
using SimpleApp.Ultilities;

namespace SimpleApp.Controllers
{
    [Authorize]
    public class DonorsController : Controller
    {
        private DataLayer.SimpleApp db = new DataLayer.SimpleApp();

        // GET: Donors
        public ActionResult Index()
        {
            return View(Mapper.Map<List<DonorVM>>(db.Donors.ToList()));
        }

        // GET: Donors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);

            if (donor == null)
            {
                return HttpNotFound();
            }
            donor.AuditLogs = db.AuditLog.Where(i => i.RecordId == donor.Id.ToString()).OrderByDescending(x => x.EventDateUTC).ToList();

            return View(Mapper.Map<DonorVM>(donor));
        }

        // GET: Donors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Donor donor)
        {
            if (ModelState.IsValid)
            {
                db.Donors.Add(donor);
                db.SaveChanges();
                return RedirectToAction(Constant.Actions.Index);
            }

            return View(Mapper.Map<DonorVM>(donor));
        }

        // GET: Donors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<DonorVM>(donor));
        }

        // POST: Donors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Donor donor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(Constant.Actions.Index);
            }
            return View(Mapper.Map<DonorVM>(donor));
        }

        // GET: Donors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<DonorVM>(donor));
        }

        // POST: Donors/Delete/5
        [HttpPost, ActionName(Constant.Actions.Delete)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donor donor = db.Donors.Find(id);
            db.Donors.Remove(donor);
            db.SaveChanges();
            return RedirectToAction(Constant.Actions.Index);
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
