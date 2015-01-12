//-------------------------------------------------------------------------------
// <copyright file="SerilogLoggerFactory.cs" company="Ninject Project Contributors">
//   Copyright (c) 2015 Ninject Project Contributors
//   Authors: Scott Xu (scott-xu@msn.com)
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

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