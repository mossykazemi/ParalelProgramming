using System.Collections.Concurrent;

Console.WriteLine("*** Start Main ***");

var tokenSource = new CancellationTokenSource();
var token = tokenSource.Token;

Task t;
var tasks = new ConcurrentBag<Task>();

Console.WriteLine("Press Any Key to begin ...");
Console.ReadKey(true);
Console.WriteLine("To terminate the example, press 'c' to cancel and exit");
Console.WriteLine();

t = Task.Factory.StartNew(() => LongRunningOperation(1, token), token);
Console.WriteLine($"Task {t.Id} executing");
tasks.Add(t);

char ch = Console.ReadKey().KeyChar;
if (ch == 'c')
{
    tokenSource.Cancel();
    Console.WriteLine("Task Cancellation Request");
}

try
{
    Task.WaitAll(tasks.ToArray());
}
catch(AggregateException e)
{
    Console.WriteLine("AggregateException thrown");
    foreach (var v in e.InnerExceptions)
    {
        if (v is TaskCanceledException)
        {
            Console.WriteLine("TaskCanceledException thrown");
        }
        else
        {
            Console.WriteLine($"Execption {v.GetType().Name} thrown");
        }

        Console.WriteLine();
    }
}
finally
{
    tokenSource.Dispose();
}

foreach (var task in tasks)
{
    Console.WriteLine($"Task {task.Id} status is now {task.Status}");
}

Console.WriteLine("*** End Main ***");
Console.ReadKey();



static void LongRunningOperation(int taskNumber, CancellationToken ct)
{
    if (ct.IsCancellationRequested)
    {
        Console.WriteLine($"Task {taskNumber} was cancelled before it got started");
        ct.ThrowIfCancellationRequested();
    }

    int max = 100;
    for (int i = 0; i < max; i++)
    {
        Thread.Sleep(1000);
    }

    if (ct.IsCancellationRequested)
    {
        Console.WriteLine($"Task {taskNumber} Cancelled");
        ct.ThrowIfCancellationRequested();
    }

}