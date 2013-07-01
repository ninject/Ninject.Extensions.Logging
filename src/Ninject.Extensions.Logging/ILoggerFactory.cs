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
    using System;
    using Ninject.Activation;
    using Ninject.Components;

    /// <summary>
    /// Factory for loggers
    /// </summary>
    public interface ILoggerFactory : INinjectComponent
    {
        /// <summary>
        /// Gets the logger for the specified type, creating it if necessary.
        /// </summary>
        /// <param name="type">The type to create the logger for.</param>
        /// <returns>The newly-created logger.</returns>
        ILogger GetLogger(Type type);

        /// <summary>
        /// Gets a custom-named logger for the specified type, creating it if necessary.
        /// </summary>
        /// <param name="name">The explicit name to create the logger for.  If null, the type's FullName will be used.</param>
        /// <returns>The newly-created logger.</returns>
        ILogger GetLogger(string name);

        /// <summary>
        /// Gets the logger for the specified activation context, creating it if necessary.
        /// </summary>
        /// <param name="context">The context for which a logger is created.</param>
        /// <returns>The newly-created logger.</returns>
        ILogger GetLogger(IContext context);
        
#if !SILVERLIGHT && !NETCF
        /// <summary>
        /// Gets the logger for the class calling this method.
        /// </summary>
        /// <returns>The newly-created logger.</returns>
        ILogger GetCurrentClassLogger();
#endif
    }
}