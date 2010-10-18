#region Using Directives

using System;
using Ninject.Modules;

#endregion

namespace Ninject.Extensions.Logging.Tests.Infrastructure
{
    public interface ILoggingTestContext
    {
        INinjectModule[] TestModules { get; }
        Type LoggerType { get; }
    }
}