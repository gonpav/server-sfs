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
        public static void SendMedicUpdate(Medic medic)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MessageHub>();
            context.Clients.All.addMessage(medic);
        }
    }
}