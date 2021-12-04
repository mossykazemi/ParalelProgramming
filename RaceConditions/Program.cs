Console.WriteLine("*** Start Main ***");

Task T1 = Task.Factory.StartNew(PrintStar);
Task T2 = T1.ContinueWith(a => PrintPlus());

Task.WaitAll(new Task[] { T1, T2 });


Console.WriteLine("*** End Main ***");
Console.ReadKey();


static void PrintStar()
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine(" * ");
    }
}

static void PrintPlus()
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine(" + ");
    }
}