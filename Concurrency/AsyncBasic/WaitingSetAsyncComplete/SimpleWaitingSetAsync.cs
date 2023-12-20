namespace Concurrency.AsyncBasic.WaitingSetAsyncComplete;

public class SimpleWaitingSetAsync
{

    public async Task SimpleWait()
    {
        var task1 = Task.Delay(TimeSpan.FromSeconds(1));
        var task2 = Task.Delay(TimeSpan.FromSeconds(3));
        var task3 = Task.Delay(TimeSpan.FromSeconds(1));

        await Task.WhenAll(task1, task2, task3);

        var taskInt1 = Task.FromResult(1);
        var taskInt2 = Task.FromResult(11);
        var taskInt3 = Task.FromResult(3);

        int[] results = await Task.WhenAll(taskInt1, taskInt2, taskInt3);

    }

    public async Task<string> DownloadAllAsync(HttpClient client, IEnumerable<string> urls)
    {
        var downloads = urls.Select(u => client.GetStringAsync(u));
        var downloadTasks = downloads.ToArray();
        var htmlPages = await Task.WhenAll(downloadTasks);
        return string.Concat(htmlPages);
    }

    public async Task ThrowNotImplementExceptionAsync()
    {
        await Task.Delay(1);
        throw new NotImplementedException();
    }

    public async Task ThrowInvalidOperationExceptionAsync()
    {
        await Task.Delay(1);
        throw new InvalidOperationException();
    }

    public async Task ObserveOneExceptionAsync()
    {
        var task1 = ThrowInvalidOperationExceptionAsync();
        var task2 = ThrowNotImplementExceptionAsync();
        try
        {
            await Task.WhenAll(task1, task2);
        }
        catch (Exception ex)
        {

        }
    }
    public async Task ObserveAllExceptionAsync()
    {
        var task1 = ThrowInvalidOperationExceptionAsync();
        var task2 = ThrowNotImplementExceptionAsync();
        var task = Task.WhenAll(task1, task2);
        try
        {
            await task;
        }
        catch
        {
            var allExceptions = task.Exception;
        }
    }
}
