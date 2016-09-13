using HelloWorld.Domain.Contracts;
using System;

namespace HelloWorld.Data
{
    public class ConsoleLogger : ILogger
    {
        public void LogException(Exception ex)
        {
            Console.WriteLine("EXCEPTION>> " + ex.Message + "\n" + ex.StackTrace.ToString());
        }
    }
}
