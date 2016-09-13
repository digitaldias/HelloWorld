namespace HelloWorld.Domain.Contracts
{
    public interface IConversationManager
    {
        string RequestGreeting();


        string DefaultGreeting { get;  }
    }
}