#region Using Directives

using System.Reflection;

#endregion

namespace Ninject.Extensions.Logging.Classes
{
    #if !SILVERLIGHT && !NETCF
    public class ObjectWithNamedLoggers
    {
        private readonly ILogger _firstLogger;
        private readonly ILogger _secondLogger;

// ReSharper disable SuggestBaseTypeForParameter
        public ObjectWithNamedLoggers(ILoggerFactory loggerFactory)
// ReSharper restore SuggestBaseTypeForParameter
        {
            _firstLogger = loggerFactory.GetLogger(this.GetType(), "First");
            _secondLogger = loggerFactory.GetCurrentClassLogger("Second");
        }

        public ILogger FirstLogger
        {
            get { return _firstLogger; }
        }

        public ILogger SecondLogger
        {
            get { return _secondLogger; }
        }
    }
    #endif
}