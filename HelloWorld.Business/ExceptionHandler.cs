using HelloWorld.Domain.Contracts;
using HelloWorld.Domain.Contracts.Handlers;
using System;
using System.Threading.Tasks;

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


        public async Task<TResult> RunAsync<TResult>(Func<Task<TResult>> unsafeTask)
        {
            try
            {
                return await unsafeTask.Invoke();
            }
            catch(Exception ex)
            {
                _logger.LogException(ex);
            }
            return default(TResult);
        }
    }
}