Console.WriteLine("*** Main Start ***");

Task[] tasks = new Task[3]
{
    Task.Factory.StartNew(() => Method1()),
    Task.Factory.StartNew(() => Method2()),
    Task.Factory.StartNew(() => Method3())
};

// Task.WaitAny(tasks);
Task.WaitAll(tasks);

Console.WriteLine("*** Main End ***");
Console.ReadKey();

static void Method1()
{
    Thread.Sleep(2000);
    Console.WriteLine("Method1");
}

static void Method2()
{
    Console.WriteLine("Method2");
}

static void Method3()
{
    Console.WriteLine("Method3");
}