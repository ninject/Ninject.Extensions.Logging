// -------------------------------------------------------------------------------------------------
// <copyright file="NLogModule.cs" company="Ninject Project Contributors">
//   Copyright (c) 2010 bbv Software Engineering AG
//   Copyright (c) 2011-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.Extensions.Logging.NLog4
{
    using Ninject.Extensions.Logging.NLog4.Infrastructure;

    /// <summary>
    /// Extends the functionality of the kernel, providing integration between the Ninject
    /// logging infrastructure and nlog.
    /// </summary>
    public class NLogModule : LoggerModuleBase
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<ILoggerFactory>().ToConstant(new NLogLoggerFactory());
            base.Load();
        }
    }
}