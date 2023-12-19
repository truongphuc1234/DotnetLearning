namespace Concurrency.AsyncBasic.PausingForAPeriodTime;

public class SimpleTimeOut
{
    public async Task<string?> DownloadStringWithTimeOut(HttpClient client, string uri)
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        Task<string> downloadTask = client.GetStringAsync(uri);
        Task timeout = Task.Delay(Timeout.InfiniteTimeSpan, cts.Token);
        Task completeTask = await Task.WhenAny(downloadTask, timeout);
        if (completeTask == timeout)
        {
            return null;
        }
        return await downloadTask;
    }
}


