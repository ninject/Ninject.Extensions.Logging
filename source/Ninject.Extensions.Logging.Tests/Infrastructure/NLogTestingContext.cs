#region Using Directives

using System;
using Ninject.Extensions.Logging.NLog;
using Ninject.Extensions.Logging.NLog.Infrastructure;
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

        public override Type LoggerType
        {
            get { return typeof (NLogLogger); }
        }

        #endregion
    }
}