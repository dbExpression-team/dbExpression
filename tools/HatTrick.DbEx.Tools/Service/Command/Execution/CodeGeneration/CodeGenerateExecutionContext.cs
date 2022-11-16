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
using Newtonsoft.Json;
using HatTrick.Model.Sql;
using HatTrick.Model.MsSql;
using HatTrick.Text.Templating;
using HatTrick.DbEx.Tools.Configuration;
using HatTrick.Reflection;
using System.Linq;
using System.Reflection;
using HatTrick.DbEx.Tools.Model;
using HatTrick.DbEx.Tools.Builder;
using HatTrick.DbEx.Tools.Resources;
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

            base.PushProgressFeedback("Executing code generation");

            string configPath = this.ResolveConfigPath();

            DbExConfig? config = GetConfig(configPath);
            if (config is null)
            {
                ServiceDispatch.Feedback.Push(To.Error, $"Could not resolve DbEx config at path {configPath}");
                return;
            }
            base.PushProgressFeedback("initialized DbEx config");

            this.EnsureConfig(config);

            this.EnsureWorkingDirectory(config, configPath);

            ServiceDispatch.Feedback.Push(To.ConsoleOnly, "«Current working directory:  »Green");
            ServiceDispatch.Feedback.Push(To.ConsoleOnly, base.WorkingDirectory);

            config.OutputDirectory = this.ResolveOutputDirectory(config);

            base.PushProgressFeedback("ensured output directory");

            base.PushProgressFeedback("starting sql model extraction");
            MsSqlModel sqlModel = BuildSqlModel(config);
            base.PushProgressFeedback("extracted full sql model");

            ApplySqlModelOverrides(config, sqlModel);
            base.PushProgressFeedback("applied model metadata");

            EnsureRenderSafe(config, sqlModel);

            this.RenderOutputs(sqlModel, config);
            base.PushProgressFeedback("code render completed");

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
            string json = ServiceDispatch.IO.GetFileText(path, Encoding.UTF8);
            DbExConfig? config = JsonConvert.DeserializeObject<DbExConfig>(json);
            return config;
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
                if (string.IsNullOrWhiteSpace(config.Source.Platform.Key))
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

            base.PushProgressFeedback($"applied working directory override");
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

        #region build sql model
        protected static MsSqlModel BuildSqlModel(DbExConfig config)
        {
            MsSqlModelBuilder sqlMdlBlder = new(config.Source?.ConnectionString!.Value!);
            bool failed = false;
            sqlMdlBlder.OnError += (ex) =>
            {
                failed = true;
                ServiceDispatch.Feedback.PushException(new ExceptionFeedback(ex));
            };

            MsSqlModel sqlModel = sqlMdlBlder.Build();

            if (failed)
            {
                ServiceDispatch.Feedback.Push(To.ConsoleOnly, string.Empty);
                throw new CommandException("Exception encountered building sql model");
            }

            return sqlModel;
        }
        #endregion

        #region apply sql model overrides
        protected static void ApplySqlModelOverrides(DbExConfig config, MsSqlModel model)
        {
            if (config is not null && config.Overrides is not null)
            {
                Override? o;
                for (int i = 0; i < config.Overrides.Length; i++)
                {
                    o = config.Overrides[i];

                    if (!EnsureOverride(o, i, config))
                        continue;

                    IList<INamedMeta> set = ResolveOverrideTarget(model, o);
                    if (set is null || set.Count == 0)
                    {
                        ServiceDispatch.Feedback.Push(To.Warn, $"overrides.apply.to.path: '{o.Apply.To?.Path}' at overrides[{i}] resolved 0 items");
                        continue;
                    }

                    ValidateOverride(o, i, set); //this only renders warnings

                    foreach (var item in set)
                    {
                        item.Meta = o.Apply.ToJson();
                    }
                }
            }
        }
        #endregion

        #region ensure render safe
        private void EnsureRenderSafe(DbExConfig config, MsSqlModel model)
        {
            if (config?.Source?.Platform?.Key != "MsSql")
                throw new CommandException("dbex.config error: source.platform.key: dbExpression only supports a value of MsSql.");

            if (!mssqlVersions.Contains(config?.Source?.Platform?.Version!))
                throw new CommandException($"dbex.config error: source.platform.version: dbExpression only supports MsSql versions {String.Join(',', mssqlVersions)}.");

            if (config?.Overrides is null)
                return;

            if (!config.Overrides.Any(ov => ov.Apply.To.Path == "."))
                return; //if override to path . exists, we caught this issue in ApplyOverrides

            if (string.Compare(config.RootNamespace, model.Name, true) == 0)
            {
                //setting the root namespace equal the db name causes compile circular dependency
                throw new CommandException($"dbex.config error: rootNamespace: {config.RootNamespace} - rootNamespace cannot equal database name: {model.Name}");
            }
        }
        #endregion

        #region ensure override
        private static bool EnsureOverride(Override o, int atIndex, DbExConfig config)
        {
            //warnings...
            if (o is null)
            {
                ServiceDispatch.Feedback.Push(To.Warn, $"encountered null override value at overrides[{atIndex}]");
                return false;
            }
            if (o.Apply is null)
            {
                ServiceDispatch.Feedback.Push(To.Warn, $"encountered null override.apply value at overrides[{atIndex}]");
                return false;
            }
            if (o.Apply.To is null)
            {
                ServiceDispatch.Feedback.Push(To.Warn, $"encountered null override.apply.to value at overrides[{atIndex}]");
                return false;
            }
            if (o.Apply.To.Path is null)
            {
                ServiceDispatch.Feedback.Push(To.Warn, $"encountered null override.apply.to.path value at overrides[{atIndex}]");
                return false;
            }
            if (o.Apply.To.Path == string.Empty)
            {
                ServiceDispatch.Feedback.Push(To.Warn, $"encountered empty override.apply.to.path value at overrides[{atIndex}]");
                return false;
            }

            //if all relavent values provided, check for hard stop errors
            //errors
            if (o.Apply.To.Path == "." && (string.Compare(o.Apply.Name, config.RootNamespace, true) == 0))
            {
                //setting the root namespace equal the db name causes compile circular dependency
                string msg = string.Empty;
                msg += $"encountered override.apply.name=\"{o.Apply.Name}\" for override.apply.to.path=\"{o.Apply.To.Path}\" at overrides[{atIndex}]";
                msg += ($"  The rootNamespace cannot equal the database name.");
                throw new CommandException(msg);
            }

            return true;
        }
        #endregion

        #region resolve override target
        private static IList<INamedMeta> ResolveOverrideTarget(MsSqlModel model, Override o)
        {
            IList<INamedMeta> set = new List<INamedMeta>();
            switch (o.Apply.To.ObjectType)
            {
                case ObjectType.Any:
                    MsSqlModelAccessor accessor = new(model);
                    set = accessor.ResolveItemSet(o.Apply.To.Path);
                    break;
                case ObjectType.Schema:
                    set = ResolveOverrideTarget<ISqlSchema>(model, o);
                    break;
                case ObjectType.Table:
                    set = ResolveOverrideTarget<ISqlTable>(model, o);
                    break;
                case ObjectType.View:
                    set = ResolveOverrideTarget<ISqlView>(model, o);
                    break;
                case ObjectType.Procedure:
                    set = ResolveOverrideTarget<ISqlProcedure>(model, o);
                    break;
                case ObjectType.Relationship:
                    set = ResolveOverrideTarget<ISqlRelationship>(model, o);
                    break;
                case ObjectType.Index:
                    set = ResolveOverrideTarget<ISqlIndex>(model, o);
                    break;
                case ObjectType.Column:
                    set = ResolveOverrideTarget<ISqlColumn>(model, o);
                    break;
                case ObjectType.TableColumn:
                    set = ResolveOverrideTarget<ISqlTableColumn>(model, o);
                    break;
                case ObjectType.ViewColumn:
                    set = ResolveOverrideTarget<ISqlViewColumn>(model, o);
                    break;
                case ObjectType.Parameter:
                    set = ResolveOverrideTarget<ISqlParameter>(model, o);
                    break;
                default:
                    ServiceDispatch.Feedback.Push(To.Error, $"encountered unknown ObjectType: {o.Apply.To.ObjectType}");
                    break;
            }
            return set;
        }

        public static IList<INamedMeta> ResolveOverrideTarget<T>(MsSqlModel model, Override o) where T : INamedMeta
        {
            Predicate<T> predicate = BuildMatchPredicate<T>(o);

            MsSqlModelAccessor accessor = new(model);

            IList<T> set = accessor.ResolveItemSet<T>(o.Apply.To.Path, predicate);

            return set.Cast<INamedMeta>().ToList();
        }
        #endregion

        #region validate override
        private static void ValidateOverride(Override ovrd, int atIndex, IList<INamedMeta> targetSet)
        {
            //resolve distinct target types
            var distinct = targetSet.GroupBy(t => t.GetType()).Select(t => t.FirstOrDefault()).ToList();

            if (ovrd.Apply.AllowInsert.HasValue && !distinct.All(m => (m is MsSqlTableColumn)))
            {
                ServiceDispatch.Feedback.Push(To.Warn, $"override.apply.allowinsert at overrides[{atIndex}] is invalid");
                ServiceDispatch.Feedback.Push(To.Warn, $"allowinsert is only valid on table columns");
            }
            if (ovrd.Apply.AllowUpdate.HasValue && !distinct.All(m => (m is MsSqlTableColumn)))
            {
                ServiceDispatch.Feedback.Push(To.Warn, $"override.apply.allowupdate at overrides[{atIndex}] is invalid");
                ServiceDispatch.Feedback.Push(To.Warn, $"allowupdate is only valid on table columns");
            }
            if (ovrd.Apply.ClrType != null && !distinct.All(m => (m is MsSqlColumn) || (m is MsSqlParameter)))
            {
                ServiceDispatch.Feedback.Push(To.Warn, $"override.apply.clrtype at overrides[{atIndex}] is invalid");
                ServiceDispatch.Feedback.Push(To.Warn, $"clrtype is only valid on columns and parameters");
            }
            if (ovrd.Apply.Interfaces != null && ovrd.Apply.Interfaces.Length > 0 && !distinct.All(m => (m is MsSqlTable) || (m is MsSqlView)))
            {
                ServiceDispatch.Feedback.Push(To.Warn, $"override.apply.interfaces at overrides[{atIndex}] is invalid");
                ServiceDispatch.Feedback.Push(To.Warn, $"interfaces are only valid on tables and views");
            }
            if (ovrd.Apply.Direction != null && !distinct.All(m => m is MsSqlParameter))
            {
                ServiceDispatch.Feedback.Push(To.Warn, $"override.apply.direction at overrides[{atIndex}] is invalid");
                ServiceDispatch.Feedback.Push(To.Warn, $"direction is only valid on procedure parameters");
            }
        }
		#endregion

		#region build match predicate
		private static Predicate<T> BuildMatchPredicate<T>(Override o)
        {
            List<Predicate<T>> predicateSet = new();
            Dictionary<string, object>? match = o.Apply.To.Match;
            if (match != null && match.Count > 0)
            {
                foreach (string key in match.Keys)
                {
                    Type t = typeof(T);
                    BindingFlags bFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase;
                    PropertyInfo pi = t.GetProperty(key, bFlags)!;
                    if (pi is null)
                        throw new InvalidOperationException($"Could not resolve property {key}.");
                    IConvertible matchVal = (IConvertible)match[key];

                    bool p(T obj)
                    {
                        object? target = pi.GetValue(obj);
                        string? msg = null;
                        Type pType = matchVal.GetType();
                        Type? tType = target?.GetType();
                        bool passed = false;
                        try
                        {
                            if (target is not null && tType is not null)
                            {
                                if (tType == typeof(string))
                                    passed = string.Compare(target as string, matchVal as string, true) == 0;
                                else if (tType.IsEnum)
                                    passed = target.Equals(Enum.Parse(tType, (matchVal as string)!, true));
                                else
                                    passed = target.Equals(Convert.ChangeType(matchVal, tType));
                            }
                        }
                        catch (InvalidCastException)
                        {
                            passed = false;
                            msg = $"invalid cast exception for override meta match, provided type: {pType} to target type: {tType}";
                        }
                        catch (FormatException)
                        {
                            passed = false;
                            msg = $"format exception for override meta match, provided value: {pType} to target type: {tType}";
                        }
                        catch (OverflowException)
                        {
                            passed = false;
                            msg = $"overflow exception for override meta match, provided type: {pType} to target type: {tType}";
                        }
                        catch (Exception ex)
                        {
                            passed = false;
                            msg = $"exception encountered coverting override meta match value to target:{Environment.NewLine}{ex.Message}";
                        }

                        if (msg is not null)
                        {
                            ServiceDispatch.Feedback.Push(To.Error, msg);
                        }

                        return passed;
                    }

                    predicateSet.Add(p);
                }
            }

            return predicateSet.Count > 0 
                ? (obj) => predicateSet.All(p => p(obj)) : (obj) => true;
        }
        #endregion

        #region render outputs
        protected void RenderOutputs(MsSqlModel sqlModel, DbExConfig config)
        {
            string[] names = ResourceAccessor.GetTemplateShortNames();
            TemplateModelService templateService = new(config);
            TemplateHelpers lambdaService = new(templateService);
            LanguageFeaturesModel languageFeatures = new(config.LanguageFeatures.Nullable);
            DatabasePairModel databaseModel = templateService.CreateModel(new PlatformModel(config.Source!.Platform!.Key!, config.Source!.Platform!.Version!), sqlModel, templateService, languageFeatures);

            for (int i = 0; i < names.Length; i++)
            {
                var resource = ResourceAccessor.GetTemplate(names[i]);
                RenderOutput(databaseModel, config, resource, lambdaService);
            }
        }
        #endregion

        #region render output
        protected void RenderOutput(DatabasePairModel databaseModel, DbExConfig config, Resource resource, TemplateHelpers helpers)
        {
            TemplateEngine engine = new(resource.Value);
            //engine.ProgressListener += (i, s) =>
            //{
            //    svc.Feedback.Push(To.ConsoleOnly, $"{i} \t {s}");
            //};
            engine.TrimWhitespace = true;

            LambdaRepository repo = engine.LambdaRepo;
            repo.Register(nameof(helpers.ToLower), (Func<string?, string?>)helpers.ToLower);
            repo.Register(nameof(helpers.ToCamelCase), (Func<string?, string?>)helpers.ToCamelCase);
            repo.Register(nameof(helpers.InsertSpaceOnCapitalization), (Func<string?, string?>)helpers.InsertSpaceOnCapitalization);
            repo.Register(nameof(helpers.InsertSpaceOnCapitalizationAndToLower), (Func<string?, string?>)helpers.InsertSpaceOnCapitalizationAndToLower);
            repo.Register(nameof(helpers.FirstOrDefault), (Func<IEnumerable, object?>)helpers.FirstOrDefault);
            //repo.Register(nameof(helpers.Concat), (Func<string?, string?, string?>)helpers.Concat);
            repo.Register(nameof(helpers.Join), (Func<string?, object[], string>)helpers.Join);
            //repo.Register(nameof(helpers.Replace), (Func<string?, string?, string?, string?>)helpers.Replace);
            repo.Register(nameof(helpers.GetTemplatePartial), (Func<string?, string?>)helpers.GetTemplatePartial);
            repo.Register(nameof(helpers.TrimStart), (Func<string?, string?, string?>)helpers.TrimStart);
            repo.Register(nameof(helpers.TrimEnd), (Func<string?, string?, string?>)helpers.TrimEnd);
            repo.Register(nameof(helpers.GetSchemaArgName), (Func<string, SchemaExpressionModel, string>)helpers.GetSchemaArgName);
            repo.Register(nameof(helpers.GetEntityArgName), (Func<string, EntityExpressionModel, string>)helpers.GetEntityArgName);
            repo.Register(nameof(helpers.GetFieldArgName), (Func<string, FieldExpressionModel, string>)helpers.GetFieldArgName);
            repo.Register(nameof(helpers.IsLowercase), (Func<string,bool>)helpers.IsLowercase);
            repo.Register(nameof(helpers.Iterator), (Func<Iterator>)helpers.Iterator);
            repo.Register(nameof(helpers.CS8981PragmaWarning), (Func<string, string, string?>)helpers.CS8981PragmaWarning);

            string? output = null;
            try
            {
                output = engine.Merge(databaseModel);
            }
            catch (Exception e)
            {
                ServiceDispatch.Feedback.Push(To.Error, $"Error generating template {resource.Name}: {e.Message}");
                throw;
            }

            string outputDir = config.OutputDirectory!;
            string fileName = $"{resource.Name}.generated.{resource.Extension}";
            string path = Path.Combine(outputDir, fileName);

            ServiceDispatch.IO.WriteFile(path, output, Encoding.UTF8);
            base.PushProgressFeedback($"rendering {fileName} completed");
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
