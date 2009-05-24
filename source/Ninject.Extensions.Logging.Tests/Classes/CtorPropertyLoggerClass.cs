namespace Ninject.Extensions.Logging.Tests.Classes
{
    public class CtorPropertyLoggerClass
    {
        public CtorPropertyLoggerClass( ILogger logger )
        {
            Logger = logger;
        }

        public ILogger Logger { get; private set; }
    }
}