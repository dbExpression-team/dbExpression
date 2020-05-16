using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using HatTrick.Model.MsSql;
using HatTrick.Text.Templating;
using svc = HatTrick.DbEx.Tools.Service.ServiceDispatch;

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
                svc.Feedback.Push(To.Info, $"Executing code generation");
                svc.Feedback.Push(To.ConsoleOnly, "«Current working directory:  »Green");
                svc.Feedback.Push(To.ConsoleOnly, base.WorkingDirectory);

                string configPath = this.ResolveConfigPath();

                DbExConfig config = this.GetConfig(configPath);
                base.PushProgressFeedback("initialized DbEx config");

                config.OutputDirectory = this.ResolveOutputDirectory(config);

                this.EnsureOutputDirectory(config);
                base.PushProgressFeedback("ensured output directory");

                MsSqlModel sqlModel = this.BuildSqlModel(config);
                base.PushProgressFeedback("extracted full sql model");

                this.ApplySqlModelOverrides(config, sqlModel);
                base.PushProgressFeedback("applied model meta data");

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
                throw new CommandException($"Could not resolve DbExConfig.json file at path: {path}");
            }

            return path;
        }
        #endregion

        #region resolve output path
        protected string ResolveOutputDirectory(DbExConfig config)
        {
            string path = config.OutputDirectory;
            string keyUsed = null;
            if (base.TryGetOption(out path, out keyUsed, "--output", "-o"))
            {
                if (!svc.IO.DirectoryExists(path))
                {
                    //it's not a valid file or directory (absolute or relative)...
                    throw new CommandException($"Command option '{keyUsed}' does not point to a valid file or directory. Value provided: {path}");
                }
            }

            return path;
        }
        #endregion

        #region get config
        protected DbExConfig GetConfig(string path)
        {
            string json = svc.IO.GetFileText(path, Encoding.UTF8);
            DbExConfig config = JsonConvert.DeserializeObject<DbExConfig>(json);
            this.EnsureConfig(config);
            return config;
        }
        #endregion

        #region ensure config
        protected void EnsureConfig(DbExConfig config)
        {
            if (config.Source == null)
            {
                string key1 = nameof(config.Source);
                string msg = $"DbEx configuration file missing required key: {key1}";
                throw new CommandException(msg);
            }

            if (config.Source?.Type == null)
            {
                string key1 = nameof(config.Source);
                string key2 = nameof(config.Source.Type);
                string msg = $"DbEx configuration file missing required key: {key1}.{key2}";
                throw new CommandException(msg);
            }

            if (config.Source?.ReferenceKey == null)
            {
                string key1 = nameof(config.Source);
                string key2 = nameof(config.Source.ReferenceKey);
                string msg = $"DbEx configuration file missing required key: {key1}.{key2}";
                throw new CommandException(msg);
            }

            if (config.Source?.ConnectionString == null)
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

            //if (string.IsNullOrWhiteSpace(config.RuntimeConnectionStringName))
            //{
            //    string key1 = nameof(config.RuntimeConnectionStringName);
            //    string msg = $"DbExConfig file missing required key: {key1}";
            //    throw new CommandException(msg);
            //}

            if (!string.IsNullOrWhiteSpace(config.OutputDirectory))
            {
                if (svc.IO.FileExists(config.OutputDirectory))
                {
                    throw new CommandException($"There is already a file with the same name as the name you specified for 'outputDirectory' within the DbExConfig");
                }
            }
        }
        #endregion

        #region ensure output path
        protected void EnsureOutputDirectory(DbExConfig config)
        {
            string path = null;
            if (!string.IsNullOrWhiteSpace(config.OutputDirectory))
            {
                path = config.OutputDirectory;
            }
            else
            {
                path = DEFAULT_OUTPUT_PATH;
                config.OutputDirectory = path;
            }

            if (!svc.IO.DirectoryExists(path))
            {
                Directory.CreateDirectory(path);
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
        protected void ApplySqlModelOverrides(DbExConfig config, MsSqlModel sqlModel)
        {
            if (config != null && config.Meta != null)
            {
                Meta m = null;
                for (int i = 0; i < config.Meta.Length; i++)
                {
                    m = config.Meta[i];

                    if (m.Path == null)
                    {
                        svc.Feedback.Push(To.Warn, $"encountered null meta.path value at meta[{i}]");
                        continue;
                    }
                    if (m.Apply == null)
                    {
                        svc.Feedback.Push(To.Warn, $"encountered null meta.apply value at meta[{i}]");
                        continue;
                    }
                    INamedMeta nm = sqlModel.ResolveItem(m.Path);
                    if (nm == null)
                    {
                        svc.Feedback.Push(To.Warn, $"meta.path: '{(m.Path == string.Empty ? "string.Empty" : m.Path)}' at meta[{i}] could not be resolved.");
                    }
                    else
                    {
                        nm.Meta = (nm.Meta == null) ? m.Apply.AsString() : (", " + m.Apply.AsString());
                    }
                }
            }
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
            engine.ProgressListener += (i, s) =>
            {
                svc.Feedback.Push(To.ConsoleOnly, $"{i} \t {s}");
            };
            engine.TrimWhitespace = true;

            LambdaRepository repo = engine.LambdaRepo;
            repo.Register(nameof(helpers.IsIgnored), (Func<INamedMeta, bool>)helpers.IsIgnored);
            repo.Register(nameof(helpers.ToCamelCase), (Func<INamedMeta, string>)helpers.ToCamelCase);
            repo.Register(nameof(helpers.ResolveName), (Func<INamedMeta, string>)helpers.ResolveName);
            repo.Register(nameof(helpers.InsertSpaceOnCapitalization), (Func<string, string>)helpers.InsertSpaceOnCapitalization);
            repo.Register(nameof(helpers.InsertSpaceOnCapitalizationAndToLower), (Func<INamedMeta, string>)helpers.InsertSpaceOnCapitalizationAndToLower);
            repo.Register(nameof(helpers.HasDataTypeOverride), (Func<INamedMeta, bool>)helpers.HasDataTypeOverride);
            repo.Register(nameof(helpers.IsEnum), (Func<INamedMeta, bool>)helpers.IsEnum);
            repo.Register(nameof(helpers.ResolveAssemblyTypeName), (Func<MsSqlColumn, bool, string>)helpers.ResolveAssemblyTypeName);
            repo.Register(nameof(helpers.ResolveStrictAssemblyTypeName), (Func<MsSqlColumn, string>)helpers.ResolveStrictAssemblyTypeName);
            repo.Register(nameof(helpers.ResolveFieldExpressionTypeName), (Func<MsSqlColumn, bool, string>)helpers.ResolveFieldExpressionTypeName);
            repo.Register(nameof(helpers.BuildFieldExpressionInterfaceProperty), (Func<MsSqlColumn, INamedMeta, string>)helpers.BuildFieldExpressionInterfaceProperty);
            repo.Register(nameof(helpers.BuildEntityExpressionConstructorForFieldExpression), (Func<MsSqlColumn, INamedMeta, INamedMeta, string>)helpers.BuildEntityExpressionConstructorForFieldExpression);
            repo.Register(nameof(helpers.NameRepresentsLastTouchedTimestamp), (Func<string, bool>)helpers.NameRepresentsLastTouchedTimestamp);
            repo.Register(nameof(helpers.IsLast), (Func<EnumerableNamedMetaSet<MsSqlColumn>, MsSqlColumn, bool>)helpers.IsLast);
            repo.Register(nameof(helpers.ResolveConsolidatedTablesAndViews), (Func<MsSqlSchema, EnumerableNamedMetaSet<INamedMeta>>)helpers.ResolveConsolidatedTablesAndViews);
            repo.Register(nameof(helpers.IsMsSqlTable), (Func<INamedMeta, bool>)helpers.IsMsSqlTable);
            repo.Register(nameof(helpers.IsMsSqlView), (Func<INamedMeta, bool>)helpers.IsMsSqlView);
            repo.Register("ResolveSourceReferenceKey", (Func<string>)(() => { return config.Source.ReferenceKey; }));
            repo.Register("ResolveRootNamespace", (Func<string>)(() => 
            {
                return string.IsNullOrEmpty(config.RootNamespace) ? "DbEx." : $"{config.RootNamespace.TrimEnd('.')}.";
            }));

            string output = engine.Merge(sqlModel);

            string outputDir = config.OutputDirectory;
            string fileName = $"{resource.Name.Replace(".Template", string.Empty)}.cs";
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
