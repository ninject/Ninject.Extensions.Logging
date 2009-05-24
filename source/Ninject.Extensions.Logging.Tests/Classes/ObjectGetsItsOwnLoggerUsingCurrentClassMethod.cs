namespace Ninject.Extensions.Logging.Tests.Classes
{
    public class ObjectGetsItsOwnLoggerUsingCurrentClassMethod
    {
        private readonly ILogger _logger;

// ReSharper disable SuggestBaseTypeForParameter
        public ObjectGetsItsOwnLoggerUsingCurrentClassMethod( IKernel kernel )
// ReSharper restore SuggestBaseTypeForParameter
        {
            _logger = kernel.Get<ILoggerFactory>().GetCurrentClassLogger();
        }

        public ILogger Logger
        {
            get { return _logger; }
        }
    }
}