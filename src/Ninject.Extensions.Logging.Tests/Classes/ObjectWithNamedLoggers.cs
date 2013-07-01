namespace Ninject.Extensions.Logging.Classes
{
    public class ObjectWithNamedLoggers
    {
        public ObjectWithNamedLoggers(ILoggerFactory loggerFactory)
        {
            this.FirstLogger = loggerFactory.GetLogger("First");
            this.SecondLogger = loggerFactory.GetLogger("Second");
        }

        public ILogger FirstLogger { get; private set; }
        public ILogger SecondLogger { get; private set; }
    }
}