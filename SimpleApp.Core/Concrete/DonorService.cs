using System;
using System.Collections.Generic;
using System.Linq;
using SimpleApp.Core.Services;
using SimpleApp.DataLayer.Model;
using SimpleApp.DataLayer.Repositories;
using TrackerEnabledDbContext.Common.Models;

namespace SimpleApp.Core.Concrete
{
    public class DonorService : IService<Donor>
    {
        #region Private Members

        private readonly IRepository<Donor> _donorRepository;

        #endregion

        #region Constructor
        public DonorService(IRepository<Donor> donorRepository)
        {
            _donorRepository = donorRepository;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add a new donor 
        /// </summary>
        /// <param name="donor"></param>
        public void Add(Donor donor)
        {
            if(donor == null) throw new ArgumentNullException(nameof(donor));

            _donorRepository.Add(donor);
        }

        /// <summary>
        /// Update donor record
        /// </summary>
        /// <param name="donor"></param>
        public void Update(Donor donor)
        {
            if (donor == null) throw new ArgumentNullException(nameof(donor));

            _donorRepository.Update(donor);
        }

        /// <summary>
        /// Delete donor record based on id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int? id)
        {
            if(id == null) throw new ArgumentNullException("Unable to remove " + nameof(id));
            _donorRepository.Delete(id);
        }

        /// <summary>Return donor's count</summary>
        public int GetRecordsCount()
        {
            return _donorRepository.GetRecordsCount();
        }

        /// <summary>
        /// Find donor record by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Donor FindById(int? id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            var donor = _donorRepository.FindById(id);

            //Retrieve audit logs for the donor case
            donor.AuditLogs = _donorRepository.GetAuditLogsById(id).ToList();

            return donor;
        }

        /// <summary>
        /// Return all donors
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Donor> GetAllRecords()
        {
            return _donorRepository.GetAllRecords().ToList();
        }

        /// <summary>
        /// Return all audit logs by donor case id
        /// Throw Argument Null Exception if null Id or null donor case
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<AuditLog> GetAuditLogsById(int? id)
        {
            //Null id
            if (id == null) throw new ArgumentNullException(nameof(id));
            
            var donor = FindById(id);

            //Null donor
            if (donor == null) throw new ArgumentNullException(nameof(donor));
            
            return _donorRepository.GetAuditLogsById(id).ToList();
        }

        #endregion
    }
}