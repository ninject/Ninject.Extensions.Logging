namespace Ninject.Extensions.Logging.Tests.Infrastructure
{
    using System;
    using Ninject.Extensions.Logging.NLog2;
    using Ninject.Extensions.Logging.NLog2.Infrastructure;
    using Ninject.Modules;

    public abstract class NLogTestingContext : CommonTests
    {
        private readonly INinjectModule module;

        public NLogTestingContext()
        {
            this.module = new NLogModule();
        }

        public override INinjectModule[] TestModules
        {
            get { return new[] { this.module }; }
        }

        public override Type LoggerType
        {
            get { return typeof (NLogLogger); }
        }
    }
}