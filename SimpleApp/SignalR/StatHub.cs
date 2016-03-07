using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using SimpleApp.DataLayer.Model;
using SimpleApp.DataLayer.Repositories;

namespace SimpleApp.SignalR
{
    [Authorize]
    public class StatHub : Hub
    {
        public override Task OnConnected()
        {
            //Setting up repositories to be called for SignalR
            IRepository<Patient> patientDb = new PatientRepository();
            IRepository<Donor> donorDb = new DonorRepository();

            //Grabbing the user's identity to be displayed for the notification
            var username = Context.User.Identity.Name;

            //Getting table's count for both donor and patient
            Clients.All.loadPatientStatNumber(username, patientDb.GetRecordsCount());
            Clients.All.loadDonorStatNumber(username, donorDb.GetRecordsCount());

            return base.OnConnected();
        }
    }
}