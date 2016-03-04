using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using SimpleApp.DataLayer.Model;

namespace SimpleApp.DataLayer.Repositories
{
    public class PatientRepository : IRepository
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
    }
}
