namespace Ninject.Extensions.Logging.NLog
{
    using Ninject.Extensions.Logging.NLog.Infrastructure;
    using Ninject.Modules;

    public class NLogTests : NLogTestingContext
    {
        // todo, add nlog specific tests
    }

#if !SILVERLIGHT && !NETCF
    public class NLogAutoloadTests : NLogTestingContext
    {
        protected override INinjectSettings CreateSettings()
        {
            return new NinjectSettings
                {
                    LoadExtensions = true, 
                    ExtensionSearchPattern = "Ninject.Extensions.Logging.NLog.dll"
                };
        }

        public override INinjectModule[] TestModules
        {
            get { return new INinjectModule[0]; }
        }
    }
#endif
}