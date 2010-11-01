namespace Ninject.Extensions.Logging.Infrastructure
{
    using System;
    using Ninject.Modules;

    public interface ILoggingTestContext
    {
        INinjectModule[] TestModules { get; }
        Type LoggerType { get; }
    }
}