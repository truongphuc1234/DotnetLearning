namespace Concurrency.AsyncBasic.WaitAnyAsync;

public class WaitAny
{
    public async Task<int> FirstRespondingUrlAsync(HttpClient client, string url1, string url2)
    {
        var downloadTaskA = client.GetByteArrayAsync(url1);
        var downloadTaskB = client.GetByteArrayAsync(url2);
        var completeTask = await Task.WhenAny(downloadTaskA, downloadTaskB);
        var data = await completeTask;
        return data.Length;
    }
}
