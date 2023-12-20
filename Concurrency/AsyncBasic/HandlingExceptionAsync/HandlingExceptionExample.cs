namespace Concurrency.AsyncBasic.HandlingExceptionAsync;

public class HanldingExceptionExample
{
    public async Task ThrowExceptionAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        throw new InvalidOperationException("test");
    }

    public async Task TestAsync()
    {
        var task = ThrowExceptionAsync();
        try
        {
            await task;
        }
        catch (InvalidOperationException)
        {

        }
    }
}
