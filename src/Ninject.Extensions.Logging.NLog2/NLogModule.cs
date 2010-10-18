//
// Author: Remo Gloor <remo.gloor@gmail.com>
// Copyright (c) 2010, bbv Software Engineering AG
//
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
//

namespace Ninject.Extensions.Logging.NLog2
{
    using Ninject.Extensions.Logging.NLog2.Infrastructure;

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