using System;

class Program
{
    static void Main(string[] args)
    {
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();

        logger1.Log("This is the first message.");
        logger2.Log("This is the second message.");

        if (logger1 == logger2)
        {
            Console.WriteLine("Both logger instances are the same (Singleton verified).");
        }
        else
        {
            Console.WriteLine("Different instances found (Singleton failed).");
        }
    }
}
