#region Using Directives

using System;
using Ninject.Modules;

#endregion

namespace Ninject.Extensions.Logging.Tests.Infrastructure
{
    public interface ILoggingTestContext
    {
        INinjectModule TestModule { get; }
        Type LoggerType { get; }
    }
}