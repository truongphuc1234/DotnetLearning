namespace Concurrency.AsyncBasic.ReturnCompleteTask;

public interface IMyAsyncInterface
{
    Task<int> GetValueAsync(CancellationToken ct);
    Task DoSomethingAsync();
    Task<T> NotImplementAsync<T>();

}
