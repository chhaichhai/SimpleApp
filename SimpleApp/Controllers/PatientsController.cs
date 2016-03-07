using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using SimpleApp.Core.Services;
using SimpleApp.DataLayer.Model;
using SimpleApp.Models;
using SimpleApp.Ultilities;

namespace SimpleApp.Controllers
{
    [Authorize]
    public class PatientsController : Controller
    {
        #region Private Members

        private readonly IService<Patient> _patientService;

        #endregion

        #region Constructor

        public PatientsController(IService<Patient> patientService)
        {
            _patientService = patientService;
        }

        #endregion

        #region Index
        // GET: Patients
        public ActionResult Index()
        {
            return View(Mapper.Map<List<PatientVM>>(_patientService.GetAllRecords()));
        }

        #endregion

        #region Details
        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            return View(Mapper.Map<PatientVM>(_patientService.FindById(id)));
        }

        #endregion

        #region Create

        // GET: Patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _patientService.Add(patient);
                return RedirectToAction(Constant.Actions.Index);
            }

            return View(Mapper.Map<PatientVM>(patient));
        }

        #endregion

        #region Edit

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            return View(Mapper.Map<PatientVM>(_patientService.FindById(id)));
        }

        // POST: Patients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _patientService.Update(patient);
                return RedirectToAction(Constant.Actions.Index);
            }
            return View(Mapper.Map<PatientVM>(patient));
        }

        #endregion

        #region Delete

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            return View(Mapper.Map<PatientVM>(_patientService.FindById(id)));
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName(Constant.Actions.Delete)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _patientService.Delete(id);
            return RedirectToAction(Constant.Actions.Index);
        }

        #endregion
    }
}
