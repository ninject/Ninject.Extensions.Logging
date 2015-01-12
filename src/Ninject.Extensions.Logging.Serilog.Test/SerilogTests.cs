namespace Ninject.Extensions.Logging.Test.Serilog
{
    using Ninject;
    using Ninject.Extensions.Logging.Serilog.Infrastructure;
    using Ninject.Extensions.Logging.Serilog.Test.Infrastructure;
    using Ninject.Modules;

    public class SerilogTests : SerilogTestingContext
    {
        // todo, add log4net specific tests
    }

#if !SILVERLIGHT && !NETCF
    public class SerilogAutoloadTests : SerilogTestingContext
    {
        protected override INinjectSettings CreateSettings()
        {
            return new NinjectSettings
            {
                LoadExtensions = true,
                ExtensionSearchPatterns = new[] { "Ninject.Extensions.Logging.Serilog.dll" }
            };
        }

        public override INinjectModule[] TestModules
        {
            get { return new INinjectModule[0]; }
        }
    }
#endif
}