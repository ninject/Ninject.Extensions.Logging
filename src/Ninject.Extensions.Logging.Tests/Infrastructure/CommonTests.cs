namespace Ninject.Extensions.Logging.Infrastructure
{
    using System;

    using FluentAssertions;

    using Ninject.Extensions.Logging.Classes;
    using Ninject.Modules;
    using Xunit;

    public abstract class CommonTests : ILoggingTestContext
    {
#if!WINDOWS_PHONE // WINDOWS Phone runner bug. Running tests from base classes is not possible
        [Fact]
        public void PublicLoggerPropertyIsInjected()
        {
            using (var kernel = this.CreateKernel())
            {
                var loggerClass = kernel.Get<PublicPropertyLoggerClass>();
                loggerClass.Logger.Should().NotBeNull();
                loggerClass.Logger.Type.Should().Be(typeof(PublicPropertyLoggerClass));
                loggerClass.Logger.GetType().Should().Be(this.LoggerType);
            }
        }

        [Fact]
        public void NonPublicLoggerPropertyIsNotInjected()
        {
            using (var kernel = this.CreateKernel())
            {
                var loggerClass = kernel.Get<NonPublicPropertyLoggerClass>();
                loggerClass.Logger.Should().BeNull();
            }
        }
 
        [Fact]
        public virtual void CtorLoggerPropertyIsInjected()
        {
            using (var kernel = this.CreateKernel())
            {
                var loggerClass = kernel.Get<CtorPropertyLoggerClass>();
                loggerClass.Logger.Should().NotBeNull();
                loggerClass.Logger.Type.Should().Be(typeof(CtorPropertyLoggerClass));
                loggerClass.Logger.GetType().Should().Be(this.LoggerType);
            }
        }

        [Fact]
        public void ObjectCanGetsItsOwnLogger()
        {
            using (var kernel = this.CreateKernel())
            {
                var loggerClass = kernel.Get<ObjectGetsItsOwnLogger>();
                loggerClass.Logger.Should().NotBeNull();
                loggerClass.Logger.Type.Should().Be(typeof(ObjectGetsItsOwnLogger));
                loggerClass.Logger.GetType().Should().Be(this.LoggerType);
            }
        }
#endif

#if !SILVERLIGHT && !NETCF
        [Fact]
        public void ObjectCanGetsItsOwnLoggerUsingGetCurrentClassLogger()
        {
            using (var kernel = this.CreateKernel())
            {
                var loggerClass = kernel.Get<ObjectGetsItsOwnLoggerUsingCurrentClassMethod>();
                loggerClass.Logger.Should().NotBeNull();
                loggerClass.Logger.Type.Should().Be(typeof(ObjectGetsItsOwnLoggerUsingCurrentClassMethod));
                loggerClass.Logger.GetType().Should().Be(this.LoggerType);
            }
        }
#endif

        [Fact]
        public void ObjectCanGetNamedLoggers()
        {
            using (var kernel = this.CreateKernel())
            {
                var loggerClass = kernel.Get<ObjectWithNamedLoggers>();

                loggerClass.FirstLogger.Should().NotBeNull();
                loggerClass.FirstLogger.Name.Should().Be("First");

                loggerClass.SecondLogger.Should().NotBeNull();
                loggerClass.SecondLogger.Name.Should().Be("Second");
            }
        }

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