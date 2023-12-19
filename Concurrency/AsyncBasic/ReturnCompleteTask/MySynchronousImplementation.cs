

namespace Concurrency.AsyncBasic.ReturnCompleteTask;


public class MySynchronousImplementation : IMyAsyncInterface
{
    public Task DoSomethingAsync()
    {
        try
        {
            DoSomethingSync();
            return Task.CompletedTask;

        }
        catch (Exception ex)
        {
            return Task.FromException(ex);
        }
    }


    public Task<int> GetValueAsync(CancellationToken ct)
    {

        if (ct.IsCancellationRequested)
        {
            return Task.FromCanceled<int>(ct);
        }
        return Task.FromResult<int>(13);
    }

    public Task<T> NotImplementAsync<T>()
    {
        return Task.FromException<T>(new NotImplementedException());
    }

    private void DoSomethingSync()
    {
    }
}
