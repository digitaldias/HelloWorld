using System;

namespace HelloWorld.Domain.Contracts.Handlers
{
    public interface IExceptionHandler
    {
        TResult Run<TResult>(Func<TResult> unsafeFunction);
    }
}