using System.Data.Entity;
using System.Linq;
using SimpleApp.DataLayer.Model;

namespace SimpleApp.DataLayer.Repositories
{
    public class DonorRepository : IRepository
    {
        private DataLayer.SimpleApp db = new DataLayer.SimpleApp();
        private readonly DbSet<Donor> _donors;

        public DonorRepository()
        {
            _donors = db.Donors;
        }

        /// <summary>Return donor's count</summary>
        public int GetRecordsCount()
        {
            return _donors.Count();
        }
    }
}