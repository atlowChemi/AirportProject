using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Server.Hubs
{
    public class FlightHub : Hub
    {
        /// <summary>
        /// Register client to requested control tower group of updates.
        /// </summary>
        /// <param name="name">Name of control tower.</param>
        /// <returns>A <see cref="Task"/> representing the addition of client to group.</returns>
        public async Task RegisterToControlTower(string name)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"CT-{name}");
        }
    }
}
