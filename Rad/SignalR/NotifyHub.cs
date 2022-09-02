using Microsoft.AspNetCore.SignalR;

namespace Rad.SignalR
{
    /// <summary>
    /// https://www.c-sharpcorner.com/article/real-time-angular-11-application-with-signalr-and-net-5/
    /// </summary>
    public class NotifyHub : Hub<IClientNotifier>
    {
    }
}
