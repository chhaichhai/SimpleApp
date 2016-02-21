using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using SimpleApp.Core.Concrete;
using SimpleApp.Core.Services;

namespace SimpleApp.Controllers
{
    [Authorize]
    public class StatHub : Hub
    {
        public void GetPatientStat()
        {
            IDbContext patientDb = new PatientDbContext();
            Clients.All.loadStatNumber(patientDb.GetRecordsCount());
        }
        public void GetDonorStat()
        {
            IDbContext donorDb = new DonorDbContext();
            Clients.All.loadStatNumber(donorDb.GetRecordsCount());
        }

        public override Task OnConnected()
        {
            IDbContext patientDb = new PatientDbContext();
            IDbContext donorDb = new DonorDbContext();

            Clients.All.loadPatientStatNumber(patientDb.GetRecordsCount());
            Clients.All.loadDonorStatNumber(donorDb.GetRecordsCount());
            return base.OnConnected();
        }
    }
}