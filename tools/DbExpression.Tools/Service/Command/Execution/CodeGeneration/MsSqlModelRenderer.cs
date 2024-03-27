#region license
// Copyright (c) dbExpression.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion

using DbExpression.Tools.Configuration;
using DbExpression.Tools.Resources;
using DbExpression.Tools.Model;
using HatTrick.Model.MsSql;
using HatTrick.Model.Sql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbExpression.Tools.Service
{
    public class MsSqlModelRenderer : SqlModelRenderer, ISqlModelRenderer
    {
        #region internals
        private readonly HashSet<string> mssqlVersions = new() { "2005", "2008", "2012", "2014", "2016", "2017", "2019", "2022" };
        #endregion

        #region constructors
        public MsSqlModelRenderer(DbExConfig config) : base(config)
        {
        }
        #endregion

        #region render
        public void Render()
        {
            ServiceDispatch.Feedback.Push(To.Info, "starting mssql model extraction");
            var mssqlModel = BuildMsSqlModel();
            ServiceDispatch.Feedback.Push(To.Info, "extracted full mssql model");

            ApplySqlModelOverrides(mssqlModel);
            ServiceDispatch.Feedback.Push(To.Info, "applied model metadata");

            EnsureRenderSafe(mssqlModel);

            RenderOutputs(mssqlModel);
            ServiceDispatch.Feedback.Push(To.Info, "code render completed");
        }
        #endregion

        #region build sql model
        protected MsSqlModel BuildMsSqlModel()
        {
            MsSqlModelBuilder builder = new(Config.Source?.ConnectionString!.Value!);
            bool failed = false;
            builder.OnError += (ex) =>
            {
                failed = true;
                ServiceDispatch.Feedback.PushException(new ExceptionFeedback(ex));
            };

            MsSqlModel sqlModel = builder.Build();

            if (failed)
            {
                ServiceDispatch.Feedback.Push(To.ConsoleOnly, string.Empty);
                throw new CommandException("Exception encountered building sql model");
            }

            return sqlModel;
        }
        #endregion

        #region apply sql model overrides
        protected void ApplySqlModelOverrides(MsSqlModel model)
        {
            if (Config is null || Config.Overrides is null)
                return;

            Override? o;
            for (int i = 0; i < Config.Overrides.Length; i++)
            {
                o = Config.Overrides[i];

                if (o.Apply?.To?.Path is null || String.IsNullOrWhiteSpace(o.Apply.To.Path))
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
                    item.EnsureOverrides();
                    item.GetOverrides().Add(o);
                }
            }
        }
        #endregion

        #region ensure render safe
        private void EnsureRenderSafe(MsSqlModel model)
        {
            if (Config?.Source?.Platform?.Key != SupportedPlatform.MsSql)
                throw new CommandException("dbex.config error: source.platform.key: dbExpression only supports a value of MsSql.");

            if (!mssqlVersions.Contains(Config?.Source?.Platform?.Version!))
                throw new CommandException($"dbex.config error: source.platform.version: dbExpression only supports MsSql versions {String.Join(',', mssqlVersions)}.");

            if (Config?.Overrides is null)
                return;

            if (!Config.Overrides.Any(ov => ov.Apply.To.Path == "."))
                return; //if override to path . exists, we caught this issue in ApplyOverrides

            if (string.Compare(Config.RootNamespace, model.Name, true) == 0)
            {
                //setting the root namespace equal the db name causes compile circular dependency
                throw new CommandException($"dbex.config error: rootNamespace: {Config.RootNamespace} - rootNamespace cannot equal database name: {model.Name}");
            }
        }
        #endregion

        #region resolve override target
        private IList<INamedMeta> ResolveOverrideTarget(MsSqlModel model, Override o)
        {
            return o.Apply.To.ObjectType switch
            {
                ObjectType.Any => new MsSqlModelAccessor(model).ResolveItemSet(o.Apply.To.Path),
                ObjectType.Schema => ResolveOverrideTarget<MsSqlSchema>(model, o),
                ObjectType.Table => ResolveOverrideTarget<MsSqlTable>(model, o),
                ObjectType.View => ResolveOverrideTarget<MsSqlView>(model, o),
                ObjectType.Procedure => ResolveOverrideTarget<MsSqlProcedure>(model, o),
                ObjectType.Relationship => ResolveOverrideTarget<MsSqlRelationship>(model, o),
                ObjectType.Index => ResolveOverrideTarget<MsSqlIndex>(model, o),
                ObjectType.Column => ResolveOverrideTarget<MsSqlColumn>(model, o),
                ObjectType.TableColumn => ResolveOverrideTarget<MsSqlTableColumn>(model, o),
                ObjectType.ViewColumn => ResolveOverrideTarget<MsSqlViewColumn>(model, o),
                ObjectType.Parameter => ResolveOverrideTarget<MsSqlParameter>(model, o),
                ObjectType unknown => throw new NotImplementedException($"Object type {unknown} has not been implemented.")
            };
        }

        public IList<INamedMeta> ResolveOverrideTarget<T>(MsSqlModel model, Override o) where T : INamedMeta
        {
            MsSqlModelAccessor accessor = new(model);

            IList<T> set = accessor.ResolveItemSet<T>(o.Apply.To.Path, _ => true);

            return set.Cast<INamedMeta>().ToList();
        }
        #endregion

        #region render outputs 
        protected void RenderOutputs(MsSqlModel sqlModel)
        {
            ITemplateModelService<MsSqlModel> modelService = TemplateModelService.CreateService(Config) as ITemplateModelService<MsSqlModel>
                ?? throw new InvalidOperationException($"Internal operations requested a service for a model type of {typeof(MsSqlModel)}, but a different type was provided.");

            DatabasePairModel<MsSqlModel> databaseModel = modelService.CreateDatabaseModel(sqlModel);
            
            Version version = typeof(CodeGenerateExecutionContext).Assembly.GetName().Version!;

            TemplateService templateService = new(modelService);

            string[] names = ResourceAccessor.GetTemplateShortNames();
            for (int i = 0; i < names.Length; i++)
            {
                try
                {
                    var resource = ResourceAccessor.GetTemplate(names[i]);
                    RenderOutput(databaseModel, resource, templateService);
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException($"Failed to render output for template {names[i]}: {e.Message}", e);
                }
            }
        }
        #endregion
    }
}