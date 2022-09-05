namespace Rad.Services.Queue;

public class TaskParameter
{
    public CancellationToken CancellationToken { get; set; }

    public string? ConnectionId { get; set; }
}