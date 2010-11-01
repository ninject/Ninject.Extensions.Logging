namespace Ninject.Extensions.Logging.NLog.Infrastructure
{
    using System;
    using Ninject.Extensions.Logging.Infrastructure;
    using Ninject.Modules;

    public abstract class NLogTestingContext : CommonTests
    {
        private readonly INinjectModule _module;

        public NLogTestingContext()
        {
            _module = new NLogModule();
        }

        #region Implementation of ILoggingTestContext

        public override INinjectModule[] TestModules
        {
            get { return new[] { _module }; }
        }

        public override Type LoggerType
        {
            get { return typeof (NLogLogger); }
        }

        #endregion
    }
}