Console.WriteLine("*** Main start ****");

//Parallel.Invoke(() => Operation2(), () => Operation1());

var task1 = Task.Run(() => Operation1());
Console.WriteLine("this is execute first");
task1.Wait();

var task2 = Task.Run(() => Operation2());
Console.WriteLine("this is execute second");
task2.Wait();

Console.WriteLine("*** Main end ****");
Console.ReadKey();

static void Operation1()
{
    Console.WriteLine("Operation 1 Executed");
}

static void Operation2()
{
    Console.WriteLine("Operation 2 Executed");
}