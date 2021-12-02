Console.WriteLine("*** Start Main ***");

var task1 = Task.Run(() => throw new CustomException("This is and exception"))
    .ContinueWith(
        t =>
        {
            Console.WriteLine($"{t.Exception.InnerException.GetType().Name} : {t.Exception.InnerException.Message}");
        }, TaskContinuationOptions.OnlyOnFaulted);

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