using HelloWorld.Domain.Contracts;
using HelloWorld.Domain.Contracts.Handlers;
using HelloWorld.Domain.Contracts.Readers;

namespace HelloWorld.Business
{
    public class ConversationManager : IConversationManager
    {
        private readonly IExceptionHandler _exceptionHandler;
        private readonly ITokenReader _tokenReader;


        public ConversationManager(ITokenReader tokenReader, IExceptionHandler exceptionHandler)
        {
            _tokenReader      = tokenReader;
            _exceptionHandler = exceptionHandler;
        }


        public string DefaultGreeting { get { return "Hello World"; } }


        public string RequestGreeting()
        {
            var greeting = _exceptionHandler.Run(() => _tokenReader.GetGreeting());

            if (!string.IsNullOrEmpty(greeting))
                return greeting;

            return DefaultGreeting;
        }
    }
}