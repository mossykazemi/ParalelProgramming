Console.WriteLine("*** Start Main ***");

var task1 = Task.Factory.StartNew(() =>
{
    var child1 = Task.Factory.StartNew(() =>
    {
        var child2 = Task.Factory.StartNew(() => { throw new CustomException("Second child fault attached"); },
            TaskCreationOptions.AttachedToParent);
        throw new CustomException("First child fault attached");
    }, TaskCreationOptions.AttachedToParent);
});

try
{
    task1.Wait();
}
catch (AggregateException ex)
{
    foreach (var e in ex.Flatten().InnerExceptions)
    {
        if (e is CustomException)
        {
            Console.WriteLine(e.Message);
        }
        else
        {
            throw e;
        }
    }
}

Console.WriteLine("*** End Main ***");
Console.ReadKey();


public class CustomException : Exception
{
    public CustomException() : base()
    {
    }

    public CustomException(string message) : base(message)
    {
    }

    public CustomException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}