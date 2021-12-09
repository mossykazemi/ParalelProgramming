using System.Collections.Concurrent;

int[] elements = { 50, 10, 0 };
var stack = new ConcurrentStack<int>(elements);
Console.WriteLine(string.Join(", ", stack.ToArray()));

stack.Push(100);
Console.WriteLine(string.Join(", ", stack.ToArray()));

if (stack.TryPeek(out int resultPeek))
{
    Console.WriteLine($"TryPeek : {resultPeek}");
}

if (stack.TryPop(out int resultPop))
{
    Console.WriteLine($"TryPop : {resultPop}");
}

Console.WriteLine(string.Join(", ", stack.ToArray()));

Console.WriteLine("*** End Main ***");
Console.ReadKey();