using System.Collections.Concurrent;

Console.WriteLine("*** Start Main ***");

var bag = new ConcurrentBag<int>();
bag.Add(1);
bag.Add(2);
bag.Add(3);

int result;
if (bag.TryPeek(out result))
{
    Console.WriteLine($"TryPeek : {result}");
}

if (bag.TryTake(out result))
{
    Console.WriteLine($"TryTake : {result}");
}

Console.WriteLine($"Final bag is: {string.Join(", ", bag.ToArray())}");
Console.WriteLine("*** End Main ***");
Console.ReadKey();