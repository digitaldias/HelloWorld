using System;
using System.Threading.Tasks;

namespace HelloWorld.Domain.Contracts
{
    public interface ILogger
    {
        void LogException(Exception ex);
    }
}