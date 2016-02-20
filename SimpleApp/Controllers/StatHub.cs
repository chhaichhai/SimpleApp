using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using SimpleApp.Core.Concrete;

namespace SimpleApp.Controllers
{
    [Authorize]
    public class StatHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public void GetPatientStat()
        {
            PatientDbContext patientDb = new PatientDbContext();
            Clients.All.loadStatNumber(patientDb.GetDatabase().Count);
        }

        public override Task OnConnected()
        {
            PatientDbContext patientDb = new PatientDbContext();
            Clients.All.loadStatNumber(patientDb.GetDatabase().Count);
            return base.OnConnected();
        }
    }
}