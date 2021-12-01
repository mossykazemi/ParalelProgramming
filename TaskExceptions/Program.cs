Console.WriteLine("*** Main Start ***");

var task1 = Task.Run(() => throw new CustomException("this is an exception"));

while (!task1.IsCompleted)
{
}

if (task1.Status == TaskStatus.Faulted)
{
    foreach (var e in task1.Exception.InnerExceptions)
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

Console.WriteLine("*** Main End ***");
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