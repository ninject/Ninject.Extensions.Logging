//-------------------------------------------------------------------------------
// <copyright file="NLogTestingContext.cs" company="bbv Software Services AG">
//   Copyright (c) 2010 Software Services AG
//   Remo Gloor (remo.gloor@gmail.com)
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

namespace Ninject.Extensions.Logging.NLog3.Infrastructure
{
    using System;
    using Ninject.Extensions.Logging.Infrastructure;
    using Ninject.Modules;

    using Xunit;

    /// <summary>
    /// The context for testing NLog3
    /// </summary>
    public abstract class NLogTestingContext : CommonTests
    {
        /// <summary>
        /// The NLog3 module
        /// </summary>
        private readonly INinjectModule module;

        /// <summary>
        /// Initializes a new instance of the <see cref="NLogTestingContext"/> class.
        /// </summary>
        protected NLogTestingContext()
        {
            this.module = new NLogModule();
        }

        /// <summary>
        /// Gets the test modules.
        /// </summary>
        /// <value>The test modules.</value>
        public override INinjectModule[] TestModules
        {
            get { return new[] { this.module }; }
        }

        /// <summary>
        /// Gets the type of the logger.
        /// </summary>
        /// <value>The type of the logger.</value>
        public override Type LoggerType
        {
            get
            {
                return typeof(NLogLogger);
            }
        }
    }
}