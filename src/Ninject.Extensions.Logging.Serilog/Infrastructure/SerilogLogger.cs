//-------------------------------------------------------------------------------
// <copyright file="SerilogLogger.cs" company="Ninject Project Contributors">
//   Copyright (c) 2015 Ninject Project Contributors
//   Authors: Scott Xu (scott-xu@msn.com)
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

namespace Ninject.Extensions.Logging.Serilog.Infrastructure
{
    using System;
    using global::Serilog;
    using global::Serilog.Core;
    using global::Serilog.Events;

    /// <summary>
    /// A logger that integrates with serilog, passing all messages to a <see cref="ILogger"/>.
    /// </summary>
    public class SerilogLogger : LoggerBase
    {
        /// <summary>
        /// Serilog logger.
        /// </summary>
        private readonly ILogger serilogLogger;

        /// <summary>
        /// Logger name.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerilogLogger"/> class.
        /// </summary>
        /// <param name="type">The type to create a logger for.</param>
        public SerilogLogger(Type type)
            : base(type)
        {
            this.serilogLogger = Log.ForContext(type);
            this.name = type.FullName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerilogLogger"/> class.
        /// </summary>
        /// <param name="name">A custom name to use for the logger.  If null, the type's FullName will be used.</param>
        public SerilogLogger(string name)
            : base(name)
        {
            this.serilogLogger = Log.ForContext(Constants.SourceContextPropertyName, name);
            this.name = name;
        }

        /// <summary>
        /// Gets the name of the logger.
        /// </summary>
        /// <value>The name of the logger.</value>
        public override string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets a value indicating whether messages with Debug severity should be logged.
        /// </summary>
        public override bool IsDebugEnabled
        {
            get { return this.serilogLogger.IsEnabled(LogEventLevel.Debug); }
        }

        /// <summary>
        /// Gets a value indicating whether messages with Info severity should be logged.
        /// </summary>
        public override bool IsInfoEnabled
        {
            get { return this.serilogLogger.IsEnabled(LogEventLevel.Information); }
        }

        /// <summary>
        /// Gets a value indicating whether messages with Trace severity should be logged.
        /// </summary>
        public override bool IsTraceEnabled
        {
            get { return this.serilogLogger.IsEnabled(LogEventLevel.Verbose); }
        }

        /// <summary>
        /// Gets a value indicating whether messages with Warn severity should be logged.
        /// </summary>
        public override bool IsWarnEnabled
        {
            get { return this.serilogLogger.IsEnabled(LogEventLevel.Warning); }
        }

        /// <summary>
        /// Gets a value indicating whether messages with Error severity should be logged.
        /// </summary>
        public override bool IsErrorEnabled
        {
            get { return this.serilogLogger.IsEnabled(LogEventLevel.Error); }
        }

        /// <summary>
        /// Gets a value indicating whether messages with Fatal severity should be logged.
        /// </summary>
        public override bool IsFatalEnabled
        {
            get { return this.serilogLogger.IsEnabled(LogEventLevel.Fatal); }
        }

        /// <summary>
        /// Logs the specified exception with Debug severity.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="format">The message or format template.</param>
        /// <param name="args">Any arguments required for the format template.</param>
        public override void Debug(Exception exception, string format, params object[] args)
        {
            if (this.IsDebugEnabled)
            {
                this.serilogLogger.Debug(exception, format, args);
            }
        }

        /// <summary>
        /// Logs the specified exception with Debug severity.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception to log.</param>
        public override void DebugException(string message, Exception exception)
        {
            if (this.IsDebugEnabled)
            {
                this.serilogLogger.Debug(exception, message);
            }
        }

        /// <summary>
        /// Logs the specified message with Info severity.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Info(string message)
        {
            if (this.IsInfoEnabled)
            {
                this.serilogLogger.Information(message);
            }
        }

        /// <summary>
        /// Logs the specified message with Debug severity.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Debug(string message)
        {
            if (this.IsDebugEnabled)
            {
                this.serilogLogger.Debug(message);
            }
        }

        /// <summary>
        /// Logs the specified message with Debug severity.
        /// </summary>
        /// <param name="format">The message or format template.</param>
        /// <param name="args">Any arguments required for the format template.</param>
        public override void Debug(string format, params object[] args)
        {
            if (this.IsDebugEnabled)
            {
                this.serilogLogger.Debug(format, args);
            }
        }

        /// <summary>
        /// Logs the specified exception with Error severity.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="format">The message or format template.</param>
        /// <param name="args">Any arguments required for the format template.</param>
        public override void Error(Exception exception, string format, params object[] args)
        {
            if (this.IsErrorEnabled)
            {
                this.serilogLogger.Error(exception, format, args);
            }
        }

        /// <summary>
        /// Logs the specified exception with Error severity.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception to log.</param>
        public override void ErrorException(string message, Exception exception)
        {
            if (this.IsErrorEnabled)
            {
                this.serilogLogger.Error(exception, message);
            }
        }

        /// <summary>
        /// Logs the specified message with Fatal severity.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Fatal(string message)
        {
            if (this.IsFatalEnabled)
            {
                this.serilogLogger.Fatal(message);
            }
        }

        /// <summary>
        /// Logs the specified message with Warn severity.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception to log.</param>
        public override void WarnException(string message, Exception exception)
        {
            if (this.IsWarnEnabled)
            {
                this.serilogLogger.Warning(exception, message);
            }
        }

        /// <summary>
        /// Logs the specified message with Error severity.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Error(string message)
        {
            if (this.IsErrorEnabled)
            {
                this.serilogLogger.Error(message);
            }
        }

        /// <summary>
        /// Logs the specified message with Error severity.
        /// </summary>
        /// <param name="format">The message or format template.</param>
        /// <param name="args">Any arguments required for the format template.</param>
        public override void Error(string format, params object[] args)
        {
            if (this.IsErrorEnabled)
            {
                this.serilogLogger.Error(format, args);
            }
        }

        /// <summary>
        /// Logs the specified message with Fatal severity.
        /// </summary>
        /// <param name="format">The message or format template.</param>
        /// <param name="args">Any arguments required for the format template.</param>
        public override void Fatal(string format, params object[] args)
        {
            if (this.IsFatalEnabled)
            {
                this.serilogLogger.Fatal(format, args);
            }
        }

        /// <summary>
        /// Logs the specified exception with Fatal severity.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="format">The message or format template.</param>
        /// <param name="args">Any arguments required for the format template.</param>
        public override void Fatal(Exception exception, string format, params object[] args)
        {
            if (this.IsFatalEnabled)
            {
                this.serilogLogger.Fatal(exception, format, args);
            }
        }

        /// <summary>
        /// Logs the specified exception with Fatal severity.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception to log.</param>
        public override void FatalException(string message, Exception exception)
        {
            if (this.IsFatalEnabled)
            {
                this.serilogLogger.Fatal(exception, message);
            }
        }

        /// <summary>
        /// Logs the specified message with Info severity.
        /// </summary>
        /// <param name="format">The message or format template.</param>
        /// <param name="args">Any arguments required for the format template.</param>
        public override void Info(string format, params object[] args)
        {
            if (this.IsInfoEnabled)
            {
                this.serilogLogger.Information(format, args);
            }
        }

        /// <summary>
        /// Logs the specified exception with Info severity.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="format">The message or format template.</param>
        /// <param name="args">Any arguments required for the format template.</param>
        public override void Info(Exception exception, string format, params object[] args)
        {
            if (this.IsInfoEnabled)
            {
                this.serilogLogger.Information(exception, format, args);
            }
        }

        /// <summary>
        /// Logs the specified exception with Info severity.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception to log.</param>
        public override void InfoException(string message, Exception exception)
        {
            if (this.IsInfoEnabled)
            {
                this.serilogLogger.Fatal(exception, message);
            }
        }

        /// <summary>
        /// Logs the specified message with Trace severity.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Trace(string message)
        {
            if (this.IsTraceEnabled)
            {
                this.serilogLogger.Verbose(message);
            }
        }

        /// <summary>
        /// Logs the specified message with Trace severity.
        /// </summary>
        /// <param name="format">The message or format template.</param>
        /// <param name="args">Any arguments required for the format template.</param>
        public override void Trace(string format, params object[] args)
        {
            if (this.IsTraceEnabled)
            {
                this.serilogLogger.Verbose(format, args);
            }
        }

        /// <summary>
        /// Logs the specified exception with Trace severity.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="format">The message or format template.</param>
        /// <param name="args">Any arguments required for the format template.</param>
        public override void Trace(Exception exception, string format, params object[] args)
        {
            if (this.IsTraceEnabled)
            {
                this.serilogLogger.Verbose(exception, format, args);
            }
        }

        /// <summary>
        /// Logs the specified exception with Trace severity.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception to log.</param>
        public override void TraceException(string message, Exception exception)
        {
            if (this.IsTraceEnabled)
            {
                this.serilogLogger.Verbose(exception, message);
            }
        }

        /// <summary>
        /// Logs the specified message with Warn severity.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Warn(string message)
        {
            if (this.IsWarnEnabled)
            {
                this.serilogLogger.Warning(message);
            }
        }

        /// <summary>
        /// Logs the specified message with Warn severity.
        /// </summary>
        /// <param name="format">The message or format template.</param>
        /// <param name="args">Any arguments required for the format template.</param>
        public override void Warn(string format, params object[] args)
        {
            if (this.IsWarnEnabled)
            {
                this.serilogLogger.Fatal(format, args);
            }
        }

        /// <summary>
        /// Logs the specified exception with Warn severity.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="format">The message or format template.</param>
        /// <param name="args">Any arguments required for the format template.</param>
        public override void Warn(Exception exception, string format, params object[] args)
        {
            if (this.IsWarnEnabled)
            {
                this.serilogLogger.Fatal(exception, format, args);
            }
        }
    }
}