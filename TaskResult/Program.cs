Console.WriteLine("*** Main Start ***");
Run();
Console.WriteLine("*** Main End ***");
Console.ReadKey();

static async void Run()
{
    var t1 = Task<string>.Run(() =>
    {
        Thread.Sleep(4000);
        return "Task One Executed";
    });

    var taskResult = await t1;
    Console.WriteLine(taskResult);
}