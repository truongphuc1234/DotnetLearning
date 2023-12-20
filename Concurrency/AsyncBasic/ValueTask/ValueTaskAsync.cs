
namespace Concurrency.AsyncBasic.ValueTasks;

public class ValueTaskAsync
{
    private Func<Task>? _disposeLogic;
    public async ValueTask<int> MethodAsync()
    {
        await Task.Delay(100);
        return 13;
    }

    public ValueTask<int> SecondMethodAsync()
    {
        if (CanBehaveSynchronously())
        {
            return new ValueTask<int>(13);
        }
        return new ValueTask<int>(SlowMethodAsync());
    }

    public ValueTask DisposeAsync()
    {
        if (_disposeLogic == null)
        {
            return default;
        }
        Func<Task> logic = _disposeLogic;
        _disposeLogic = null;
        return new ValueTask(logic());
    }

    public async Task ConsumeMethodAsync()
    {
        var valueTask = MethodAsync();
        int value = await valueTask;
    }

    public async Task SecondConsumeMethodAsync()
    {
        var valueTask = MethodAsync();
        var task1 = valueTask.AsTask();
        var anotherTask1 = valueTask.AsTask();
        var result = await Task.WhenAll(task1, anotherTask1);
    }

    private Task<int> SlowMethodAsync()
    {
        throw new NotImplementedException();
    }

    private bool CanBehaveSynchronously()
    {
        throw new NotImplementedException();
    }
}
