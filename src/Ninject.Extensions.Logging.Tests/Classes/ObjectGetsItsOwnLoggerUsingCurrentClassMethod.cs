namespace Ninject.Extensions.Logging.Classes
{
    using System.Runtime.CompilerServices;

#if !SILVERLIGHT
    public class ObjectGetsItsOwnLoggerUsingCurrentClassMethod
    {
        private readonly ILogger _logger;

// ReSharper disable SuggestBaseTypeForParameter
        [MethodImpl(MethodImplOptions.NoInlining)]
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
#endif
}