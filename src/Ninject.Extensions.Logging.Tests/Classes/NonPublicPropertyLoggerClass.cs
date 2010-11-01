namespace Ninject.Extensions.Logging.Classes
{
    public class NonPublicPropertyLoggerClass
    {
        [Inject]
        internal ILogger Logger { get; set; }
    }
}