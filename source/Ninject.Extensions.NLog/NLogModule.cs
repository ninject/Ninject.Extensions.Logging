#region License

//
// Author: Ivan Porto Carrero <ivan@flanders.co.nz>
// Copyright © 2008-2010, Flanders International Marketing Ltd.
// Copyright © 2007-2010, Enkari, Ltd.
// Copyright © 2009-2010, Innovatian Software, LLC
//
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
//

#endregion

#region Using Directives

using Ninject.Extensions.Logging.NLog.Infrastructure;

#endregion

namespace Ninject.Extensions.Logging.NLog
{
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
            Bind<ILoggerFactory>().ToConstant( new NLogLoggerFactory() );
            base.Load();
        }
    }
}