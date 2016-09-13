using HelloWorld.Data;
using HelloWorld.Domain.Contracts;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayHello.DependencyInversion
{
    public class RuntimeRegistry : Registry
    {
        public RuntimeRegistry()
        {
            Scan(x => {
                x.AssembliesFromApplicationBaseDirectory();                
                x.WithDefaultConventions();
            });

            For<ILogger>().Singleton().Use<ConsoleLogger>();
        }
    }
}
