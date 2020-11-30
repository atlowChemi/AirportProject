using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Server.Hubs
{
    public class FlightHub : Hub
    {
        public async Task RegisterToControlTower(string name)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"CT-{name}");
        }
    }
}
