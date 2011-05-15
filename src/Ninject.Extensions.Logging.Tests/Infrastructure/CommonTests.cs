namespace Ninject.Extensions.Logging.Infrastructure
{
    using System;
    using Ninject.Extensions.Logging.Classes;
    using Ninject.Modules;
    using Xunit;
    using Xunit.Should;

    public abstract class CommonTests : ILoggingTestContext
    {
        [Fact]
        public void PublicLoggerPropertyIsInjected()
        {
            using (var kernel = this.CreateKernel())
            {
                var loggerClass = kernel.Get<PublicPropertyLoggerClass>();
                loggerClass.Logger.ShouldNotBeNull();
                loggerClass.Logger.Type.ShouldBe(typeof(PublicPropertyLoggerClass));
                loggerClass.Logger.GetType().ShouldBe(this.LoggerType);
            }
        }

        [Fact]
        public void NonPublicLoggerPropertyIsNotInjected()
        {
            using (var kernel = this.CreateKernel())
            {
                var loggerClass = kernel.Get<NonPublicPropertyLoggerClass>();
                loggerClass.Logger.ShouldBeNull();
            }
        }

        [Fact]
        public void CtorLoggerPropertyIsInjected()
        {
            using (var kernel = this.CreateKernel())
            {
                var loggerClass = kernel.Get<CtorPropertyLoggerClass>();
                loggerClass.Logger.ShouldNotBeNull();
                loggerClass.Logger.Type.ShouldBe(typeof(CtorPropertyLoggerClass));
                loggerClass.Logger.GetType().ShouldBe(this.LoggerType);
            }
        }

        [Fact]
        public void ObjectCanGetsItsOwnLogger()
        {
            using (var kernel = this.CreateKernel())
            {
                var loggerClass = kernel.Get<ObjectGetsItsOwnLogger>();
                loggerClass.Logger.ShouldNotBeNull();
                loggerClass.Logger.Type.ShouldBe(typeof(ObjectGetsItsOwnLogger));
                loggerClass.Logger.GetType().ShouldBe(this.LoggerType);
            }
        }

#if !SILVERLIGHT && !NETCF
        [Fact]
        public void ObjectCanGetsItsOwnLoggerUsingGetCurrentClassLogger()
        {
            using (var kernel = this.CreateKernel())
            {
                var loggerClass = kernel.Get<ObjectGetsItsOwnLoggerUsingCurrentClassMethod>();
                loggerClass.Logger.ShouldNotBeNull();
                loggerClass.Logger.Type.ShouldBe(typeof(ObjectGetsItsOwnLoggerUsingCurrentClassMethod));
                loggerClass.Logger.GetType().ShouldBe(this.LoggerType);
            }
        }
#endif

        protected virtual IKernel CreateKernel()
        {
            var settings = this.CreateSettings();
            return new StandardKernel(settings, this.TestModules);
        }

        protected virtual INinjectSettings CreateSettings()
        {
#if SILVERLIGHT && !NETCF
            return new NinjectSettings();
#else
            return new NinjectSettings { LoadExtensions = false };
#endif
        }

        public abstract INinjectModule[] TestModules { get; }
        
        public abstract Type LoggerType { get; }
    }
}