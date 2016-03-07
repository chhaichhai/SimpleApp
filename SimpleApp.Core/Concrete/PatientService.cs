using System;
using System.Collections.Generic;
using System.Linq;
using SimpleApp.Core.Services;
using SimpleApp.DataLayer.Model;
using SimpleApp.DataLayer.Repositories;
using TrackerEnabledDbContext.Common.Models;

namespace SimpleApp.Core.Concrete
{
    /// <summary>
    /// This class implements IService to provide communication to the Patient repository
    /// </summary>
    public class PatientService : IService<Patient>
    {
        #region Private Members

        private readonly IRepository<Patient> _patientRepository;

        #endregion

        #region Constructor
            
        public PatientService(IRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add a new patient 
        /// </summary>
        /// <param name="patient"></param>
        /// <exception cref="ArgumentNullException">Thrown when patient is null</exception>
        public void Add(Patient patient)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));

            _patientRepository.Add(patient);
        }

        /// <summary>
        /// Delete patient record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException">Thrown when id is null</exception>
        public void Delete(int? id)
        {
            if (id == null) throw new ArgumentNullException("Unable to remove " + nameof(id));
            _patientRepository.Delete(id);
        }

        /// <summary>
        /// Find patient record by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown when id is null</exception>
        public Patient FindById(int? id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            var patient = _patientRepository.FindById(id);

            //Retrieve audit logs for the donor case
            patient.AuditLogs = _patientRepository.GetAuditLogsById(id).ToList();

            return patient;
        }

        /// <summary>
        /// Return all patients
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Patient> GetAllRecords()
        {
            return _patientRepository.GetAllRecords().ToList();
        }

        /// <summary>
        /// Return all audit logs by patient case id
        /// Throw ArgumentNullException if null Id or null donor case
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown when id is null</exception>
        /// <exception cref="ArgumentNullException">Thrown when patient is null</exception>
        public IEnumerable<AuditLog> GetAuditLogsById(int? id)
        {
            //Null id
            if (id == null) throw new ArgumentNullException(nameof(id));

            var patient = FindById(id);

            //Null donor
            if (patient == null) throw new ArgumentNullException(nameof(patient));

            //Return the query as list
            return _patientRepository.GetAuditLogsById(id).ToList();
        }

        /// <summary>Return patient's count</summary>
        public int GetRecordsCount()
        {
            return _patientRepository.GetRecordsCount();
        }

        /// <summary>
        /// Update patient record
        /// </summary>
        /// <param name="patient"></param>
        /// <exception cref="ArgumentNullException">Thrown when patient is null</exception>
        public void Update(Patient patient)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));

            _patientRepository.Update(patient);
        }

        #endregion
    }
}