namespace Ninject.Extensions.Logging.Tests
{
    using Ninject.Extensions.Logging.Tests.Infrastructure;
#if SILVERLIGHT
#if SILVERLIGHT_MSTEST
    using Microsoft.VisualStudio.TestTools.UnitTesting;
#else
    using UnitDriven;
#endif
#else
    using Ninject.Extensions.Logging.Tests.MSTestAttributes;
    using Ninject.Modules;
#endif

    [TestClass]
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
                    ExtensionSearchPattern = "Ninject.Extensions.Logging.NLog2.dll"
                };
        }

        public override INinjectModule[] TestModules
        {
            get { return new INinjectModule[0]; }
        }
    }
#endif
}