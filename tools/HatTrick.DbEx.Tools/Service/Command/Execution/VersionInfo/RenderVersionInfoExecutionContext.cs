#region license
// Copyright (c) HatTrick Labs, LLC.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/HatTrickLabs/db-ex
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HatTrick.DbEx.Tools.Service
{
    public class RenderVersionInfoExecutionContext : ExecutionContext
    {
        #region internals
        private static Dictionary<SupportedPlatform, Lazy<ResourceManager>> _resourceManagers = new();
        private static List<SupportedPlatform> _supportedPlatforms = new List<SupportedPlatform>(Enum.GetValues<SupportedPlatform>());

        private readonly string[] OPTION_KEYS = new string[]
        {
            "--help", "-?",     // help
        };
        #endregion

        #region interface
        public static string[] CommandTextValues { get; } = new string[] { "version", "ver" };
        #endregion

        #region constructors
        public RenderVersionInfoExecutionContext(string command) : this(command, null)
        {
               
        }

        public RenderVersionInfoExecutionContext(string command, string? options) : base(command, options)
        {
            base.EnsureOptions(OPTION_KEYS);
        }
        #endregion

        #region execute
        public override void Execute()
        {
            base.Execute();

            if (base.HelpOptionExists())
            {
                //render execution context help
                this.PushHelpFeedback();
            }
            else
            {
                Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version!;
                ServiceDispatch.Feedback.Push(To.ConsoleOnly, $"HatTrick Labs dbex cli version [{version}]");
                ServiceDispatch.Feedback.Push(To.ConsoleOnly, "Runtime version compatibility:");

                foreach (var platform in PackageCompatibility.GetPlatformCompatibility()) 
                {
                    ServiceDispatch.Feedback.Push(To.ConsoleOnly, $"- {platform.Key}: {platform.Value.Aggregate("[", (x,v) => x += $"{v}, ", x => $"{x.TrimEnd(' ', ',')}]")}");
                }

                ServiceDispatch.Feedback.Push(To.ConsoleOnly, string.Empty);
            }

            base.Complete();
        }
        #endregion

        #region push help feedback
        private void PushHelpFeedback()
        {
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, "«Usage:  »Green");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, "dbex version");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, string.Empty);
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, "Notes:»Green");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, $"{base.Tab}renders package version and assembly version.");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, string.Empty);
        }
        #endregion
    }

    
}
