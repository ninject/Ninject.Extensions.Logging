#region Using Directives

using Ninject.Extensions.Logging.Tests.Infrastructure;

#endregion

namespace Ninject.Extensions.Logging.Tests
{
    public class Log4netTests : Log4netTestingContext
    {
        // todo, add log4net specific tests
    }

    public class Log4netAutoloadTests : Log4netTestingContext
    {
        protected virtual INinjectSettings CreateSettings()
        {
            var settings = new NinjectSettings();
            settings.LoadExtensions = true;
            settings.ExtensionSearchPattern = "Ninject.Extensions.Logging.Log4net.dll";
            return settings;
        }
    }
}