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
        public override Task OnConnected()
        {
            IDbContext patientDb = new PatientDbContext();
            IDbContext donorDb = new DonorDbContext();
            var username = Context.User.Identity.Name;

            Clients.All.loadPatientStatNumber(username, patientDb.GetRecordsCount());
            Clients.All.loadDonorStatNumber(username, donorDb.GetRecordsCount());
            return base.OnConnected();
        }
    }
}