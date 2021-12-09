using System.Collections.Concurrent;
namespace ConcurrentDictionary;

class Program
{ 
    private static ConcurrentDictionary<string, int> _cocurrent = new ConcurrentDictionary<string, int>();
    static void Main(string[] args)
    {
        Console.WriteLine("*** Start Main ***");

        var task1 = Task.Run(() => WriteToDictionary());
        var task2 = Task.Run(() => WriteToDictionary());

        Task.WaitAll(task1, task2);

        Console.WriteLine($"Average : {_cocurrent.Values.Average()}");

        Console.WriteLine("*** End Main ***");
        Console.ReadKey();
    }

    private static void WriteToDictionary()
    {
        for (int num = 0; num < 999; num++)
        {
            _cocurrent.TryAdd(num.ToString(), num);
        }
    }
}