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
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using Ninject.Activation;
    using Ninject.Activation.Caching;
    using Ninject.Components;

    /// <summary>
    /// A baseline definition of a logger factory, which tracks loggers as flyweights by type.
    /// Custom logger factories should generally extend this type.
    /// </summary>
    public abstract class LoggerFactoryBase : NinjectComponent, ILoggerFactory, IPruneable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerFactoryBase"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public LoggerFactoryBase(IKernel kernel)
        {
            kernel.Components.Get<ICachePruner>().Start(this);
        }

        /// <summary>
        /// Maps types to loggers.
        /// </summary>
        private readonly Dictionary<Type, WeakReference> loggersByType = new Dictionary<Type, WeakReference>();

        /// <summary>
        /// Maps names to loggers.
        /// </summary>
        private readonly Dictionary<string, WeakReference> loggersByName = new Dictionary<string, WeakReference>();

        /// <summary>
        /// Gets the logger for the specified type, creating it if necessary.
        /// </summary>
        /// <param name="type">The type to create the logger for.</param>
        /// <returns>The newly-created logger.</returns>
        public ILogger GetLogger(Type type)
        {
            lock (this.loggersByType)
            {
                if (this.loggersByType.ContainsKey(type))
                {
                    var cachedLogger = this.loggersByType[type].Target as ILogger;
                    if (cachedLogger == null)
                    {
                        cachedLogger = this.CreateLogger(type);
                    }

                    return cachedLogger;
                }

                var logger = this.CreateLogger(type);
                this.loggersByType.Add(type, new WeakReference(logger));

                return logger;
            }
        }

        /// <summary>
        /// Gets a custom-named logger for the specified type, creating it if necessary.
        /// </summary>
        /// <param name="name">The explicit name to create the logger for.  If null, the type's FullName will be used.</param>
        /// <returns>The newly-created logger.</returns>
        public ILogger GetLogger(string name)
        {
            lock (this.loggersByName)
            {
                if (this.loggersByName.ContainsKey(name))
                {
                    var cachedLogger = this.loggersByName[name].Target as ILogger;
                    if (cachedLogger == null)
                    {
                        cachedLogger = this.CreateLogger(name);
                    }

                    return cachedLogger;
                }

                var logger = this.CreateLogger(name);
                this.loggersByName.Add(name, new WeakReference(logger));

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
        /// The method info for GetCurrentClassLogger
        /// </summary>
        private static readonly MethodInfo getCurrentClassLoggerMethodInfo =
            typeof(LoggerFactoryBase).GetMethod("GetCurrentClassLogger", BindingFlags.Public | BindingFlags.Instance);

        /// <summary>
        /// Gets the logger for the class calling this method.
        /// </summary>
        /// <returns>The newly-created logger.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public ILogger GetCurrentClassLogger()
        {
            var frame = new StackFrame(0, false);
            if (frame.GetMethod() == getCurrentClassLoggerMethodInfo)
            {
                frame = new StackFrame(1, false);
            }

            var type = frame.GetMethod().DeclaringType;

            if (type == null)
            {
                throw new InvalidOperationException(string.Format("Can not determine current class. Method: {0}", frame.GetMethod()));
            }

            return this.GetLogger(type);
        }
#endif

        /// <summary>
        /// Prune dead loggers.
        /// </summary>
        public void Prune()
        {
            lock (this.loggersByName)
            {
                var deadLoggersByName = this.loggersByName.Where(kvp => !kvp.Value.IsAlive).ToList();
                foreach (var kvp in deadLoggersByName)
                {
                    this.loggersByName.Remove(kvp.Key);
                }
            }

            lock (this.loggersByType)
            {
                var deadLoggersByType = this.loggersByType.Where(kvp => !kvp.Value.IsAlive).ToList();
                foreach (var kvp in deadLoggersByType)
                {
                    this.loggersByType.Remove(kvp.Key);
                }
            }
        }

        /// <summary>
        /// Creates a logger for the specified type.
        /// </summary>
        /// <param name="type">The type to create the logger for.</param>
        /// <returns>The newly-created logger.</returns>
        protected abstract ILogger CreateLogger(Type type);

        /// <summary>
        /// Creates a logger with the specified name.
        /// </summary>
        /// <param name="name">The explicit name to create the logger for.  If null, the type's FullName will be used.</param>
        /// <returns>The newly-created logger.</returns>
        protected abstract ILogger CreateLogger(string name);
    }
}