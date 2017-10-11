// -------------------------------------------------------------------------------------------------
// <copyright file="SerilogModule.cs" company="Ninject Project Contributors">
//   Copyright (c) 2011-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.Extensions.Logging.Serilog
{
    using Ninject.Extensions.Logging.Serilog.Infrastructure;

    /// <summary>
    /// Extends the functionality of the kernel, providing integration between the Ninject
    /// logging infrastructure and nlog.
    /// </summary>
    public class SerilogModule : LoggerModuleBase
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<ILoggerFactory>().ToConstant(new SerilogLoggerFactory());
            base.Load();
        }
    }
}