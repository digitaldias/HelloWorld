using System;


namespace HelloWorld.Domain.Contracts
{
    public interface ILogger
    {
        void LogException(Exception ex);
    }
}