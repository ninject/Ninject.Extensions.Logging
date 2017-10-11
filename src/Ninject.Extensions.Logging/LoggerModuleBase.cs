// -------------------------------------------------------------------------------------------------
// <copyright file="LoggerModuleBase.cs" company="Ninject Project Contributors">
//   Copyright (c) 2007-2010 Enkari, Ltd.
//   Copyright (c) 2010 bbv Software Engineering AG
//   Copyright (c) 2011-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.Extensions.Logging
{
    using Ninject.Modules;

    /// <summary>
    /// Base implementation for logger modules
    /// </summary>
    public abstract class LoggerModuleBase : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<ILogger>().ToMethod(context => context.Kernel.Get<ILoggerFactory>().GetLogger(context));
        }
    }
}