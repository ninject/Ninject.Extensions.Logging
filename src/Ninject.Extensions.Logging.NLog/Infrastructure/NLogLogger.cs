//
// Author: Ivan Porto Carrero <ivan@flanders.co.nz>
// Copyright (c) 2008-2010, Flanders International Marketing Ltd.
// Copyright (c) 2007-2010, Enkari, Ltd.
//
// Author: Remo Gloor <remo.gloor@gmail.com>
// Copyright (c) 2010, bbv Software Engineering AG
//
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
//

namespace Ninject.Extensions.Logging.NLog.Infrastructure
{
    using System;
    using global::NLog;

    /// <summary>
    /// A logger that integrates with nlog, passing all messages to a <see cref="Logger"/>.
    /// </summary>
    public class NLogLogger : LoggerBase
    {
        /// <summary>
        /// NLog logger.
        /// </summary>
        private readonly Logger nlogLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="NLogLogger"/> class.
        /// </summary>
        /// <param name="type">The type to associate with the logger.</param>
        public NLogLogger(Type type)
            : base(type)
        {
            this.nlogLogger = LogManager.GetLogger(type.FullName);
        }

        /// <summary>
        /// Gets a value indicating whether messages with Debug severity should be logged.
        /// </summary>
        public override bool IsDebugEnabled
        {
            get { return this.nlogLogger.IsDebugEnabled; }
        }

        /// <summary>
        /// Gets a value indicating whether messages with Info severity should be logged.
        /// </summary>
        public override bool IsInfoEnabled
        {
            get { return this.nlogLogger.IsInfoEnabled; }
        }

        /// <summary>
        /// Gets a value indicating whether messages with Trace severity should be logged.
        /// </summary>
        public override bool IsTraceEnabled
        {
            get { return this.nlogLogger.IsTraceEnabled; }
        }

        /// <summary>
        /// Gets a value indicating whether messages with Warn severity should be logged.
        /// </summary>
        public override bool IsWarnEnabled
        {
            get { return this.nlogLogger.IsWarnEnabled; }
        }

        /// <summary>
        /// Gets a value indicating whether messages with Error severity should be logged.
        /// </summary>
        public override bool IsErrorEnabled
        {
            get { return this.nlogLogger.IsErrorEnabled; }
        }

        /// <summary>
        /// Gets a value indicating whether messages with Fatal severity should be logged.
        /// </summary>
        public override bool IsFatalEnabled
        {
            get { return this.nlogLogger.IsFatalEnabled; }
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
                this.Log(LogLevel.Debug, exception, format, args);
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
                this.Log(LogLevel.Info, "{0}", message);
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
                this.Log(LogLevel.Debug, "{0}", message);
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
                this.Log(LogLevel.Debug, format, args);
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
                this.Log(LogLevel.Error, exception, format, args);
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
                this.Log(LogLevel.Fatal, "{0}", message);
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
                this.Log(LogLevel.Error, "{0}", message);
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
                this.Log(LogLevel.Error, format, args);
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
                this.Log(LogLevel.Fatal, format, args);
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
                this.Log(LogLevel.Fatal, exception, format, args);
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
                this.Log(LogLevel.Info, format, args);
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
                this.Log(LogLevel.Info, exception, format, args);
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
                this.Log(LogLevel.Trace, "{0}", message);
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
                this.Log(LogLevel.Trace, format, args);
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
                this.Log(LogLevel.Trace, exception, format, args);
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
                this.Log(LogLevel.Warn, "{0}", message);
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
                this.Log(LogLevel.Warn, format, args);
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
                this.Log(LogLevel.Warn, exception, format, args);
            }
        }

        /// <summary>
        /// Logs with the specified level while preserving the call site.
        /// </summary>
        /// <param name="level">The log level.</param>
        /// <param name="format">The message format.</param>
        /// <param name="args">The argsuments.</param>
        private void Log(LogLevel level, string format, params object[] args)
        {
            var le = new LogEventInfo(level, this.nlogLogger.Name, null, format, args);
            this.nlogLogger.Log(typeof(NLogLogger), le);
        }

        /// <summary>
        /// Logs with the specified level while preserving the call site.
        /// </summary>
        /// <param name="level">The log level.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="format">The message format.</param>
        /// <param name="args">The argsuments.</param>
        private void Log(LogLevel level, Exception exception, string format, params object[] args)
        {
            var le = new LogEventInfo(level, this.nlogLogger.Name, null, format, args, exception);
            this.nlogLogger.Log(typeof(NLogLogger), le);
        }
    }
}