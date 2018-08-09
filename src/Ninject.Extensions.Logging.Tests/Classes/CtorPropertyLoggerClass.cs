namespace Ninject.Extensions.Logging.Classes
{
    using System;

    public class CtorPropertyLoggerClass
    {
        public CtorPropertyLoggerClass( ILogger logger )
        {
            this.Logger = logger;
        }

        public void LogTrace(string message)
        {
            this.Logger.Trace(message);
        }

        public void LogTraceWithArguments(string format, params object[] args)
        {
            this.Logger.Trace(format, args);
        }

        public void LogTraceException(string message, Exception exception)
        {
            this.Logger.TraceException(message, exception);
        }

        public void LogTraceWithException(Exception e, string format, params object[] args)
        {
            this.Logger.Trace(e, format, args);
        }

        public void LogInfo(string message)
        {
            this.Logger.Info(message);
        }

        public void LogInfoWithArguments(string format, params object[] args)
        {
            this.Logger.Info(format, args);
        }

        public void LogInfoException(string message, Exception exception)
        {
            this.Logger.InfoException(message, exception);
        }

        public void LogInfoWithException(Exception e, string format, params object[] args)
        {
            this.Logger.Info(e, format, args);
        }

        public void LogDebug(string message)
        {
            this.Logger.Debug(message);
        }

        public void LogDebugWithArguments(string format, params object[] args)
        {
            this.Logger.Debug(format, args);
        }

        public void LogDebugException(string message, Exception exception)
        {
            this.Logger.DebugException(message, exception);
        }

        public void LogDebugWithException(Exception e, string format, params object[] args)
        {
            this.Logger.Debug(e, format, args);
        }

        public void LogError(string message)
        {
            this.Logger.Error(message);
        }

        public void LogErrorWithArguments(string format, params object[] args)
        {
            this.Logger.Error(format, args);
        }

        public void LogErrorException(string message, Exception exception)
        {
            this.Logger.ErrorException(message, exception);
        }

        public void LogErrorWithException(Exception e, string format, params object[] args)
        {
            this.Logger.Error(e, format, args);
        }

        public void LogWarn(string message)
        {
            this.Logger.Warn(message);
        }

        public void LogWarnWithArguments(string format, params object[] args)
        {
            this.Logger.Warn(format, args);
        }

        public void LogWarnException(string message, Exception exception)
        {
            this.Logger.WarnException(message, exception);
        }

        public void LogWarnWithException(Exception e, string format, params object[] args)
        {
            this.Logger.Warn(e, format, args);
        }

        public void LogFatal(string message)
        {
            this.Logger.Fatal(message);
        }

        public void LogFatalWithArguments(string format, params object[] args)
        {
            this.Logger.Fatal(format, args);
        }

        public void LogFatalException(string message, Exception exception)
        {
            this.Logger.FatalException(message, exception);
        }

        public void LogFatalWithException(Exception e, string format, params object[] args)
        {
            this.Logger.Fatal(e, format, args);
        }
        
        public ILogger Logger { get; private set; }
    }
}