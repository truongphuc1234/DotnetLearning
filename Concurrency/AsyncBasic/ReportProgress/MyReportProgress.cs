namespace Concurrency.AsyncBasic.ReportProgress;

public class MyReportProgress
{
    public async Task MyMethodAsync(IProgress<double>? progress)
    {
        double percentComplete = 0;
        for (int i = 0; i < 4; i++)
        {
            await Task.Delay(TimeSpan.FromSeconds(i));
            progress?.Report(percentComplete);
        }
    }

    public async Task CallMyMethodAsync()
    {
        var progress = new Progress<double>();
        progress.ProgressChanged += (sender, args) =>
        {
            //Do any thing
        };
        await MyMethodAsync(progress);
    }
}
