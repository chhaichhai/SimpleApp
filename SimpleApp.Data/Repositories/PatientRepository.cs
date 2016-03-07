using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using SimpleApp.DataLayer.Model;
using TrackerEnabledDbContext.Common.Models;

namespace SimpleApp.DataLayer.Repositories
{
    public class PatientRepository : IRepository<Patient>, IDisposable
    {
        private SimpleApp db = new SimpleApp();
        private readonly DbSet<Patient> _patients;

        public PatientRepository()
        {
            _patients = db.Patients;
        }

        public int GetRecordsCount()
        {
            return _patients.Count();
        }

        public Patient FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Add(Patient record)
        {
            throw new NotImplementedException();
        }

        public void Update(Patient record)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Patient> GetAllRecords()
        {
            throw new NotImplementedException();
        }

        public IQueryable<AuditLog> GetAuditLogsById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
