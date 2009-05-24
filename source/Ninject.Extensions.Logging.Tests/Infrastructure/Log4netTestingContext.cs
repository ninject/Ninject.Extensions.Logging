#region Using Directives

using log4net.Config;
using Ninject.Extensions.Logging.Log4net;
using Ninject.Modules;

#endregion

namespace Ninject.Extensions.Logging.Tests.Infrastructure
{
    public abstract class Log4netTestingContext : CommonTests
    {
        private readonly INinjectModule _module;

        static Log4netTestingContext()
        {
            XmlConfigurator.Configure();
        }

        public Log4netTestingContext()
        {
            _module = new Log4netModule();
        }

        #region Implementation of ILoggingTestContext

        public override INinjectModule TestModule
        {
            get { return _module; }
        }

        #endregion
    }
}