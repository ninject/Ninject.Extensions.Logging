#region Using Directives

using Ninject.Extensions.Logging.Tests.Infrastructure;

#endregion

namespace Ninject.Extensions.Logging.Tests
{
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