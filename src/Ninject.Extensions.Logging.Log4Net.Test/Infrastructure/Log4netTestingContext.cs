namespace Ninject.Extensions.Logging.Log4Net.Infrastructure
{
    using System;
    using log4net.Config;
    using Ninject.Extensions.Logging.Infrastructure;
    using Ninject.Extensions.Logging.Log4net;
    using Ninject.Extensions.Logging.Log4net.Infrastructure;
    using Ninject.Modules;

    public abstract class Log4netTestingContext : CommonTests
    {
        private readonly INinjectModule module;

        static Log4netTestingContext()
        {
            XmlConfigurator.Configure();
        }

        public Log4netTestingContext()
        {
            this.module = new Log4NetModule();
        }

        public override INinjectModule[] TestModules
        {
            get { return new[] { this.module }; }
        }

        public override Type LoggerType
        {
            get { return typeof (Log4NetLogger); }
        }
    }
}