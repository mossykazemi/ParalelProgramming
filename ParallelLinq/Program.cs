using System.Diagnostics;

Console.WriteLine("*** Start Main ***");

var source = Enumerable.Range(1, 1000000);
var sw = new Stopwatch();
sw.Start();

var result = source
    .AsParallel()
    .WithDegreeOfParallelism(2)
    .AsOrdered()
    .Where(n => n % 2 == 0)
    .Select(s => s);

sw.Stop();

Console.WriteLine($"found {result.Count()} even numbers out of {source.Count()}, in :{sw.ElapsedMilliseconds}");

Console.WriteLine("*** End Main ***");
Console.ReadKey();