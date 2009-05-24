#region Using Directives

using Ninject.Modules;

#endregion

namespace Ninject.Extensions.Logging.Tests.Infrastructure
{
    public interface ILoggingTestContext
    {
        INinjectModule TestModule { get; }
    }
}