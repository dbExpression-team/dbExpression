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

﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using svc = HatTrick.DbEx.Tools.Service.ServiceDispatch;
using HatTrick.DbEx.Tools.Resources;

namespace HatTrick.DbEx.Tools.Service
{
    public class MakeConfigExecutionContext : ExecutionContext
    {
        #region internals
        private readonly string[] OPTION_KEYS = new string[] 
        {
            "--help", "-?",                 // help
            "--directory", "--dir", "-d",   //output directory
        };
        private readonly string SAMPLE_CONFIG_NAME = "dbex.config.json";
        private readonly string DEFAULT_OUTPUT_PATH = "./";
        #endregion

        #region interface
        public static string[] CommandTextValues { get; } = new string[] { "makeconfig", "mkconfig", "mkc" };
        #endregion

        #region constructors
        public MakeConfigExecutionContext(string command) : this(command, null)
        {
        }

        public MakeConfigExecutionContext(string command, string? options) : base(command, options)
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
                svc.Feedback.Push(To.Info, $"Executing make config");
                svc.Feedback.Push(To.ConsoleOnly, "«Current working directory:  »Green");
                svc.Feedback.Push(To.ConsoleOnly, base.WorkingDirectory);

                string path = this.ResolveOutputDirectory();

                WriteOutput(path);
            }

            base.Complete();
        }
        #endregion

        #region resolve output path
        private string ResolveOutputDirectory()
        {
            if (base.TryGetOption(out string? path, out string? keyUsed, "--directory", "--dir", "-d"))
            {
                if (!svc.IO.DirectoryExists(path!))
                {
                    throw new CommandException($"Command option '{keyUsed}' does not point to an existing directory: {path}");
                }
                path = Path.Combine(path!, SAMPLE_CONFIG_NAME);
            }
            else
            {
                //assume default path...default is current so it must exist...
                path = Path.Combine(DEFAULT_OUTPUT_PATH, SAMPLE_CONFIG_NAME);
            }

            if (svc.IO.FileExists(path))
            {
                throw new CommandException($"File already exists.  Path: {path}");
            }
            return path;
        }
        #endregion

        #region write output
        private static void WriteOutput(string path)
        {
            string resourcePath = $"{typeof(ResourceAccessor).Namespace}.DbExConfig.DbEx.Config.Example.json";
            Resource config = ResourceAccessor.GetResource(resourcePath);

            svc.Feedback.Push(To.Info, $"Writing dbex.config.json file to: {path}");
            if (!Path.IsPathFullyQualified(path))
            {
                svc.Feedback.Push(To.ConsoleOnly, $"«Absolute path:  »Green");
                svc.Feedback.Push(To.ConsoleOnly,Path.GetFullPath(path));
            }

            svc.IO.WriteFile(path, config.Value!, Encoding.UTF8);
        }
        #endregion

        #region push help feedback
        private void PushHelpFeedback()
        {
            svc.Feedback.Push(To.ConsoleOnly, "«Usage:  »Green");
            svc.Feedback.Push(To.ConsoleOnly, "dbex makeconfig [options]");
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            svc.Feedback.Push(To.ConsoleOnly, "Options:»Green");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}-d|--dir|--directory: <output directory for sample config json file>");
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            svc.Feedback.Push(To.ConsoleOnly, "Notes:»Green");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}Directory option value defaults to current working directory if the option is not provided.");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}Directory option value can be absolute or relative.");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}the output config file name is always {SAMPLE_CONFIG_NAME}");
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            svc.Feedback.Push(To.ConsoleOnly, "Usage example(s):»Green");
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            svc.Feedback.Push(To.ConsoleOnly, $"The following two commands produce the same results (output file written to current working directory):»Green");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}dbex makeconfig -d ./");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}{base.Tab}or");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}dbex makeconfig");
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            svc.Feedback.Push(To.ConsoleOnly, $"Usage for an absolute output directory path:»Green");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}dbex makeconfig -d c:/git/my-project");
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            svc.Feedback.Push(To.ConsoleOnly, $"Usage for a relative output directory path:»Green");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}dbex makeconfig -d ../../my-project");
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            svc.Feedback.Push(To.ConsoleOnly, $"Usage for a output directory path containing spaces:»Green");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}dbex makeconfig -d \"../../my project\"");
        }
        #endregion
    }
}
