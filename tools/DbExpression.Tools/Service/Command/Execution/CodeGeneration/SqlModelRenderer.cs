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
using DbExpression.Tools.Model;
using DbExpression.Tools.Resources;
using HatTrick.Model.MsSql;
using HatTrick.Model.Sql;
using HatTrick.Text.Templating;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using ResourceAccessor = DbExpression.Tools.Resources.ResourceAccessor;

namespace DbExpression.Tools.Service
{
    public abstract class SqlModelRenderer
    {
        #region internals
        protected DbExpressionConfig Config { get; init; }
        #endregion

        #region constructors
        protected SqlModelRenderer(DbExpressionConfig config)
        {
            Config = config ?? throw new ArgumentNullException(nameof(config));
        }
        #endregion

        #region methods
        protected virtual void ValidateOverride(Override ovrd, int atIndex, IList<INamedMeta> targetSet)
        {
            //resolve distinct target types
            var distinct = targetSet.GroupBy(t => t.GetType()).Select(t => t.FirstOrDefault()).ToList();

            if (ovrd.Apply.AllowInsert.HasValue && !distinct.All(m => (m is ISqlTableColumn)))
            {
                ServiceDispatch.Feedback.Push(To.Warn, $"override.apply.allowinsert at overrides[{atIndex}] is invalid");
                ServiceDispatch.Feedback.Push(To.Warn, $"allowinsert is only valid on table columns");
            }
            if (ovrd.Apply.AllowUpdate.HasValue && !distinct.All(m => (m is ISqlTableColumn)))
            {
                ServiceDispatch.Feedback.Push(To.Warn, $"override.apply.allowupdate at overrides[{atIndex}] is invalid");
                ServiceDispatch.Feedback.Push(To.Warn, $"allowupdate is only valid on table columns");
            }
            if (ovrd.Apply.ClrType != null && !distinct.All(m => (m is ISqlColumn) || (m is ISqlParameter)))
            {
                ServiceDispatch.Feedback.Push(To.Warn, $"override.apply.clrtype at overrides[{atIndex}] is invalid");
                ServiceDispatch.Feedback.Push(To.Warn, $"clrtype is only valid on columns and parameters");
            }
            if (ovrd.Apply.Interfaces != null && ovrd.Apply.Interfaces.Any() && !distinct.All(m => (m is ISqlTable) || (m is ISqlView)))
            {
                ServiceDispatch.Feedback.Push(To.Warn, $"override.apply.interfaces at overrides[{atIndex}] is invalid");
                ServiceDispatch.Feedback.Push(To.Warn, $"interfaces are only valid on tables and views");
            }
            if (ovrd.Apply.Direction != null && !distinct.All(m => m is ISqlParameter))
            {
                ServiceDispatch.Feedback.Push(To.Warn, $"override.apply.direction at overrides[{atIndex}] is invalid");
                ServiceDispatch.Feedback.Push(To.Warn, $"direction is only valid on procedure parameters");
            }
        }

        protected virtual void RenderOutput<T>(DatabasePairModel<T> databaseModel, Resource resource, TemplateService templateService)
            where T : class, ISqlModel
        {
            TemplateEngine engine = new(resource.Value);
            engine.TrimWhitespace = true;

            LambdaRepository repo = engine.LambdaRepo;
            repo.Register(nameof(templateService.ToLower), (Func<string?, string?>)templateService.ToLower);
            repo.Register(nameof(templateService.ToCamelCase), (Func<string?, string?>)templateService.ToCamelCase);
            repo.Register(nameof(templateService.InsertSpaceOnCapitalization), (Func<string?, string?>)templateService.InsertSpaceOnCapitalization);
            repo.Register(nameof(templateService.InsertSpaceOnCapitalizationAndToLower), (Func<string?, string?>)templateService.InsertSpaceOnCapitalizationAndToLower);
            repo.Register(nameof(templateService.FirstOrDefault), (Func<IEnumerable, object?>)templateService.FirstOrDefault);
            //repo.Register(nameof(helpers.Concat), (Func<string?, string?, string?>)helpers.Concat);
            repo.Register(nameof(templateService.Join), (Func<string?, object[], string>)templateService.Join);
            //repo.Register(nameof(helpers.Replace), (Func<string?, string?, string?, string?>)helpers.Replace);
            repo.Register(nameof(templateService.GetTemplatePartial), (Func<string?, string?>)templateService.GetTemplatePartial);
            repo.Register(nameof(templateService.TrimStart), (Func<string?, string?, string?>)templateService.TrimStart);
            repo.Register(nameof(templateService.TrimEnd), (Func<string?, string?, string?>)templateService.TrimEnd);
            repo.Register(nameof(templateService.EndsWith), (Func<string, string, bool>)templateService.EndsWith);
            repo.Register(nameof(templateService.GetSchemaArgName), (Func<string, SchemaExpressionModel, string>)templateService.GetSchemaArgName);
            repo.Register(nameof(templateService.GetEntityArgName), (Func<string, EntityExpressionModel, string>)templateService.GetEntityArgName);
            repo.Register(nameof(templateService.GetFieldArgName), (Func<string, FieldExpressionModel, string>)templateService.GetFieldArgName);
            repo.Register(nameof(templateService.IsLowercase), (Func<string, bool>)templateService.IsLowercase);
            repo.Register(nameof(templateService.Iterator), (Func<Iterator>)templateService.Iterator);
            repo.Register(nameof(templateService.CS8981PragmaWarning), (Func<string, string, string?>)templateService.CS8981PragmaWarning);

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

            string outputDir = Config.OutputDirectory!;
            string fileName = $"{resource.Name}.generated.{resource.Extension}";
            string path = Path.Combine(outputDir, fileName);

            ServiceDispatch.IO.WriteFile(path, output, Encoding.UTF8);
            ServiceDispatch.Feedback.Push(To.Info, $"rendering {fileName} completed");
        }

        public static ISqlModelRenderer CreateRenderer(DbExpressionConfig config, SupportedPlatform platform, Action<string> pushProgressFeedback)
        {
            return platform switch
            {
                SupportedPlatform.MsSql => new MsSqlModelRenderer(config),
                _ => throw new NotSupportedException($"Platform type {config.Source!.Platform!.Key} is not supported.")
            };
        }
        #endregion
    }
}