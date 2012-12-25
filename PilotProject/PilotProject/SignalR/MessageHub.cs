using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR;

namespace PilotProject.SignalR
{
    public class MessageHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.addMessage(message);
        }
        public void SubToMedic(int medicId)
        {
            System.Diagnostics.Trace.WriteLine("Test" + medicId.ToString());
            System.Diagnostics.Trace.WriteLine(Context.ConnectionId);
            Groups.Add(Context.ConnectionId, medicId.ToString());
        }
        public static void SendMedicUpdate(Medic medic)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MessageHub>();
            System.Diagnostics.Trace.WriteLine("Sending medic update");
            context.Clients.Group(medic.Id.ToString()).updateMedic(medic);
        }
    }
}