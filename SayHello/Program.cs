using HelloWorld.Domain.Contracts;
using SayHello.DependencyInversion;
using StructureMap;
using System;

namespace SayHello
{
    class Program
    {
        static void Main(string[] args)
        {
            var ioc = new Container(new RuntimeRegistry());            

            Console.WriteLine(ioc.GetInstance<IConversationManager>().RequestGreeting());

            Finish();
        }


        static void Finish()
        {
            Console.WriteLine("\nDone. Press any key to continue");
            Console.ReadKey();
        }
    }
}
