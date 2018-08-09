//-------------------------------------------------------------------------------
// <copyright file="NLogTests.cs" company="bbv Software Services AG">
//   Copyright (c) 2010 Software Services AG
//   Remo Gloor (remo.gloor@gmail.com)
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace Ninject.Extensions.Logging.NLog4
{
    using System;
    using System.Reflection;

    using FluentAssertions;

    using Ninject.Extensions.Logging.Classes;
    using Ninject.Extensions.Logging.NLog4.Infrastructure;
    using NLog;
    using NLog.Config;
    using Xunit;

    public class NLogTests : NLogTestingContext
    {
        /// <summary>
        /// the target that is used to intercept the logging events
        /// </summary>
        private static readonly TestTarget testTarget;

        /// <summary>
        /// Initializes a new instance of the <see cref="NLogTests"/> class.
        /// </summary>
        static NLogTests()
        {
            testTarget = new TestTarget { Layout = "${callsite}" };
            SimpleConfigurator.ConfigureForTargetLogging(testTarget, LogLevel.Trace);
        }

        /// <summary>
        /// Tests info logging
        /// </summary>
        [Fact]
        public void LogTrace()
        {
            this.TestLog(LogLevel.Trace, typeof(CtorPropertyLoggerClass).GetMethod("LogTrace"));
        }

        /// <summary>
        /// Tests Trace logging
        /// </summary>
        [Fact]
        public void LogTraceWithArguments()
        {
            this.TestLogWithArguments(LogLevel.Trace, typeof(CtorPropertyLoggerClass).GetMethod("LogTraceWithArguments"));
        }

        /// <summary>
        /// Tests Trace exception logging
        /// </summary>
        [Fact]
        public void LogTraceException()
        {
            this.TestLogException(LogLevel.Trace, typeof(CtorPropertyLoggerClass).GetMethod("LogTraceException"));
        }

        /// <summary>
        /// Tests Trace logging with exception
        /// </summary>
        [Fact]
        public void LogTraceWithException()
        {
            this.TestLogWithException(LogLevel.Trace, typeof(CtorPropertyLoggerClass).GetMethod("LogTraceWithException"));
        }

        /// <summary>
        /// Tests info logging
        /// </summary>
        [Fact]
        public void LogInfo()
        {
            this.TestLog(LogLevel.Info, typeof(CtorPropertyLoggerClass).GetMethod("LogInfo"));
        }

        /// <summary>
        /// Tests info logging
        /// </summary>
        [Fact]
        public void LogInfoWithArguments()
        {
            this.TestLogWithArguments(LogLevel.Info, typeof(CtorPropertyLoggerClass).GetMethod("LogInfoWithArguments"));
        }

        /// <summary>
        /// Tests info exception logging
        /// </summary>
        [Fact]
        public void LogInfoException()
        {
            this.TestLogException(LogLevel.Info, typeof(CtorPropertyLoggerClass).GetMethod("LogInfoException"));
        }

        /// <summary>
        /// Tests info logging with exception
        /// </summary>
        [Fact]
        public void LogInfoWithException()
        {
            this.TestLogWithException(LogLevel.Info, typeof(CtorPropertyLoggerClass).GetMethod("LogInfoWithException"));
        }

        /// <summary>
        /// Tests debug logging
        /// </summary>
        [Fact]
        public void LogDebug()
        {
            this.TestLog(LogLevel.Debug, typeof(CtorPropertyLoggerClass).GetMethod("LogDebug"));
        }

        /// <summary>
        /// Tests debug logging
        /// </summary>
        [Fact]
        public void LogDebugWithArguments()
        {
            this.TestLogWithArguments(LogLevel.Debug, typeof(CtorPropertyLoggerClass).GetMethod("LogDebugWithArguments"));
        }

        /// <summary>
        /// Tests debug exception logging
        /// </summary>
        [Fact]
        public void LogDebugException()
        {
            this.TestLogException(LogLevel.Debug, typeof(CtorPropertyLoggerClass).GetMethod("LogDebugException"));
        }

        /// <summary>
        /// Tests debug logging with exception
        /// </summary>
        [Fact]
        public void LogDebugWithException()
        {
            this.TestLogWithException(LogLevel.Debug, typeof(CtorPropertyLoggerClass).GetMethod("LogDebugWithException"));
        }

        /// <summary>
        /// Tests warn logging
        /// </summary>
        [Fact]
        public void LogWarn()
        {
            this.TestLog(LogLevel.Warn, typeof(CtorPropertyLoggerClass).GetMethod("LogWarn"));
        }

        /// <summary>
        /// Tests warn logging
        /// </summary>
        [Fact]
        public void LogWarnWithArguments()
        {
            this.TestLogWithArguments(LogLevel.Warn, typeof(CtorPropertyLoggerClass).GetMethod("LogWarnWithArguments"));
        }

        /// <summary>
        /// Tests warn exception logging
        /// </summary>
        [Fact]
        public void LogWarnException()
        {
            this.TestLogException(LogLevel.Warn, typeof(CtorPropertyLoggerClass).GetMethod("LogWarnException"));
        }

        /// <summary>
        /// Tests warn logging with exception
        /// </summary>
        [Fact]
        public void LogWarnWithException()
        {
            this.TestLogWithException(LogLevel.Warn, typeof(CtorPropertyLoggerClass).GetMethod("LogWarnWithException"));
        }

        /// <summary>
        /// Tests error logging
        /// </summary>
        [Fact]
        public void LogError()
        {
            this.TestLog(LogLevel.Error, typeof(CtorPropertyLoggerClass).GetMethod("LogError"));
        }

        /// <summary>
        /// Tests error logging
        /// </summary>
        [Fact]
        public void LogErrorWithArguments()
        {
            this.TestLogWithArguments(LogLevel.Error, typeof(CtorPropertyLoggerClass).GetMethod("LogErrorWithArguments"));
        }

        /// <summary>
        /// Tests fatal exception logging
        /// </summary>
        [Fact]
        public void LogErrorException()
        {
            this.TestLogException(LogLevel.Error, typeof(CtorPropertyLoggerClass).GetMethod("LogErrorException"));
        }

        /// <summary>
        /// Tests error logging with exception
        /// </summary>
        [Fact]
        public void LogErrorWithException()
        {
            this.TestLogWithException(LogLevel.Error, typeof(CtorPropertyLoggerClass).GetMethod("LogErrorWithException"));
        }

        /// <summary>
        /// Tests fatal logging
        /// </summary>
        [Fact]
        public void LogFatal()
        {
            this.TestLog(LogLevel.Fatal, typeof(CtorPropertyLoggerClass).GetMethod("LogFatal"));
        }

        /// <summary>
        /// Tests fatal logging
        /// </summary>
        [Fact]
        public void LogFatalWithArguments()
        {
            this.TestLogWithArguments(LogLevel.Fatal, typeof(CtorPropertyLoggerClass).GetMethod("LogFatalWithArguments"));
        }

        /// <summary>
        /// Tests fatal exception logging
        /// </summary>
        [Fact]
        public void LogFatalException()
        {
            this.TestLogException(LogLevel.Fatal, typeof(CtorPropertyLoggerClass).GetMethod("LogFatalException"));
        }

        /// <summary>
        /// Tests fatal logging with exception
        /// </summary>
        [Fact]
        public void LogFatalWithException()
        {
            this.TestLogWithException(LogLevel.Fatal, typeof(CtorPropertyLoggerClass).GetMethod("LogFatalWithException"));
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
        /// Tests the logging without exception and without parameters.
        /// </summary>
        /// <param name="logLevel">The log level to be tested.</param>
        /// <param name="methodInfo">The method info to be called to invoke the method to be tested.</param>
        private void TestLog(LogLevel logLevel, MethodInfo methodInfo)
        {
            using (var kernel = this.CreateKernel())
            {
                var loggerClass = kernel.Get<CtorPropertyLoggerClass>();

                methodInfo.Invoke(loggerClass, new object[] { "test message" });

                var lastLogEvent = testTarget.LastLogEvent;
                lastLogEvent.Should().NotBeNull();
                lastLogEvent.FormattedMessage.Should().Be("test message");
                lastLogEvent.Level.Should().Be(logLevel);
                lastLogEvent.LoggerName.Should().Be(loggerClass.GetType().FullName);
                lastLogEvent.Exception.Should().BeNull();

                // testTarget.LastMessage.ShouldBe(methodInfo.DeclaringType.FullName + "." + methodInfo.Name);
                // lastLogEvent.UserStackFrame.GetMethod().ShouldBe(methodInfo);
            }

        }

        /// <summary>
        /// Tests the logging without exception and with parameters.
        /// </summary>
        /// <param name="logLevel">The log level to be tested.</param>
        /// <param name="methodInfo">The method info to be called to invoke the method to be tested.</param>
        private void TestLogWithArguments(LogLevel logLevel, MethodInfo methodInfo)
        {
            using (var kernel = this.CreateKernel())
            {
                var loggerClass = kernel.Get<CtorPropertyLoggerClass>();

                methodInfo.Invoke(loggerClass, new object[] { "message {0}", new object[] { 1 } });

                var lastLogEvent = testTarget.LastLogEvent;
                lastLogEvent.Should().NotBeNull();
                lastLogEvent.FormattedMessage.Should().Be("message 1");
                lastLogEvent.Level.Should().Be(logLevel);
                lastLogEvent.LoggerName.Should().Be(loggerClass.GetType().FullName);
                lastLogEvent.Exception.Should().BeNull();

                // testTarget.LastMessage.ShouldBe(methodInfo.DeclaringType.FullName + "." + methodInfo.Name);
                // lastLogEvent.UserStackFrame.GetMethod().ShouldBe(methodInfo);
            }
        }

        /// <summary>
        /// Tests the logging with exception.
        /// </summary>
        /// <param name="logLevel">The log level to be tested.</param>
        /// <param name="methodInfo">The method info to be called to invoke the method to be tested.</param>
        private void TestLogException(LogLevel logLevel, MethodInfo methodInfo)
        {
            using (var kernel = this.CreateKernel())
            {
                var loggerClass = kernel.Get<CtorPropertyLoggerClass>();
                var exception = new ArgumentException();

                methodInfo.Invoke(loggerClass, new object[] { "exception message", exception });

                var lastLogEvent = testTarget.LastLogEvent;
                lastLogEvent.Should().NotBeNull();
                lastLogEvent.FormattedMessage.Should().Be("exception message");
                lastLogEvent.Level.Should().Be(logLevel);
                lastLogEvent.LoggerName.Should().Be(loggerClass.GetType().FullName);
                lastLogEvent.Exception.Should().BeSameAs(exception);

                // testTarget.LastMessage.ShouldBe(methodInfo.DeclaringType.FullName + "." + methodInfo.Name);
                // lastLogEvent.UserStackFrame.GetMethod().ShouldBe(methodInfo);
            }
        }

        /// <summary>
        /// Tests the logging with exception.
        /// </summary>
        /// <param name="logLevel">The log level to be tested.</param>
        /// <param name="methodInfo">The method info to be called to invoke the method to be tested.</param>
        private void TestLogWithException(LogLevel logLevel, MethodInfo methodInfo)
        {
            using (var kernel = this.CreateKernel())
            {
                var loggerClass = kernel.Get<CtorPropertyLoggerClass>();
                var exception = new ArgumentException();

                methodInfo.Invoke(loggerClass, new object[] { exception, "message {0}", new object[] { 1 } });

                var lastLogEvent = testTarget.LastLogEvent;
                lastLogEvent.Should().NotBeNull();
                lastLogEvent.FormattedMessage.Should().Be("message 1");
                lastLogEvent.Level.Should().Be(logLevel);
                lastLogEvent.LoggerName.Should().Be(loggerClass.GetType().FullName);
                lastLogEvent.Exception.Should().BeSameAs(exception);

                // testTarget.LastMessage.ShouldBe(methodInfo.DeclaringType.FullName + "." + methodInfo.Name);
                // lastLogEvent.UserStackFrame.GetMethod().ShouldBe(methodInfo);
            }
        }
    }
}