using System;
using System.Threading.Tasks;

namespace HelloWorld.Domain.Contracts.Handlers
{
    public interface IExceptionHandler
    {
        TResult Run<TResult>(Func<TResult> unsafeFunction);


        Task<TResult> RunAsync<TResult>(Func<Task<TResult>> unsafeTask);
    }
}