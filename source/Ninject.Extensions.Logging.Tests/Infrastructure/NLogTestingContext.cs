#region Using Directives

using Ninject.Extensions.Logging.NLog;
using Ninject.Modules;

#endregion

namespace Ninject.Extensions.Logging.Tests.Infrastructure
{
    public abstract class NLogTestingContext : CommonTests
    {
        private readonly INinjectModule _module;

        public NLogTestingContext()
        {
            _module = new NLogModule();
        }

        #region Implementation of ILoggingTestContext

        public override INinjectModule TestModule
        {
            get { return _module; }
        }

        #endregion
    }
}