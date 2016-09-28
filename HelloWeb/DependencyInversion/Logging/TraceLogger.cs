using HelloWorld.Domain.Contracts;
using System;
using System.Diagnostics;

namespace HelloWeb.DependencyInversion.Logging
{
    public class TraceLogger : ILogger
    {
        public void LogException(Exception ex)
        {
            Trace.WriteLine("EXCEPTION>> " + ex.Message + "\n" + ex.StackTrace.ToString());
        }
    }
}