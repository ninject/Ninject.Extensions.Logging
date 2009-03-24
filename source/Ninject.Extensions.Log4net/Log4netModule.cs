#region License

//
// Author: Nate Kohari <nkohari@gmail.com>
// Copyright (c) 2007-2009, Enkari, Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

#endregion

#region Using Directives

using Ninject.Extensions.Logging.Log4net.Infrastructure;
using Ninject.Modules;

#endregion

namespace Ninject.Extensions.Logging.Log4net
{
    /// <summary>
    /// Extends the functionality of the kernel, providing integration between the Ninject
    /// logging infrastructure and log4net.
    /// </summary>
    public class Log4netModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<ILoggerFactory>().ToConstant( new Log4netLoggerFactory() );
            Bind<ILogger>().To<Log4netLogger>();
        }
    }
}