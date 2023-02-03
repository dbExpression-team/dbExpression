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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using HatTrick.Model.Sql;
using HatTrick.Model.MsSql;
using HatTrick.Text.Templating;
using HatTrick.DbEx.Tools.Configuration;
using System.Linq;
using System.Reflection;
using HatTrick.DbEx.Tools.Model;
using HatTrick.DbEx.Tools.Builder;
using HatTrick.DbEx.Tools.Resources;
using System.Text.Json;
using System.Text.Json.Serialization;
using ResourceAccessor = HatTrick.DbEx.Tools.Resources.ResourceAccessor;

namespace HatTrick.DbEx.Tools.Service
{
    public class CodeGenerateExecutionContext : ExecutionContext
    {
        #region internals
        private readonly string[] OPTION_KEYS = new string[]
        {
            "--help", "-?", //help
            "--path", "-p", //config file path
            "--output", "-o" //command line override of output path
        };
        private readonly string DEFAULT_ROOT_NAMESPACE = "DbEx";
        private readonly string DEFAULT_DATABASE_ACCESSOR = "db";
        private readonly string DEFAULT_CONFIG_PATH = "./";
        private readonly string DEFAULT_CONFIG_NAME = "dbex.config.json";
        private readonly string DEFAULT_OUTPUT_PATH = "./DbEx";
        private readonly char[] INVALID_FILENAME_CHARS = Path.GetInvalidFileNameChars();

        private readonly HashSet<string> mssqlVersions = new () { "2005", "2008", "2012", "2014", "2016", "2017", "2019", "2022" };
        #endregion

        #region interface
        public static string[] CommandTextValues { get; } = new string[] { "generate", "gen" };
        #endregion

        #region constructors
        public CodeGenerateExecutionContext(string command) : this(command, null)
        {
        }

        public CodeGenerateExecutionContext(string command, string? options) : base(command, options)
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
                base.Complete();
                return;
            }

            ServiceDispatch.Feedback.Push(To.Info, "Executing code generation");

            string configPath = this.ResolveConfigPath();

            DbExConfig? config = GetConfig(configPath);
            if (config is null)
            {
                ServiceDispatch.Feedback.Push(To.Error, $"Could not resolve DbEx config at path {configPath}");
                return;
            }
            ServiceDispatch.Feedback.Push(To.Info, "initialized DbEx config");

            this.EnsureConfig(config);

            this.EnsureWorkingDirectory(config, configPath);

            ServiceDispatch.Feedback.Push(To.ConsoleOnly, "«Current working directory:  »Green");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, base.WorkingDirectory);

            config.OutputDirectory = this.ResolveOutputDirectory(config);

            ServiceDispatch.Feedback.Push(To.Info, "ensured output directory");

            switch (config.Source!.Platform!.Key)
            {
                case SupportedPlatform.MsSql: new MsSqlModelRenderer(config).Render(); break;
                default: throw new NotSupportedException($"Platform type {config.Source!.Platform!.Key} is not supported.");
            }

            base.Complete();
        }        
        #endregion

        #region resolve config path
        protected string ResolveConfigPath()
        {
            if (base.TryGetOption(out string? path, out string? keyUsed, "--path", "-p"))
            {
                //allow for a path with a file name... or a directory and we will assume default file name...
                if (!ServiceDispatch.IO.FileExists(path!))
                {
                    if (!ServiceDispatch.IO.DirectoryExists(path!))
                    {
                        //it's not a valid file or directory (absolute or relative)...
                        throw new CommandException($"Command option '{keyUsed}' does not point to a valid file or directory. Value provided: {path}");
                    }
                    path = Path.Combine(path!, DEFAULT_CONFIG_NAME);
                }
            }
            else
            {
                //assume default path...
                path = Path.Combine(DEFAULT_CONFIG_PATH, DEFAULT_CONFIG_NAME);
            }

            if (!ServiceDispatch.IO.FileExists(path!))
            {
                throw new CommandException($"Could not resolve config json file at path: {path}");
            }

            return Path.GetFullPath(path!);
        }
        #endregion

        #region resolve output path
        protected string ResolveOutputDirectory(DbExConfig config)
        {
            if (base.TryGetOption(out string? optionPath, out string? _, "--output", "-o"))
            {
                if (!string.IsNullOrEmpty(config.OutputDirectory))
                {
                    ServiceDispatch.Feedback.Push(To.Warn, $"Encountered --output command option and outputDirectory config setting, command option used");
                }
                config.OutputDirectory = optionPath;
            }

            this.EnsureOutputDirectory(config);

            return config.OutputDirectory!;
        }
        #endregion

        #region get config
        protected static DbExConfig? GetConfig(string path)
        {
            try
            {
                string json = ServiceDispatch.IO.GetFileText(path, Encoding.UTF8);
                DbExConfig? config = JsonSerializer.Deserialize<DbExConfig>(
                    json,
                    new JsonSerializerOptions
                    {
                        ReadCommentHandling = JsonCommentHandling.Skip,
                        PropertyNameCaseInsensitive = true,
                        Converters = { new JsonStringEnumConverter() }
                    }
                );
                return config;
            }
            catch (JsonException e) 
            {
                throw new Exception($"Could not deserialize the configuration file at path '{path}'.", e);
            }
        }
        #endregion

        #region ensure config
        protected void EnsureConfig(DbExConfig config)
        {
            if (config.Source is null)
            {
                throw new CommandException($"DbEx configuration file missing required key: {nameof(config.Source)}");
            }

            if (config.Source?.Platform is null)
            {
                throw new CommandException($"DbEx configuration file missing required key: {nameof(config.Source)}.{nameof(config.Source.Platform)}");
            }
            else
            { 
                if (config.Source.Platform.Key is null)
                {
                    throw new CommandException($"DbEx configuration file missing required key: {nameof(config.Source)}.{nameof(config.Source.Platform)}.{nameof(config.Source.Platform.Key)}");
                }
                if (string.IsNullOrWhiteSpace(config.Source.Platform.Version))
                {
                    throw new CommandException($"DbEx configuration file missing required key: {nameof(config.Source)}.{nameof(config.Source.Platform)}.{nameof(config.Source.Platform.Version)}");
                }
            }

            if (config.Source?.ConnectionString is null)
            {
                throw new CommandException($"DbEx configuration file missing required key: {nameof(config.Source)}.{nameof(config.Source.ConnectionString)}");
            }

            if (string.IsNullOrWhiteSpace(config.Source?.ConnectionString?.Value))
            {
                throw new CommandException($"DbEx configuration file missing required key: {nameof(config.Source)}.{nameof(config.Source.ConnectionString)}.{nameof(config.Source.ConnectionString.Value)}");
            }

            if (string.IsNullOrWhiteSpace(config.RootNamespace))
            {
                //just provide a root namespace default...
                config.RootNamespace = DEFAULT_ROOT_NAMESPACE;
                ServiceDispatch.Feedback.Push(To.Warn, $"DbEx configuration file does not contain a value for key: {nameof(config.RootNamespace)}, defaulting to '{DEFAULT_ROOT_NAMESPACE}'");
            }

            if (string.IsNullOrEmpty(config.DatabaseAccessor))
            {
                config.DatabaseAccessor = DEFAULT_DATABASE_ACCESSOR;
                //svc.Feedback.Push(To.Warn, $"DbEx configuration file does not contain a value for key: {nameof(config.DatabaseAccessor)}, defaulting to '{DEFAULT_DATABASE_ACCESSOR}'");
            }

            if (config is null || config.Overrides is null)
                return;

            Override? o;
            for (int i = 0; i < config.Overrides.Length; i++)
            {
                o = config.Overrides[i];

                //warnings...
                if (o is null)
                {
                    ServiceDispatch.Feedback.Push(To.Warn, $"encountered null override value at overrides[{i}]");
                    return;
                }
                if (o.Apply is null)
                {
                    ServiceDispatch.Feedback.Push(To.Warn, $"encountered null override.apply value at overrides[{i}]");
                    return;
                }
                if (o.Apply.To is null)
                {
                    ServiceDispatch.Feedback.Push(To.Warn, $"encountered null override.apply.to value at overrides[{i}]");
                    return;
                }
                if (o.Apply.To.Path is null)
                {
                    ServiceDispatch.Feedback.Push(To.Warn, $"encountered null override.apply.to.path value at overrides[{i}]");
                    return;
                }
                if (o.Apply.To.Path == string.Empty)
                {
                    ServiceDispatch.Feedback.Push(To.Warn, $"encountered empty override.apply.to.path value at overrides[{i}]");
                    return;
                }

                //if all relavent values provided, check for hard stop errors
                //errors
                if (o.Apply.To.Path == "." && (string.Compare(o.Apply.Name, config.RootNamespace, true) == 0))
                {
                    //setting the root namespace equal the db name causes compile circular dependency
                    string msg = string.Empty;
                    msg += $"encountered override.apply.name=\"{o.Apply.Name}\" for override.apply.to.path=\"{o.Apply.To.Path}\" at overrides[{i}]";
                    msg += ($"  The rootNamespace cannot equal the database name.");
                    throw new CommandException(msg);
                }
            }
        }
        #endregion

        #region ensure working directory
        private void EnsureWorkingDirectory(DbExConfig config, string fullConfigPath)
        {
            if (string.IsNullOrEmpty(config.WorkingDirectory))
            {
                config.WorkingDirectory = base.WorkingDirectory;
                return;
            }

            bool isRelative = !Path.IsPathRooted(config.WorkingDirectory) && !Path.IsPathFullyQualified(config.WorkingDirectory);
            string working;
            if (isRelative)//if working directory is relative, it should be relative to the config .json file path
            {
                //set the working directory to the config file directory (we know it exists because we read the config)
                base.WorkingDirectory = Path.GetDirectoryName(fullConfigPath)!;

                //now we can get the full path of the config.workingDirectory (relative to the config file)
                working = Path.GetFullPath(config.WorkingDirectory);
            }
            else
            {
                //configured path is absolute or rooted ... get full path to ensure we have a rooted and fully qualified path.
                working = Path.GetFullPath(config.WorkingDirectory);
            }

            base.WorkingDirectory = working;
            config.WorkingDirectory = working;

            //error: if a file exists with this exact path
            if (ServiceDispatch.IO.FileExists(config.WorkingDirectory))
            {
                throw new CommandException($"A file exists at the same path you specified for the configured 'workingDirectory'");
            }

            if (!ServiceDispatch.IO.DirectoryExists(working))
            {
                ServiceDispatch.Feedback.Push(To.Warn, "No directory exists at configured 'workingDirectory'");
                ServiceDispatch.Feedback.Push(To.Warn, $"Attempting to create working directory: {working}");
                Directory.CreateDirectory(working);
            }

            ServiceDispatch.Feedback.Push(To.Info, $"applied working directory override");
        }
        #endregion

        #region ensure output directory
        protected void EnsureOutputDirectory(DbExConfig config)
        {
            //was value provided as option or config?
            bool isProvided = !string.IsNullOrWhiteSpace(config.OutputDirectory);

            if (!isProvided)
            {
                config.OutputDirectory = Path.Combine(base.WorkingDirectory, DEFAULT_OUTPUT_PATH);
            }
            else
            {
                bool isRooted = Path.IsPathRooted(config.OutputDirectory);
                if (!isRooted)
                {
                    config.OutputDirectory = Path.GetFullPath(config.OutputDirectory!);
                }
            }

            if (ServiceDispatch.IO.FileExists(config.OutputDirectory!))
            {
                throw new CommandException($"A file exists with the same name specified for configured 'outputDirectory'");
            }

            if (!ServiceDispatch.IO.DirectoryExists(config.OutputDirectory!))
            {
                string msg = isProvided
                    ? "No directory exists at provided 'outputDirectory'"
                    : "No directory exists at default 'outputDirectory'";

                ServiceDispatch.Feedback.Push(To.Warn, msg);
                ServiceDispatch.Feedback.Push(To.Warn, $"Attempting to create output directory: {config.OutputDirectory!}");
                Directory.CreateDirectory(config.OutputDirectory!);
            }
        }
        #endregion

        #region push help feedback
        private void PushHelpFeedback()
        {
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, "«Usage:  »Green");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, "dbex generate [options]");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, string.Empty);
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, "Options:»Green");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, $"{base.Tab}-p|--path <path to dbex.config.json>");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, string.Empty);
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, "Notes:»Green");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, $"{base.Tab}Path is assumed to be current working directory if the option is not provided.");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, $"{base.Tab}Path option value can be absolute or relative.");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, $"{base.Tab}default config file name is dbex.config.json and is assumed if path option points to a directory");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, string.Empty);
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, "Usage example(s):»Green");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, string.Empty);
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, $"Usage assuming dbex.config.json is in the current working directory:»Green");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, $"{base.Tab}dbex generate -p ./");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, $"{base.Tab}{base.Tab}{base.Tab}or");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, $"{base.Tab}dbex generate");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, string.Empty);
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, $"Usage assuming the dbex.config.json is in the config folder one direcory below current working directory:»Green");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, $"{base.Tab}dbex generate -p ./config");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, string.Empty);
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, $"Usage assuming the dbex.config.json is in the config folder one directory above current working directory:»Green");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, $"{base.Tab}dbex generate -p ../config");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, string.Empty);
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, $"Usage assuming the dbex.config.json resides at an absolute path:»Green");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, $"{base.Tab}dbex generate -p c:/cofigs/app1/dbex.config.json");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, string.Empty);
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, $"Usage assuming the dbex.config.json resides at a path that includes spaces:»Green");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, $"{base.Tab}dbex generate -p \"c:/my cofigs/app1/dbex.config.json\"");
        }
        #endregion
    }
}
