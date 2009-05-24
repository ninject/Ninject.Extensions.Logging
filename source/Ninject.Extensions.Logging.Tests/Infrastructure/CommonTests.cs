#region Using Directives

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
            }
        }

        [Fact]
        public void PrivateLoggerPropertyIsInjected()
        {
            using ( var kernel = CreateKernel() )
            {
                var loggerClass = kernel.Get<PrivatePropertyLoggerClass>();
                Assert.NotNull( loggerClass.Logger );
                Assert.Equal( typeof (PrivatePropertyLoggerClass), loggerClass.Logger.Type );
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
            }
        }

        protected virtual IKernel CreateKernel()
        {
            var settings = new NinjectSettings();
            settings.LoadExtensions = false;
            return new StandardKernel( settings, TestModule );
        }

        #region Implementation of ILoggingTestContext

        public abstract INinjectModule TestModule { get; }

        #endregion
    }
}