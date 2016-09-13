using System;
using HelloWorld.Domain.Contracts.Handlers;
using HelloWorld.Domain.Contracts;

namespace HelloWorld.Business
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger _logger;


        public ExceptionHandler(ILogger logger)
        {
            _logger = logger;
        }


        public TResult Run<TResult>(Func<TResult> unsafeFunction)
        {
            try
            {
                return unsafeFunction.Invoke();
            }
            catch(Exception ex)
            {
                _logger.LogException(ex);
            }
            return default(TResult);
        }
    }
}