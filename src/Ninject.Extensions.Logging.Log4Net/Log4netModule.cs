// 
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2007-2010, Enkari, Ltd.
//
// Co-Author: Remo Gloor <remo.gloor@gmail.com>
// Copyright (c) 2010, bbv Software Engineering AG
// 
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
// 

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
            this.Bind<ILoggerFactory>().To<Log4NetLoggerFactory>().InSingletonScope();
            base.Load();
        }
    }
}