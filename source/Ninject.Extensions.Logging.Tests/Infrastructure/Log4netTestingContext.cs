#region Using Directives

using System;
using log4net.Config;
using Ninject.Extensions.Logging.Log4net;
using Ninject.Extensions.Logging.Log4net.Infrastructure;
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

        public override Type LoggerType
        {
            get { return typeof (Log4netLogger); }
        }

        #endregion
    }
}