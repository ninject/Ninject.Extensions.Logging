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
        protected override IKernel CreateKernel()
        {
            var settings = new NinjectSettings();
            settings.LoadExtensions = true;
            return new StandardKernel( settings );
        }
    }
}