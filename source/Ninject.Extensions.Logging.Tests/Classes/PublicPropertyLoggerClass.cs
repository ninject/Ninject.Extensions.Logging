namespace Ninject.Extensions.Logging.Tests.Classes
{
    public class PublicPropertyLoggerClass
    {
        [Inject]
        public ILogger Logger { get; set; }
    }
}