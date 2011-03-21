namespace Ninject.Extensions.Logging.Log4Net
{
    using Ninject;
    using Ninject.Extensions.Logging.Log4Net.Infrastructure;
    using Ninject.Modules;

    public class Log4netTests : Log4netTestingContext
    {
        // todo, add log4net specific tests
    }

#if !SILVERLIGHT && !NETCF
    public class Log4netAutoloadTests : Log4netTestingContext
    {
        protected override INinjectSettings CreateSettings()
        {
            return new NinjectSettings
                {
                    LoadExtensions = true,
                    ExtensionSearchPatterns = new[] { "Ninject.Extensions.Logging.Log4net.dll" }
                };
        }

        public override INinjectModule[] TestModules
        {
            get { return new INinjectModule[0]; }
        }
    }
#endif
}