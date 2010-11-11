namespace Ninject.Extensions.Logging.Classes
{
    using System;

    public class CtorPropertyLoggerClass
    {
        public CtorPropertyLoggerClass( ILogger logger )
        {
            Logger = logger;
        }

        public void LogInfo(string format, params object[] args)
        {
            this.Logger.Info(format, args);
        }

        public void LogInfoWithException(Exception e, string format, params object[] args)
        {
            this.Logger.Info(e, format, args);
        }

        public void LogDebug(string format, params object[] args)
        {
            this.Logger.Debug(format, args);
        }

        public void LogDebugWithException(Exception e, string format, params object[] args)
        {
            this.Logger.Debug(e, format, args);
        }

        public void LogError(string format, params object[] args)
        {
            this.Logger.Error(format, args);
        }

        public void LogErrorWithException(Exception e, string format, params object[] args)
        {
            this.Logger.Error(e, format, args);
        }

        public void LogWarn(string format, params object[] args)
        {
            this.Logger.Warn(format, args);
        }

        public void LogWarnWithException(Exception e, string format, params object[] args)
        {
            this.Logger.Warn(e, format, args);
        }

        public void LogFatal(string format, params object[] args)
        {
            this.Logger.Fatal(format, args);
        }

        public void LogFatalWithException(Exception e, string format, params object[] args)
        {
            this.Logger.Fatal(e, format, args);
        }
        
        public ILogger Logger { get; private set; }
    }
}