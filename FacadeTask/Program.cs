using System.Diagnostics;

Console.WriteLine("*** Main Start ***");

Run();

Console.WriteLine("*** Main End ***");
Console.ReadKey();

static async void Run()
{
    var stopwatch = Stopwatch.StartNew();
    var tcs = new TaskCompletionSource<bool>();
    Console.WriteLine($"Start : {stopwatch.ElapsedMilliseconds} ms");

    var fnf = Task.Delay(2000).ContinueWith(task => tcs.SetResult(true));
    Console.WriteLine($"Waiting : {stopwatch.ElapsedMilliseconds} ms");

    await tcs.Task;
    Console.WriteLine($"Done in: {stopwatch.ElapsedMilliseconds} ms");
    stopwatch.Stop();
}