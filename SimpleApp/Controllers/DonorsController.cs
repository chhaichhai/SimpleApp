using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SimpleApp.Core.Services;
using SimpleApp.DataLayer.Model;
using SimpleApp.DataLayer.Repositories;
using SimpleApp.Models;
using SimpleApp.Ultilities;

namespace SimpleApp.Controllers
{
    [Authorize]
    public class DonorsController : Controller
    {
        #region Private Members

        private readonly IService<Donor> _donorService;

        #endregion

        #region Constructor

        public DonorsController(IService<Donor> donorService)
        {
            _donorService = donorService;
        }
        #endregion

        #region Index

        // GET: Donors
        public ActionResult Index()
        {
            return View(Mapper.Map<List<DonorVM>>(_donorService.GetAllRecords()));
        }

        #endregion

        #region Details

        // GET: Donors/Details/5
        public ActionResult Details(int? id)
        {
            return View(Mapper.Map<DonorVM>(_donorService.FindById(id)));
        }

        #endregion

        #region Create
        // GET: Donors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Donor donor)
        {
            if (ModelState.IsValid)
            {
                _donorService.Add(donor);
                return RedirectToAction(Constant.Actions.Index);
            }

            return View(Mapper.Map<DonorVM>(donor));
        }

        #endregion

        #region Edit
        // GET: Donors/Edit/5
        public ActionResult Edit(int? id)
        {
            return View(Mapper.Map<DonorVM>(_donorService.FindById(id)));
        }

        // POST: Donors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Donor donor)
        {
            if (ModelState.IsValid)
            {
                _donorService.Update(donor);
                return RedirectToAction(Constant.Actions.Index);
            }
            return View(Mapper.Map<DonorVM>(donor));
        }

        #endregion

        #region Delete

        // GET: Donors/Delete/5
        public ActionResult Delete(int? id)
        {
            return View(Mapper.Map<DonorVM>(_donorService.FindById(id)));
        }

        // POST: Donors/Delete/5
        [HttpPost, ActionName(Constant.Actions.Delete)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _donorService.Delete(id);
            return RedirectToAction(Constant.Actions.Index);
        }

        #endregion
    }
}
