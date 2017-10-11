// -------------------------------------------------------------------------------------------------
// <copyright file="Log4netModule.cs" company="Ninject Project Contributors">
//   Copyright (c) 2007-2010 Enkari, Ltd.
//   Copyright (c) 2010 bbv Software Engineering AG
//   Copyright (c) 2011-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.Extensions.Logging.Log4net
{
    using Ninject.Extensions.Logging.Log4net.Infrastructure;

    /// <summary>
    /// Extends the functionality of the kernel, providing integration between the Ninject
    /// logging infrastructure and log4net.
    /// </summary>
    public class Log4NetModule : LoggerModuleBase
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<ILoggerFactory>().ToConstant(new Log4NetLoggerFactory());
            base.Load();
        }
    }
}