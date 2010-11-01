namespace Ninject.Extensions.Logging.Classes
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