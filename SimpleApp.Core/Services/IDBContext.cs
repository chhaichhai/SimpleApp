using System.Collections.Generic;
using SimpleApp.DataLayer.Model;

namespace SimpleApp.Core.Services
{
    public interface IDbContext
    {
        List<Patient> GetDatabase();
    }
}