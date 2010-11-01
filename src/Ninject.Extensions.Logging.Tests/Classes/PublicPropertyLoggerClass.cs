namespace Ninject.Extensions.Logging.Classes
{
    public class PublicPropertyLoggerClass
    {
        [Inject]
        public ILogger Logger { get; set; }
    }
}