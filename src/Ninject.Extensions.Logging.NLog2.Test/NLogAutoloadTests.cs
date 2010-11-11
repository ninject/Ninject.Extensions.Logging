//-------------------------------------------------------------------------------
// <copyright file="NLogAutoloadTests.cs" company="bbv Software Services AG">
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

namespace Ninject.Extensions.Logging.NLog2
{
#if !SILVERLIGHT && !NETCF
    using Ninject.Extensions.Logging.NLog2.Infrastructure;
    using Ninject.Modules;

    /// <summary>
    /// Tests with the module loaded by auto load extensions
    /// </summary>
    public class NLogAutoloadTests : NLogTestingContext
    {
        /// <summary>
        /// Creates the settings.
        /// </summary>
        /// <returns>The ninject settings</returns>
        protected override INinjectSettings CreateSettings()
        {
            return new NinjectSettings
                {
                    LoadExtensions = true, 
                    ExtensionSearchPattern = "Ninject.Extensions.Logging.NLog2.dll"
                };
        }

        /// <summary>
        /// Gets the test modules.
        /// </summary>
        /// <value>The test modules.</value>
        public override INinjectModule[] TestModules
        {
            get { return new INinjectModule[0]; }
        }
    }
#endif
}