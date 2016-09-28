using HelloWeb.DependencyInversion.Logging;
using HelloWorld.Domain.Contracts;
using StructureMap;

namespace HelloWeb.DependencyInversion
{
    public class RuntimeRegistry : Registry
    {
        public RuntimeRegistry()
        {
            Scan(x =>
            {
                x.AssembliesFromApplicationBaseDirectory();
                x.WithDefaultConventions();
            });

            For<ILogger>().Singleton().Use<TraceLogger>();
        }
    }
}