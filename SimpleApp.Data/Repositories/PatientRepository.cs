using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using SimpleApp.DataLayer.Model;
using TrackerEnabledDbContext.Common.Models;

namespace SimpleApp.DataLayer.Repositories
{
    /// <summary>
    /// This class implements IRepository and IDisposable
    /// Provide data access to Patient repository
    /// </summary>
    public class PatientRepository : IRepository<Patient>, IDisposable
    {
        #region Private Members

        private readonly SimpleApp _simpleAppContext = new SimpleApp();
        private readonly DbSet<Patient> _patients;

        private bool _dispose;

        #endregion

        #region Constructor

        public PatientRepository()
        {
            _patients = _simpleAppContext.Patients;
        }

        #endregion

        #region Public Methods

        /// <summary>Return patient's count</summary>
        public int GetRecordsCount()
        {
            return _patients.Count();
        }

        /// <summary>
        /// Find Donor record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown when patient is null</exception>
        public Patient FindById(int? id)
        {
            Patient patient = _patients.Find(id);
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }
            return patient;
        }

        /// <summary>
        /// Add a new patient 
        /// </summary>
        /// <param name="patient"></param>
        public void Add(Patient patient)
        {
            _patients.Add(patient);
            _simpleAppContext.SaveChanges();
        }

        /// <summary>
        /// Update patient record
        /// </summary>
        /// <param name="patient"></param>
        public void Update(Patient patient)
        {
            _simpleAppContext.Entry(patient).State = EntityState.Modified;
            _simpleAppContext.SaveChanges();
        }

        /// <summary>
        /// Delete patient record based on id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int? id)
        {
            _patients.Remove(_patients.Find(id));
            _simpleAppContext.SaveChanges();
        }

        /// <summary>
        /// Return all patients
        /// </summary>
        /// <returns></returns>
        public IQueryable<Patient> GetAllRecords()
        {
            return _patients;
        }

        /// <summary>
        /// Get all audit logs by patient case id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<AuditLog> GetAuditLogsById(int? id)
        {
            return _simpleAppContext.GetLogs<Patient>(id);
        }

        #endregion

        #region Cleanup
        protected virtual void Dispose(bool disposing)
        {
            if (!_dispose)
            {
                if (disposing)
                    _simpleAppContext.Dispose();
            }
            _dispose = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
