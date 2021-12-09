using System.Collections.Concurrent;

var queue = new ConcurrentQueue<int>();
queue.Enqueue(10);
queue.Enqueue(20);

Console.WriteLine($"Current Queue {string.Join(", ",queue.ToArray())}");

if (queue.TryPeek(out int resultPeek))
{
    Console.WriteLine($"Try Peek result : {resultPeek}");
}

if (queue.TryDequeue(out int resultDequeue))
{
    Console.WriteLine($"Try Dequeue result : {resultDequeue}");
}

Console.WriteLine($"Final Queue {string.Join(", ",queue.ToArray())}");

Console.WriteLine("*** End Main ***");
Console.ReadKey();