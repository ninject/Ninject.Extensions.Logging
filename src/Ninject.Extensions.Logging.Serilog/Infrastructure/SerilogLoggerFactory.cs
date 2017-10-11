// -------------------------------------------------------------------------------------------------
// <copyright file="SerilogLoggerFactory.cs" company="Ninject Project Contributors">
//   Copyright (c) 2011-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.Extensions.Logging.Serilog.Infrastructure
{
    using System;

    /// <summary>
    /// An implementation of a logger factory that creates <see cref="SerilogLogger"/>s.
    /// </summary>
    public class SerilogLoggerFactory : LoggerFactoryBase
    {
        /// <summary>
        /// Creates a logger for the specified type.
        /// </summary>
        /// <param name="type">The type to create the logger for.</param>
        /// <returns>The newly-created logger.</returns>
        protected override ILogger CreateLogger(Type type)
        {
            return new SerilogLogger(type);
        }

        /// <summary>
        /// Creates a logger with the specified name.
        /// </summary>
        /// <param name="name">The explicit name to create the logger for.  If null, the type's FullName will be used.</param>
        /// <returns>The newly-created logger.</returns>
        protected override ILogger CreateLogger(string name)
        {
            return new SerilogLogger(name);
        }
    }
}