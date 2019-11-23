using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace w1.Models
{
    public class ChatHub : Hub { private static Dictionary<string, string> users = new Dictionary<string, string>(); public void AddMe(string messaage) { users.Add(Context.ConnectionId, messaage); Clients.All.updateUsers(users.Values.ToArray()); } public void Send(string messaage) { Clients.All.broadcastMessage(users[Context.ConnectionId], messaage); } public override Task OnDisconnected(bool stopCalled) { users.Remove(Context.ConnectionId); Clients.All.updateUsers(users.ToArray()); return base.OnDisconnected(stopCalled); } }
}