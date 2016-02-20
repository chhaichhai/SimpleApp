using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SimpleApp.Core.Services;
using SimpleApp.DataLayer.Model;

namespace SimpleApp.Core.Concrete
{
    public class PatientDbContext : IDbContext
    {
        private DataLayer.SimpleApp db = new DataLayer.SimpleApp();
        private readonly DbSet<Patient> _patients;

        public PatientDbContext()
        {
            _patients = db.Patients;
        }

        public List<Patient> GetDatabase()
        {
            return _patients.ToList();
        }
    }
}
