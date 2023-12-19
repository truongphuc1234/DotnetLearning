namespace Concurrency.AsyncBasic.PausingForAPeriodTime;

public class SimpleDelay
{
    public async Task<T> DelayResult<T>(T result, TimeSpan timeSpan)
    {
        await Task.Delay(timeSpan);
        return result;
    }
}


