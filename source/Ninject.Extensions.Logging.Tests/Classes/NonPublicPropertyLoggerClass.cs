namespace Ninject.Extensions.Logging.Tests.Classes
{
    public class NonPublicPropertyLoggerClass
    {
        [Inject]
        internal ILogger Logger { get; set; }
    }
}