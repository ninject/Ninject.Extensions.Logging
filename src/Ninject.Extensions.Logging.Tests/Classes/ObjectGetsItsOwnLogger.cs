#region Using Directives

using System.Reflection;

#endregion

namespace Ninject.Extensions.Logging.Tests.Classes
{
    public class ObjectGetsItsOwnLogger
    {
        private readonly ILogger _logger;

// ReSharper disable SuggestBaseTypeForParameter
        public ObjectGetsItsOwnLogger( IKernel kernel )
// ReSharper restore SuggestBaseTypeForParameter
        {
            _logger = kernel.Get<ILoggerFactory>().GetLogger( MethodBase.GetCurrentMethod().DeclaringType );
        }

        public ILogger Logger
        {
            get { return _logger; }
        }
    }
}