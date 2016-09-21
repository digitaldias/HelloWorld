using HelloWorld.Domain.Contracts;
using SayHello.DependencyInversion;
using StructureMap;
using System;

namespace SayHello
{
    class Program
    {
        private static Container _ioc;

        static Program()
        {
            _ioc = new Container(new RuntimeRegistry());            
        }


        static void Main(string[] args)
        {
            var greeting = _ioc.GetInstance<IConversationManager>().RequestGreeting();

            Console.WriteLine(greeting);

            Finish();
        }


        static void Finish()
        {
            Console.WriteLine("\nDone. Press any key to continue");
            Console.ReadKey();
        }
    }
}
