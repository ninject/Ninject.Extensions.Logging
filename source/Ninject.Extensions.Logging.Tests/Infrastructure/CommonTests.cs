#region Using Directives

using System;
using Ninject.Extensions.Logging.Tests.Classes;
using Ninject.Modules;
using Xunit;

#endregion

namespace Ninject.Extensions.Logging.Tests.Infrastructure
{
    public abstract class CommonTests : ILoggingTestContext
    {
        [Fact]
        public void PublicLoggerPropertyIsInjected()
        {
            using ( var kernel = CreateKernel() )
            {
                var loggerClass = kernel.Get<PublicPropertyLoggerClass>();
                Assert.NotNull( loggerClass.Logger );
                Assert.Equal( typeof (PublicPropertyLoggerClass), loggerClass.Logger.Type );
                Assert.Equal( LoggerType, loggerClass.Logger.GetType() );
            }
        }

        [Fact]
        public void NonPublicLoggerPropertyIsNotInjected()
        {
            using ( var kernel = CreateKernel() )
            {
                var loggerClass = kernel.Get<NonPublicPropertyLoggerClass>();
                Assert.Null( loggerClass.Logger );
            }
        }

        [Fact]
        public void CtorLoggerPropertyIsInjected()
        {
            using ( var kernel = CreateKernel() )
            {
                var loggerClass = kernel.Get<CtorPropertyLoggerClass>();
                Assert.NotNull( loggerClass.Logger );
                Assert.Equal( typeof (CtorPropertyLoggerClass), loggerClass.Logger.Type );
                Assert.Equal( LoggerType, loggerClass.Logger.GetType() );
            }
        }

        [Fact]
        public void ObjectCanGetsItsOwnLogger()
        {
            using ( var kernel = CreateKernel() )
            {
                var loggerClass = kernel.Get<ObjectGetsItsOwnLogger>();
                Assert.NotNull( loggerClass.Logger );
                Assert.Equal( typeof (ObjectGetsItsOwnLogger), loggerClass.Logger.Type );
                Assert.Equal( LoggerType, loggerClass.Logger.GetType() );
            }
        }

        [Fact]
        public void ObjectCanGetsItsOwnLoggerUsingGetCurrentClassLogger()
        {
            using ( var kernel = CreateKernel() )
            {
                var loggerClass = kernel.Get<ObjectGetsItsOwnLoggerUsingCurrentClassMethod>();
                Assert.NotNull( loggerClass.Logger );
                Assert.Equal( typeof (ObjectGetsItsOwnLoggerUsingCurrentClassMethod), loggerClass.Logger.Type );
                Assert.Equal( LoggerType, loggerClass.Logger.GetType() );
            }
        }

        protected virtual IKernel CreateKernel()
        {
            var settings = CreateSettings();
            return new StandardKernel( settings, TestModule );
        }

        protected virtual INinjectSettings CreateSettings()
        {
            var settings = new NinjectSettings();
            settings.LoadExtensions = false;
            return settings;
        }

        #region Implementation of ILoggingTestContext

        public abstract INinjectModule TestModule { get; }
        public abstract Type LoggerType { get; }

        #endregion
    }
}