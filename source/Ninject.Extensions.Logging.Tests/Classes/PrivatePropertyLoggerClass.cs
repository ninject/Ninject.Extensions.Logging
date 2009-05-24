namespace Ninject.Extensions.Logging.Tests.Classes
{
    public class PrivatePropertyLoggerClass
    {
        [Inject]
        public ILogger Logger { get; set; }
    }
}