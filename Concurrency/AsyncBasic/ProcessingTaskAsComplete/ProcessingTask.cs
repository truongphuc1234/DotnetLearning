namespace Concurrency.AsyncBasic.ProcessTaskAsComplete;

public class ProcessingTask
{
    public async Task<int> DelayAndReturnAsync(int value)
    {
        await Task.Delay(TimeSpan.FromSeconds(value)).ConfigureAwait(false);
        return value;
    }

    public async void ProcessTasksAsync()
    {
        var taskA = DelayAndReturnAsync(2);
        var taskB = DelayAndReturnAsync(1);
        var taskC = DelayAndReturnAsync(3);

        var tasks = new[] { taskA, taskB, taskC };
        foreach (var task in tasks)
        {
            var result = await task;
            Console.WriteLine(result);
        }
    }

    public async Task SecondProcessTasks()
    {
        var taskA = DelayAndReturnAsync(2);
        var taskB = DelayAndReturnAsync(1);
        var taskC = DelayAndReturnAsync(3);

        var tasks = new[] { taskA, taskB, taskC };
        IEnumerable<Task> taskQuery = from t in tasks select AwaitAndProcessAsync(t);
        var processingTasks = taskQuery.ToArray();
        await Task.WhenAll(processingTasks);
    }

    public async Task ThirdProcessTasks()
    {
        var taskA = DelayAndReturnAsync(2);
        var taskB = DelayAndReturnAsync(1);
        var taskC = DelayAndReturnAsync(3);

        var tasks = new[] { taskA, taskB, taskC };
        var processingTasks = tasks.Select(async t =>
        {
            var result = await t;
            Console.WriteLine(result);
        }).ToArray();
        await Task.WhenAll(processingTasks);
    }

    private async Task AwaitAndProcessAsync(Task<int> task)
    {
        int result = await task;
        Console.WriteLine(result);
    }
}
