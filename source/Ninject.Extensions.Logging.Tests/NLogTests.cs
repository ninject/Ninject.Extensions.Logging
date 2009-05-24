#region Using Directives

using Ninject.Extensions.Logging.Tests.Infrastructure;

#endregion

namespace Ninject.Extensions.Logging.Tests
{
    public class NLogTests : NLogTestingContext
    {
        // todo, add nlog specific tests
    }

    public class NLogAutoloadTests : NLogTestingContext
    {
        protected virtual INinjectSettings CreateSettings()
        {
            var settings = new NinjectSettings();
            settings.LoadExtensions = true;
            settings.ExtensionSearchPattern = "Ninject.Extensions.Logging.NLog.dll";
            return settings;
        }
    }
}