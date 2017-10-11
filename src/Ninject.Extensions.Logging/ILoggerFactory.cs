// -------------------------------------------------------------------------------------------------
// <copyright file="ILoggerFactory.cs" company="Ninject Project Contributors">
//   Copyright (c) 2007-2010 Enkari, Ltd.
//   Copyright (c) 2010 bbv Software Engineering AG
//   Copyright (c) 2011-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.Extensions.Logging
{
    using System;
    using Ninject.Activation;

    /// <summary>
    /// Factory for loggers
    /// </summary>
    public interface ILoggerFactory
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