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

namespace Ninject.Extensions.Logging
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using Ninject.Activation;
    using Ninject.Components;

    /// <summary>
    /// A baseline definition of a logger factory, which tracks loggers as flyweights by type.
    /// Custom logger factories should generally extend this type.
    /// </summary>
    public abstract class LoggerFactoryBase : NinjectComponent, ILoggerFactory
    {
        /// <summary>
        /// Maps types to their loggers.
        /// </summary>
        private readonly Dictionary<Type, ILogger> loggers = new Dictionary<Type, ILogger>();

        /// <summary>
        /// Gets the logger for the specified type, creating it if necessary.
        /// </summary>
        /// <param name="type">The type to create the logger for.</param>
        /// <returns>The newly-created logger.</returns>
        public ILogger GetLogger(Type type)
        {
            lock (this.loggers)
            {
                if (this.loggers.ContainsKey(type))
                {
                    return this.loggers[type];
                }

                ILogger logger = this.CreateLogger(type);
                this.loggers.Add(type, logger);

                return logger;
            }
        }

        /// <summary>
        /// Gets the logger for the specified activation context, creating it if necessary.
        /// </summary>
        /// <param name="context">The ninject creation context.</param>
        /// <returns>The newly-created logger.</returns>
        public ILogger GetLogger(IContext context)
        {
            return this.GetLogger(context.Request.Target.Member.DeclaringType);
        }

#if !SILVERLIGHT && !NETCF
        /// <summary>
        /// Gets the logger for the class calling this method.
        /// </summary>
        /// <returns>The newly-created logger.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public ILogger GetCurrentClassLogger()
        {
            var frame = new StackFrame(1, false);
            return this.GetLogger(frame.GetMethod().DeclaringType);
        }
#endif

        /// <summary>
        /// Creates a logger for the specified type.
        /// </summary>
        /// <param name="type">The type to create the logger for.</param>
        /// <returns>The newly-created logger.</returns>
        protected abstract ILogger CreateLogger(Type type);
    }
}