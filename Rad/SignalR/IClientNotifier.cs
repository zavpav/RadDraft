namespace Rad.SignalR
{
    public interface IClientNotifier
    {
        Task SendProgress(ProgressNotify notifyMessage);
    }
}
