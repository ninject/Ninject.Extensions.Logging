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
        protected override IKernel CreateKernel()
        {
            var settings = new NinjectSettings();
            settings.LoadExtensions = true;
            return new StandardKernel( settings );
        }
    }
}