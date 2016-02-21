using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimpleApp.Core.Services;
using SimpleApp.DataLayer.Model;

namespace SimpleApp.Core.Concrete
{
    public class DonorDbContext : IDbContext
    {
        private DataLayer.SimpleApp db = new DataLayer.SimpleApp();
        private readonly DbSet<Donor> _donors;

        public DonorDbContext()
        {
            _donors = db.Donors;
        }

        public int GetRecordsCount()
        {
            return _donors.ToList().Count;
        }
    }
}