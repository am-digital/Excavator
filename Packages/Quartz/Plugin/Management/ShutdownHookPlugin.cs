#region License
/* 
 * All content copyright Terracotta, Inc., unless otherwise indicated. All rights reserved. 
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not 
 * use this file except in compliance with the License. You may obtain a copy 
 * of the License at 
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0 
 *   
 * Unless required by applicable law or agreed to in writing, software 
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT 
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
 * License for the specific language governing permissions and limitations 
 * under the License.
 * 
 */
#endregion

using System;
using System.Globalization;

using Quartz.Spi;

namespace Quartz.Plugin.Management
{
    /// <summary> 
    /// This plugin catches the event of the VM terminating (such as upon a CRTL-C)
    /// and tells the scheuler to Shutdown.
    /// </summary>
    /// <seealso cref="IScheduler.Shutdown(bool)" />
    /// <author>James House</author>
    /// <author>Marko Lahma (.NET)</author>
    public class ShutdownHookPlugin : ISchedulerPlugin
    {
        private bool cleanShutdown = true;

        /// <summary> 
        /// Determine whether or not the plug-in is configured to cause a clean
        /// Shutdown of the scheduler.
        /// <para>
        /// The default value is <see langword="true" />.
        /// </para>
        /// </summary>
        /// <seealso cref="IScheduler.Shutdown(bool)" />
        public virtual bool CleanShutdown
        {
            get { return cleanShutdown; }
            set { cleanShutdown = value; }
        }

        /// <summary>
        /// Called during creation of the <see cref="IScheduler" /> in order to give
        /// the <see cref="ISchedulerPlugin" /> a chance to Initialize.
        /// </summary>
        public virtual void Initialize(string pluginName, IScheduler scheduler)
        {
            AppDomain.CurrentDomain.ProcessExit += (sender, ea) =>
                                            {
                                                
                                                try
                                                {
                                                    scheduler.Shutdown(CleanShutdown);
                                                }
                                                catch (SchedulerException)
                                                {
                                                   
                                                }
                                            };
        }

        /// <summary>
        /// Called when the associated <see cref="IScheduler" /> is started, in order
        /// to let the plug-in know it can now make calls into the scheduler if it
        /// needs to.
        /// </summary>
        public virtual void Start()
        {
            // do nothing.
        }

        /// <summary>
        /// Called in order to inform the <see cref="ISchedulerPlugin" /> that it
        /// should free up all of it's resources because the scheduler is shutting
        /// down.
        /// </summary>
        public virtual void Shutdown()
        {
            // nothing to do in this case (since the scheduler is already shutting
            // down)
        }
    }
}