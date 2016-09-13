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
            if (unsafeFunction == null)
                return default(TResult);

            try
            {
                return unsafeFunction.Invoke();
            }
            catch(Exception ex)
            {
                if(_logger != null)
                    _logger.LogException(ex);
            }
            return default(TResult);
        }
    }
}