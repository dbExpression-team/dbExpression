using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using HatTrick.Model.MsSql;
using HatTrick.Text.Templating;
using svc = HatTrick.DbEx.Tools.Service.ServiceDispatch;
using HatTrick.DbEx.Tools.Configuration;
using HatTrick.Reflection;
using System.Linq;
using System.Reflection;

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
        private readonly string DEFAULT_CONFIG_PATH = "./";
        private readonly string DEFAULT_CONFIG_NAME = "DbExConfig.json";
        private readonly string DEFAULT_OUTPUT_PATH = "./DbExGenerated";
        private readonly char[] INVALID_FILENAME_CHARS = Path.GetInvalidFileNameChars();
        #endregion

        #region interface
        public static string[] CommandTextValues { get; } = new string[] { "generate", "gen" };
        #endregion

        #region constructors
        public CodeGenerateExecutionContext(string command) : this(command, null)
        {
        }

        public CodeGenerateExecutionContext(string command, string options) : base(command, options)
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
                base.PushProgressFeedback("Executing code generation");

                string configPath = this.ResolveConfigPath();

                DbExConfig config = this.GetConfig(configPath);
                base.PushProgressFeedback("initialized DbEx config");

                this.EnsureConfig(config);

                this.EnsureWorkingDirectory(config, configPath);

                svc.Feedback.Push(To.ConsoleOnly, "«Current working directory:  »Green");
                svc.Feedback.Push(To.ConsoleOnly, base.WorkingDirectory);

                config.OutputDirectory = this.ResolveOutputDirectory(config);

                base.PushProgressFeedback("ensured output directory");

                base.PushProgressFeedback("starting sql model extraction");
                MsSqlModel sqlModel = this.BuildSqlModel(config);
                base.PushProgressFeedback("extracted full sql model");

                this.ApplySqlModelOverrides(config, sqlModel);
                base.PushProgressFeedback("applied model metadata");

                this.EnsureRenderSafe(config, sqlModel);

                this.RenderOutputs(sqlModel, config);
                base.PushProgressFeedback("code render completed");

            }

            base.Complete();
        }
        #endregion

        #region resolve config path
        protected string ResolveConfigPath()
        {
            string path = null;
            string keyUsed = null;
            if (base.TryGetOption(out path, out keyUsed, "--path", "-p"))
            {
                //allow for a path with a file name... or a directory and we will assume default file name...
                if (!svc.IO.FileExists(path))
                {
                    if (!svc.IO.DirectoryExists(path))
                    {
                        //it's not a valid file or directory (absolute or relative)...
                        throw new CommandException($"Command option '{keyUsed}' does not point to a valid file or directory. Value provided: {path}");
                    }
                    path = Path.Combine(path, DEFAULT_CONFIG_NAME);
                }
            }
            else
            {
                //assume default path...
                path = Path.Combine(DEFAULT_CONFIG_PATH, DEFAULT_CONFIG_NAME);
            }

            if (!svc.IO.FileExists(path))
            {
                throw new CommandException($"Could not resolve config json file at path: {path}");
            }

            return Path.GetFullPath(path);
        }
        #endregion

		#region resolve output path
		protected string ResolveOutputDirectory(DbExConfig config)
        {
            string keyUsed;
            bool optionFound = base.TryGetOption(out string optionPath, out keyUsed, "--output", "-o");
            if (optionFound)
            {
                if (!string.IsNullOrEmpty(config.OutputDirectory))
                {
                    svc.Feedback.Push(To.Warn, $"Encountered --output command option and outputDirectory config setting, command option used");
                }
                config.OutputDirectory = optionPath;
            }

            this.EnsureOutputDirectory(config);

            return config.OutputDirectory;
        }
        #endregion

        #region get config
        protected DbExConfig GetConfig(string path)
        {
            string json = svc.IO.GetFileText(path, Encoding.UTF8);
            DbExConfig config = JsonConvert.DeserializeObject<DbExConfig>(json);
            return config;
        }
        #endregion

        #region ensure config
        protected void EnsureConfig(DbExConfig config)
        {
            if (config.Source is null)
            {
                string key1 = nameof(config.Source);
                string msg = $"DbEx configuration file missing required key: {key1}";
                throw new CommandException(msg);
            }

            if (config.Source?.Type is null)
            {
                string key1 = nameof(config.Source);
                string key2 = nameof(config.Source.Type);
                string msg = $"DbEx configuration file missing required key: {key1}.{key2}";
                throw new CommandException(msg);
            }

            if (config.Source?.ConnectionString is null)
            {
                string key1 = nameof(config.Source);
                string key2 = nameof(config.Source.ConnectionString);
                string msg = $"DbEx configuration file missing required key: {key1}.{key2}";
                throw new CommandException(msg);
            }

            if (string.IsNullOrWhiteSpace(config.Source?.ConnectionString?.Value))
            {
                string key1 = nameof(config.Source);
                string key2 = nameof(config.Source.ConnectionString);
                string key3 = nameof(config.Source.ConnectionString.Value);
                string msg = $"DbEx configuration file missing required key: {key1}.{key2}.{key3}";
                throw new CommandException(msg);
            }

            if (string.IsNullOrWhiteSpace(config.RootNamespace))
            {
                string key1 = nameof(config.RootNamespace);
                string msg = $"DbEx configuration file missing required key: {key1}";
                throw new CommandException(msg);
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
                base.WorkingDirectory = Path.GetDirectoryName(fullConfigPath);

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
            if (svc.IO.FileExists(config.WorkingDirectory))
            {
                throw new CommandException($"A file exists at the same path you specified for the configured 'workingDirectory'");
            }

            if (!svc.IO.DirectoryExists(working))
            {
                svc.Feedback.Push(To.Warn, "No directory exists at configured 'workingDirectory'");
                svc.Feedback.Push(To.Warn, $"Attempting to create working directory: {working}");
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
                    config.OutputDirectory = Path.GetFullPath(config.OutputDirectory);
                }
            }

            if (svc.IO.FileExists(config.OutputDirectory))
            {
                throw new CommandException($"A file exists with the same name specified for configured 'outputDirectory'");
            }

            if (!svc.IO.DirectoryExists(config.OutputDirectory))
            {
                string msg = isProvided
                    ? "No directory exists at provided 'outputDirectory'"
                    : "No directory exists at default 'outputDirectory'";

                svc.Feedback.Push(To.Warn, msg);
                svc.Feedback.Push(To.Warn, $"Attempting to create output directory: {config.OutputDirectory}");
                Directory.CreateDirectory(config.OutputDirectory);
            }
        }
        #endregion

        #region build sql model
        protected MsSqlModel BuildSqlModel(DbExConfig config)
        {
            MsSqlModelBuilder sqlMdlBlder = new MsSqlModelBuilder(config.Source.ConnectionString.Value);
            bool failed = false;
            sqlMdlBlder.OnError += (ex) =>
            {
                failed = true;
                svc.Feedback.PushException(new ExceptionFeedback(ex));
            };

            MsSqlModel sqlModel = sqlMdlBlder.Build();

            if (failed)
            {
                svc.Feedback.Push(To.ConsoleOnly, string.Empty);
                throw new CommandException("Exception encountered building sql model");
            }

            return sqlModel;
        }
        #endregion

        #region apply sql model overrides
        protected void ApplySqlModelOverrides(DbExConfig config, MsSqlModel model)
        {
            if (config is object && config.Overrides is object)
            {
                Override o = null;
                for (int i = 0; i < config.Overrides.Length; i++)
                {
                    o = config.Overrides[i];

                    if (!this.EnsureOverride(o, i, config))
                        continue;

                    IList<INamedMeta> set = this.ResolveOverrideTarget(model, o);
                    if (set is null || set.Count == 0)
                    {
                        svc.Feedback.Push(To.Warn, $"override.apply.to.path: '{o.Apply.To.Path}' at meta[{i}] resolved 0 items");
                        continue;
                    }

                    foreach (var item in set)
                    {
                        item.Meta = o.Apply.ToJson();
                    }
                }
            }
        }
		#endregion

		#region ensure override
        private bool EnsureOverride(Override o, int atIndex, DbExConfig config)
        {
            //warnings...
            bool isValid = true;
            if (o is null)
            {
                svc.Feedback.Push(To.Warn, $"encountered null override value at overrides[{atIndex}]");
                isValid = false;
            }
            else if (o.Apply is null)
            {
                svc.Feedback.Push(To.Warn, $"encountered null override.apply value at overrides[{atIndex}]");
                isValid = false;
            }
            else if (o.Apply.To is null)
            {
                svc.Feedback.Push(To.Warn, $"encountered null override.apply.to value at overrides[{atIndex}]");
                isValid = false;
            }
            else if (o.Apply.To.Path is null)
            {
                svc.Feedback.Push(To.Warn, $"encountered null override.apply.to.path value at overrides[{atIndex}]");
                isValid = false;
            }
            else if (o.Apply.To.Path == string.Empty)
            {
                svc.Feedback.Push(To.Warn, $"encountered empty override.apply.to.path value at overrides[{atIndex}]");
                isValid = false;
            }

            if (isValid)//if all relavent values provided, check for hard stop errors
            {
                //errors
                if (o.Apply.To.Path == "." && (string.Compare(o.Apply.Name, config.RootNamespace, true) == 0))
                {
                    //setting the root namespace equal the db name causes compile circular dependency
                    StringBuilder msg = new StringBuilder();
                    msg.AppendLine($"DbExConfig error: rootNamespace=\"{config.RootNamespace}\" - rootNamespace cannot equal database name override");
                    msg.AppendLine($"encountered override.apply.name=\"{o.Apply.Name}\" for override.apply.to.path=\"{o.Apply.To.Path}\" at overrides[{atIndex}]");
                    throw new CommandException(msg.ToString());
                }
            }

            return isValid;
        }
        #endregion

        #region ensure render safe
        private void EnsureRenderSafe(DbExConfig config, MsSqlModel model)
        {
            if (!config.Overrides.Any(ov => ov.Apply.To.Path == "."))//if override to path . exists, we caught this issue in ApplyOverrides
            {
                if (string.Compare(config.RootNamespace, model.Name, true) == 0)
                {
                    //setting the root namespace equal the db name causes compile circular dependency
                    StringBuilder msg = new StringBuilder();
                    msg.AppendLine($"DbExConfig error: rootNamespace=\"{config.RootNamespace}\" - rootNamespace cannot equal database name: {model.Name}");
                    throw new CommandException(msg.ToString());
                }
            }
        }
		#endregion

		#region resolve override target
		private IList<INamedMeta> ResolveOverrideTarget(MsSqlModel model, Override o)
        {
            IList<INamedMeta> set = null;
            switch (o.Apply.To.ObjectType)
            {
                case ObjectType.Any:
                    SqlModelAccessor accecssor = new SqlModelAccessor(model);
                    set = accecssor.ResolveItemSet(o.Apply.To.Path);
                    break;
                case ObjectType.Schema:
                    set = this.ResolveOverrideTarget<MsSqlSchema>(model, o);
                    break;
                case ObjectType.Table:
                    set = this.ResolveOverrideTarget<MsSqlTable>(model, o);
                    break;
                case ObjectType.View:
                    set = this.ResolveOverrideTarget<MsSqlView>(model, o);
                    break;
                case ObjectType.Procedure:
                    set = this.ResolveOverrideTarget<MsSqlProcedure>(model, o);
                    break;
                case ObjectType.Relationship:
                    set = this.ResolveOverrideTarget<MsSqlRelationship>(model, o);
                    break;
                case ObjectType.Index:
                    set = this.ResolveOverrideTarget<MsSqlIndex>(model, o);
                    break;
                case ObjectType.Column:
                    set = this.ResolveOverrideTarget<MsSqlColumn>(model, o);
                    break;
                case ObjectType.TableColumn:
                    set = this.ResolveOverrideTarget<MsSqlTableColumn>(model, o);
                    break;
                case ObjectType.ViewColumn:
                    set = this.ResolveOverrideTarget<MsSqlViewColumn>(model, o);
                    set.ToList<INamedMeta>();
                    break;
                case ObjectType.Parameter:
                    set = this.ResolveOverrideTarget<MsSqlParameter>(model, o);
                    break;
                default:
                    svc.Feedback.Push(To.Error, $"encountered unknown ObjectType: {o.Apply.To.ObjectType}");
                    break;
            }
            return set;
        }

        public IList<INamedMeta> ResolveOverrideTarget<T>(MsSqlModel model, Override o) where T : INamedMeta
        {
            Predicate<T> predicate = this.BuildMatchPredicate<T>(model, o);
         
            SqlModelAccessor accessor = new SqlModelAccessor(model);

            IList<T> set = accessor.ResolveItemSet<T>(o.Apply.To.Path, predicate);

            return set.Cast<INamedMeta>().ToList();
        }
        #endregion

        #region build match predicate
        private Predicate<T> BuildMatchPredicate<T>(MsSqlModel model, Override o)
        {
            Predicate<T> predicate = null;

            Dictionary<string, object> match = o.Apply.To.Match;
            if (match != null && match.Count > 0)
            {
                List<Predicate<T>> predicateSet = new List<Predicate<T>>();
                foreach (string key in match.Keys)
                {
                    Type t = typeof(T);
                    BindingFlags bFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase;
                    PropertyInfo pi = t.GetProperty(key, bFlags);
                    IConvertible matchVal = (IConvertible)match[key];

                    Predicate<T> p = (obj) =>
                    {
                        var target = pi.GetValue(obj);
                        string msg = null;  
                        Type pType = matchVal.GetType();
                        Type tType = target.GetType();
                        bool passed = false;
                        try
                        {
                            if (target is object)
                            {
                                if (tType == typeof(string))
                                    passed = string.Compare(target as string, matchVal as string, true) == 0;
                                else if (tType.IsEnum)
                                    passed = target.Equals(Enum.Parse(tType, matchVal as string, true));
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

                        if (msg is object)
                        {
                            svc.Feedback.Push(To.Error, msg);
                        }

                        return passed;
                    };

                    predicateSet.Add(p);
                }

                if (predicateSet.Count > 0)
                {
                    predicate = (obj) => predicateSet.All(p => p(obj));
                }
            }

            return predicate;
        }
		#endregion

		#region render outputs
		protected void RenderOutputs(MsSqlModel sqlModel, DbExConfig config)
        {
            var resources = new ResourceAccessor();
            string[] names = resources.GetTemplateShortNames();

            var helpers = new CodeGenerationHelpers();

            for (int i = 0; i < names.Length; i++)
            {
                var resource = resources.GetTemplate(names[i]);
                this.RenderOutput(sqlModel, config, resource, helpers);
            }
        }
        #endregion

        #region render output
        protected void RenderOutput(MsSqlModel sqlModel, DbExConfig config, Resource resource, CodeGenerationHelpers helpers)
        {
            TemplateEngine engine = new TemplateEngine(resource.Value);
            //engine.ProgressListener += (i, s) =>
            //{
            //    svc.Feedback.Push(To.ConsoleOnly, $"{i} \t {s}");
            //};
            engine.TrimWhitespace = true;

            LambdaRepository repo = engine.LambdaRepo;
            repo.Register(nameof(helpers.IsIgnored), (Func<INamedMeta, bool>)helpers.IsIgnored);
            repo.Register(nameof(helpers.ToCamelCase), (Func<INamedMeta, string>)helpers.ToCamelCase);
            repo.Register(nameof(helpers.ResolveName), (Func<INamedMeta, string>)helpers.ResolveName);
            repo.Register(nameof(helpers.ResolveStrictName), (Func<INamedMeta, string>)helpers.ResolveStrictName);
            repo.Register(nameof(helpers.InsertSpaceOnCapitalization), (Func<string, string>)helpers.InsertSpaceOnCapitalization);
            repo.Register(nameof(helpers.InsertSpaceOnCapitalizationAndToLower), (Func<INamedMeta, string>)helpers.InsertSpaceOnCapitalizationAndToLower);
            repo.Register(nameof(helpers.HasClrTypeOverride), (Func<INamedMeta, bool>)helpers.HasClrTypeOverride);
            repo.Register(nameof(helpers.IsEnum), (Func<INamedMeta, bool>)helpers.IsEnum);
            repo.Register(nameof(helpers.ResolveClrTypeName), (Func<MsSqlColumn, bool, string>)helpers.ResolveClrTypeName);
            repo.Register(nameof(helpers.ResolveStrictAssemblyTypeName), (Func<MsSqlColumn, string>)helpers.ResolveStrictAssemblyTypeName);
            repo.Register(nameof(helpers.ResolveFieldExpressionTypeName), (Func<MsSqlColumn, bool, string>)helpers.ResolveFieldExpressionTypeName);
            repo.Register(nameof(helpers.NameRepresentsLastTouchedTimestamp), (Func<string, bool>)helpers.NameRepresentsLastTouchedTimestamp);
            repo.Register(nameof(helpers.IsLast), (Func<IEnumerable<MsSqlColumn>, MsSqlColumn, bool>)helpers.IsLast);
            repo.Register(nameof(helpers.ResolveConsolidatedTablesAndViews), (Func<MsSqlSchema, IList<INamedMeta>>)helpers.ResolveConsolidatedTablesAndViews);
            repo.Register(nameof(helpers.IsMsSqlTable), (Func<INamedMeta, bool>)helpers.IsMsSqlTable);
            repo.Register(nameof(helpers.IsMsSqlView), (Func<INamedMeta, bool>)helpers.IsMsSqlView);
            repo.Register(nameof(helpers.GetTemplatePartial), (Func<string, string>)helpers.GetTemplatePartial);
            repo.Register("ResolveRootNamespace", (Func<string>)(() => $"{config.RootNamespace.TrimEnd('.')}."));

            string output = null;
            try
            {
                output = engine.Merge(sqlModel);
            }
            catch (Exception e)
            {
                svc.Feedback.Push(To.Error, $"Error generating template {resource.Name}: {e.Message}");
                throw;
            }

            string outputDir = config.OutputDirectory;
            string fileName = $"{resource.Name}.generated.cs";
            string path = Path.Combine(outputDir, fileName);

            svc.IO.WriteFile(path, output, Encoding.UTF8);
            base.PushProgressFeedback($"rendering {fileName} completed");
        }
        #endregion

        #region push help feedback
        private void PushHelpFeedback()
        {
            svc.Feedback.Push(To.ConsoleOnly, "«Usage:  »Green");
            svc.Feedback.Push(To.ConsoleOnly, "dbex generate [options]");
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            svc.Feedback.Push(To.ConsoleOnly, "Options:»Green");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}-p|--path <path to DbExConfig.json>");
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            svc.Feedback.Push(To.ConsoleOnly, "Notes:»Green");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}Path is assumed to be current working directory if the option is not provided.");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}Path option value can be absolute or relative.");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}default config file name is DbExConfig.json and is assumed if path option points to a directory");
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            svc.Feedback.Push(To.ConsoleOnly, "Usage example(s):»Green");
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            svc.Feedback.Push(To.ConsoleOnly, $"Usage assuming DbExConfig.json is in the current working directory:»Green");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}dbex generate -p ./");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}{base.Tab}{base.Tab}Or");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}dbex generate");
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            svc.Feedback.Push(To.ConsoleOnly, $"Usage assuming the DbExConfig.json is in the config folder one direcory below current working directory:»Green");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}dbex generate -p ./config");
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            svc.Feedback.Push(To.ConsoleOnly, $"Usage assuming the DbExConfig.json is in the config folder one directory above current working directory:»Green");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}dbex generate -p ../config");
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            svc.Feedback.Push(To.ConsoleOnly, $"Usage assuming the DbExConfig.json resides at an absolute path:»Green");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}dbex generate -p c:/cofigs/app1/DbExConfig.json");
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            svc.Feedback.Push(To.ConsoleOnly, $"Usage assuming the DbExConfig.json resides at a path that includes spaces:»Green");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}dbex generate -p \"c:/my cofigs/app1/DbExConfig.json\"");
        }
        #endregion
    }
}
