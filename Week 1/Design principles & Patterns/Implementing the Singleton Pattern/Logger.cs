using System;

public class Logger
{
    private static Logger singleInstance;
    private static readonly object lockObj = new object();

    private Logger()
    {
        Console.WriteLine("Logger Initialized");
    }

    public static Logger GetInstance()
    {
        if (singleInstance == null)
        {
            lock (lockObj)
            {
                if (singleInstance == null)
                {
                    singleInstance = new Logger();
                }
            }
        }
        return singleInstance;
    }

    public void Log(string message)
    {
        Console.WriteLine("Log: " + message);
    }
}
