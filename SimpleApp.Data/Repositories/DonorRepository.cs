using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using SimpleApp.DataLayer.Model;
using TrackerEnabledDbContext.Common.Models;

namespace SimpleApp.DataLayer.Repositories
{
    public class DonorRepository : IRepository<Donor>, IDisposable
    {
        #region Private Members

        private readonly SimpleApp _simpleAppContext = new SimpleApp();
        private readonly DbSet<Donor> _donors;

        private bool _dispose;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DonorRepository()
        {
            _donors = _simpleAppContext.Donors;
        }

        #endregion

        #region Public Methods
        /// <summary>Return donor's count</summary>
        public int GetRecordsCount()
        {
            return _donors.Count();
        }

        /// <summary>
        /// Find Donor record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Donor FindById(int? id)
        {
            Donor donor = _donors.Find(id);
            if (donor == null)
            {
                throw new ArgumentNullException(nameof(donor));
            }
            return donor;
        }

        /// <summary>
        /// Add a new donor 
        /// </summary>
        /// <param name="donor"></param>
        public void Add(Donor donor)
        {
            _donors.Add(donor);
            _simpleAppContext.SaveChanges();
        }

        /// <summary>
        /// Update donor record
        /// </summary>
        /// <param name="donor"></param>
        public void Update(Donor donor)
        {
            _simpleAppContext.Entry(donor).State = EntityState.Modified;
            _simpleAppContext.SaveChanges();
        }

        /// <summary>
        /// Delete donor record based on id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int? id)
        {
            _donors.Remove(_donors.Find(id));
            _simpleAppContext.SaveChanges();
        }

        /// <summary>
        /// Return all donors
        /// </summary>
        /// <returns></returns>
        public IQueryable<Donor> GetAllRecords()
        {
            return _donors;
        }

        /// <summary>
        /// Get all audit logs by donor case id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<AuditLog> GetAuditLogsById(int? id)
        {
            return _simpleAppContext.GetLogs<Donor>(id);
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