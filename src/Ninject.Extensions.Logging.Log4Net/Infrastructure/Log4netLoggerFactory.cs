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

namespace Ninject.Extensions.Logging.Log4net.Infrastructure
{
    using System;

    /// <summary>
    /// An implementation of a logger factory that creates <see cref="Log4NetLogger"/>s.
    /// </summary>
    public class Log4NetLoggerFactory : LoggerFactoryBase
    {
        /// <summary>
        /// Creates a logger for the specified type.
        /// </summary>
        /// <param name="type">The type to create the logger for.</param>
        /// <param name="name">The explicit name to create the logger for.  If null, the type's FullName will be used.</param>
        /// <returns>The newly-created logger.</returns>
        protected override ILogger CreateLogger(Type type, string name)
        {
            return new Log4NetLogger(type, name);
        }
    }
}