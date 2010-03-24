#region License

// 
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2007-2010, Enkari, Ltd.
// 
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
// 

#endregion

#region Using Directives

using Ninject.Extensions.Logging.Log4net.Infrastructure;
using Ninject.Modules;

#endregion

namespace Ninject.Extensions.Logging.Log4net
{
    /// <summary>
    /// Extends the functionality of the kernel, providing integration between the Ninject
    /// logging infrastructure and log4net.
    /// </summary>
    public class Log4netModule : LoggerModuleBase
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<ILoggerFactory>().ToConstant( new Log4netLoggerFactory() );
            base.Load();
        }
    }
}