using HelloWorld.Domain.Contracts.Readers;

namespace HelloWorld.Data
{
    public class TokenReader : ITokenReader
    {
        public string GetGreeting()
        {
            return "The sixth sick shiek's sixth sheep's sick";
        }
    }
}
