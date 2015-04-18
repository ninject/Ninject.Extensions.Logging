namespace Ninject.Extensions.Logging.Log4Net
{
    using System;
    using System.Reflection;
    
	using FluentAssertions;

	using log4net.Appender;
	using log4net.Core;
	using log4net.Repository.Hierarchy;

	using Ninject;
	using Ninject.Extensions.Logging.Classes;
	using Ninject.Extensions.Logging.Log4Net.Infrastructure;
	using Ninject.Modules;

	using Xunit;


    public class Log4netTests : Log4netTestingContext
    {
		/// <summary>
		/// the appender that is used to intercept the logging events
		/// </summary>
		private static readonly log4net.Appender.MemoryAppender testAppender;

		/// <summary>
		/// Initializes a new instance of the <see cref="Log4netTests"/> class.
		/// </summary>
		static Log4netTests()
		{
			// Create the appender
			testAppender = new MemoryAppender
			{
				Name = "Unit Test Appender",
				Layout = new log4net.Layout.PatternLayout("%message"),
				Threshold = Level.Trace
			};
			testAppender.ActivateOptions();

			// Configure the default repository
			var root = ((Hierarchy)log4net.LogManager.GetRepository()).Root;
			root.AddAppender(testAppender);
			root.Repository.Configured = true;
		}

		/// <summary>
		/// Tests info logging
		/// </summary>
		[Fact]
		public void LogInfo()
		{
			this.TestLog(Level.Info, typeof(CtorPropertyLoggerClass).GetMethod("LogInfo"));
		}

		/// <summary>
		/// Tests info logging with exception
		/// </summary>
		[Fact]
		public void LogInfoWithException()
		{
			this.TestLogWithException(Level.Info, typeof(CtorPropertyLoggerClass).GetMethod("LogInfoWithException"));
		}

		/// <summary>
		/// Tests debug logging
		/// </summary>
		[Fact]
		public void LogDebug()
		{
			this.TestLog(Level.Debug, typeof(CtorPropertyLoggerClass).GetMethod("LogDebug"));
		}

		/// <summary>
		/// Tests debug logging with exception
		/// </summary>
		[Fact]
		public void LogDebugWithException()
		{
			this.TestLogWithException(Level.Debug, typeof(CtorPropertyLoggerClass).GetMethod("LogDebugWithException"));
		}

		/// <summary>
		/// Tests warn logging
		/// </summary>
		[Fact]
		public void LogWarn()
		{
			this.TestLog(Level.Warn, typeof(CtorPropertyLoggerClass).GetMethod("LogWarn"));
		}

		/// <summary>
		/// Tests warn logging with exception
		/// </summary>
		[Fact]
		public void LogWarnWithException()
		{
			this.TestLogWithException(Level.Warn, typeof(CtorPropertyLoggerClass).GetMethod("LogWarnWithException"));
		}

		/// <summary>
		/// Tests error logging
		/// </summary>
		[Fact]
		public void LogError()
		{
			this.TestLog(Level.Error, typeof(CtorPropertyLoggerClass).GetMethod("LogError"));
		}

		/// <summary>
		/// Tests error logging with exception
		/// </summary>
		[Fact]
		public void LogErrorWithException()
		{
			this.TestLogWithException(Level.Error, typeof(CtorPropertyLoggerClass).GetMethod("LogErrorWithException"));
		}

		/// <summary>
		/// Tests fatal logging
		/// </summary>
		[Fact]
		public void LogFatal()
		{
			this.TestLog(Level.Fatal, typeof(CtorPropertyLoggerClass).GetMethod("LogFatal"));
		}

		/// <summary>
		/// Tests fatal logging with exception
		/// </summary>
		[Fact]
		public void LogFatalWithException()
		{
			this.TestLogWithException(Level.Fatal, typeof(CtorPropertyLoggerClass).GetMethod("LogFatalWithException"));
		}

#if WINDOWS_PHONE
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

		/// <summary>
		/// Tests the logging without exception.
		/// </summary>
		/// <param name="level">The log level to be tested.</param>
		/// <param name="methodInfo">The method info to be called to invoke the method to be tested.</param>
		private void TestLog(Level level, MethodInfo methodInfo)
		{
			using (var kernel = this.CreateKernel())
			{
				var loggerClass = kernel.Get<CtorPropertyLoggerClass>();

				methodInfo.Invoke(loggerClass, new object[] { "message {0}", new object[] { 1 } });

				var lastLogEvent = testAppender.GetEvents()[testAppender.GetEvents().Length - 1];
				lastLogEvent.Should().NotBeNull();
				lastLogEvent.RenderedMessage.Should().Be("message 1");
				lastLogEvent.Level.Should().Be(level);
				lastLogEvent.LoggerName.Should().Be(loggerClass.GetType().FullName);
				lastLogEvent.ExceptionObject.Should().BeNull();
			}
		}

		/// <summary>
		/// Tests the logging with exception.
		/// </summary>
		/// <param name="logLevel">The log level to be tested.</param>
		/// <param name="methodInfo">The method info to be called to invoke the method to be tested.</param>
		private void TestLogWithException(Level level, MethodInfo methodInfo)
		{
			using (var kernel = this.CreateKernel())
			{
				var loggerClass = kernel.Get<CtorPropertyLoggerClass>();
				var exception = new ArgumentException();

				methodInfo.Invoke(loggerClass, new object[] { exception, "message {0}", new object[] { 1 } });

				var lastLogEvent = testAppender.GetEvents()[testAppender.GetEvents().Length - 1];
				lastLogEvent.Should().NotBeNull();
				lastLogEvent.RenderedMessage.Should().Be("message 1");
				lastLogEvent.Level.Should().Be(level);
				lastLogEvent.LoggerName.Should().Be(loggerClass.GetType().FullName);
				lastLogEvent.ExceptionObject.Should().BeSameAs(exception);
			}

		}
    }

#if !SILVERLIGHT && !NETCF
    public class Log4netAutoloadTests : Log4netTestingContext
    {
        protected override INinjectSettings CreateSettings()
        {
            return new NinjectSettings
                {
                    LoadExtensions = true,
                    ExtensionSearchPatterns = new[] { "Ninject.Extensions.Logging.Log4net.dll" }
                };
        }

        public override INinjectModule[] TestModules
        {
            get { return new INinjectModule[0]; }
        }
    }
#endif
}