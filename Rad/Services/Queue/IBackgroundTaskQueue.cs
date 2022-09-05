namespace Rad.Services.Queue;

#pragma warning disable CS1570 // XML comment has badly formed XML
/// <summary>
/// https://docs.microsoft.com/ru-ru/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-6.0&tabs=visual-studio
/// Раздел "Фоновые задачи в очереди"
/// </summary>
public interface IBackgroundTaskQueue
#pragma warning restore CS1570 // XML comment has badly formed XML
{
    ValueTask QueueBackgroundWorkItemAsync(Func<CancellationToken, ValueTask> workItem);

    ValueTask<Func<CancellationToken, ValueTask>> DequeueAsync(CancellationToken cancellationToken);
}
