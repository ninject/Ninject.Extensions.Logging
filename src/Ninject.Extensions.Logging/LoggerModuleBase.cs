// 
// Author: Ian Davis <ian@innovatian.com>
// Copyright (c) 2009-2010, Innovatian Software, LLC
//
// Co-Author: Remo Gloor <remo.gloor@gmail.com>
// Copyright (c) 2010, bbv Software Engineering AG
// 
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
// 

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