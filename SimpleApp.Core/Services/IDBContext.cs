using System.Collections;
using System.Collections.Generic;
using SimpleApp.DataLayer.Model;

namespace SimpleApp.Core.Services
{
    public interface IDbContext
    {
        int GetRecordsCount();
    }
}