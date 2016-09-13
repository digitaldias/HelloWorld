using System;
using HelloWorld.Domain.Contracts;
using HelloWorld.Domain.Contracts.Readers;
using HelloWorld.Domain.Contracts.Handlers;

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


        public string RequestGreeting()
        {
            return _exceptionHandler.Run(() => _tokenReader.GetGreeting());            
        }
    }
}