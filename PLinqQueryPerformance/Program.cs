using System.Diagnostics;

Console.WriteLine("*** Start Main ***");

var source = Enumerable.Range(1, 3000000);

var query = source
    .Where(n => n % 2 == 0)
    .Select(n => n);

var sw = Stopwatch.StartNew();
foreach (var n in query)
{
}

sw.Stop();
Console.WriteLine($"Total query time : {sw.ElapsedMilliseconds}");


Console.WriteLine("*** End Main ***");
Console.ReadKey();