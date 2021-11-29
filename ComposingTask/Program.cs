Console.WriteLine("*** Main Start ***");
ContinueWithOperation();
Console.WriteLine("*** Main End ***");
Console.ReadKey();

static void ContinueWithOperation()
{
    var t = Task<string>.Run(() => LongRunningOperation("Continue With", 3000));

    t.ContinueWith((task1) => { Console.WriteLine(task1.Result); });
}

static string LongRunningOperation(string text, int sec)
{
    Thread.Sleep(sec);
    return $"{text} Completed";
}