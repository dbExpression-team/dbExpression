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

using HatTrick.DbEx.Tools.Configuration;
using HatTrick.DbEx.Tools.Model;
using HatTrick.Model.MsSql;
using HatTrick.Reflection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HatTrick.DbEx.Tools.Service
{
    public class TemplateModelService
    {
        #region internals
        private readonly DbExConfig _config;
        private readonly Dictionary<INamedMeta, object> _meta;
        #endregion

        #region constructors
        public TemplateModelService(DbExConfig config)
        {
            _config = config;
            _meta = new Dictionary<INamedMeta, object>();
        }
        #endregion

        public DatabasePairModel CreateModel(string platform, MsSqlModel database, TemplateModelService helpers, LanguageFeatures features)
        {
            var databasePair = new DatabasePairModel(
                    platform,
                    database,
                    new DatabaseExpressionModel(
                         features,
                            helpers.ResolveName(database),
                         helpers.ResolveRootNamespace(),
                         helpers.ResolveDatabaseAccessor()
                    ),
                    features
                );

            foreach (var schema in database.Schemas.Values.Where(c => !helpers.IsIgnored(c)))
            {
                var schemaPair = new SchemaPairModel(
                        new SchemaModel(databasePair.Database, schema),
                        new SchemaExpressionModel(
                            features,
                            databasePair.DatabaseExpression,
                            schema,
                            $"{helpers.ResolveRootNamespace()}{helpers.ResolveName(schema)}",
                            helpers.ResolveName(schema)
                        )
                    );

                databasePair.Schemas.Add(schemaPair);

                foreach (var entity in schema.Tables.Values.Cast<INamedMeta>().Concat(schema.Views.Values.Cast<INamedMeta>()))
                {
                    if (helpers.IsIgnored(entity))
                        continue;

                    EntityPairModel? entityPair = null;
                    if (entity is MsSqlTable table)
                    {
                        entityPair = new EntityPairModel(
                                new TableModel(schemaPair.Schema, table),
                                new EntityExpressionModel(
                                    features,
                                    schemaPair.SchemaExpression,
                                    helpers.ResolveName(table),
                                    helpers.ResolveAppliedInterfaces(table)
                                )
                            );

                        foreach (var column in table.Columns.Values.Where(c => !helpers.IsIgnored(c)))
                        {
                            var columnPair = new ColumnPairModel(
                                new ColumnModel(entityPair.Entity, column),
                                new FieldExpressionModel(
                                    features,
                                    entityPair.EntityExpression,
                                    column,
                                    helpers.ResolveName(column),
                                    helpers.GetClrTypeOverride(column),
                                    helpers.IsEnum(column),
                                    helpers.AllowInsert(column),
                                    helpers.AllowUpdate(column) && !column.IsComputed && !column.IsIdentity
                                )
                            );

                            entityPair.Columns.Add(columnPair);
                        }
                    }
                    else if (entity is MsSqlView view)
                    {
                        entityPair = new EntityPairModel(
                                new ViewModel(schemaPair.Schema, view),
                                new EntityExpressionModel(
                                    features,
                                    schemaPair.SchemaExpression,
                                    helpers.ResolveName(view),
                                    helpers.ResolveAppliedInterfaces(view)
                                )
                            );

                        foreach (var column in view.Columns.Values.Where(c => !helpers.IsIgnored(c)))
                        {
                            var columnPair = new ColumnPairModel(
                                new ColumnModel(entityPair.Entity, column),
                                new FieldExpressionModel(
                                    features,
                                    entityPair.EntityExpression,
                                    column,
                                    helpers.ResolveName(column),
                                    helpers.GetClrTypeOverride(column),
                                    helpers.IsEnum(column),
                                    false,
                                    false
                                )
                            );

                            entityPair.Columns.Add(columnPair);
                        }
                    }

                    if (entityPair is not null)
                        schemaPair.Entities.Add(entityPair);
                }

                foreach (var procedure in schema.Procedures.Values.Where(p => !helpers.IsIgnored(p)))
                {
                    StoredProcedureModel procedureModel = new(schemaPair.Schema, procedure);
                    StoredProcedureExpressionModel procedureExpression = new(schemaPair.SchemaExpression, helpers.ResolveName(procedure));
                    StoredProcedurePairModel procedurePair = new(procedureModel, procedureExpression);

                    foreach (var parameter in procedure.Parameters.Values.Where(p => !helpers.IsIgnored(p)))
                    {
                        ParameterModel parameterModel = new(procedureModel, parameter);
                        ParameterExpressionModel parameterExpression = new(
                            features,
                            procedureExpression,
                            parameter,
                            helpers.ResolveName(parameter),
                            helpers.GetClrTypeOverride(parameter),
                            helpers.IsEnum(parameter),
                            helpers.ResolveParameterDirection(parameter)
                        );
                        ParameterPairModel parameterPair = new(parameterModel, parameterExpression);
                        procedurePair.Parameters.Add(parameterPair);
                    }
                    schemaPair.StoredProcedures.Add(procedurePair);
                }
            }

            databasePair.Documentation = new DocumentationItemsModel(databasePair);

            return databasePair;
        }
        public string ResolveRootNamespace()
        {
            return _config.RootNamespace?.TrimEnd('.') + '.';
        }

        public string ResolveDatabaseAccessor()
        {
            return _config.DatabaseAccessor.TrimEnd('.');
        }

        public string ResolveName(INamedMeta namedMeta)
        {
            return this.TryResolveMeta(namedMeta, "Name", out string? nameOverride) ? nameOverride! : namedMeta.Name;
        }

        public string[] ResolveAppliedInterfaces(INamedMeta namedMeta)
        {
            return this.TryResolveMeta(namedMeta, "Interfaces", out string[]? interfaces) ? interfaces! : Array.Empty<string>();
        }

        public ParameterDirection ResolveParameterDirection(MsSqlParameter parameter)
        {

            if (this.TryResolveMeta(parameter as INamedMeta, "Direction", out string? direction))
            {
                if (string.Compare(direction, "Input", true) == 0)
                    return ParameterDirection.Input;
                if (string.Compare(direction, "Output", true) == 0)
                    return ParameterDirection.Output;
                if (string.Compare(direction, "InputOutput", true) == 0)
                    return ParameterDirection.InputOutput;
            }

            return parameter.IsOutput ? ParameterDirection.Output : ParameterDirection.Input;
        }

		public string? GetClrTypeOverride(INamedMeta namedMeta)
        {
            return this.TryResolveMeta(namedMeta, "ClrType", out string? dataTypeOverride) ? dataTypeOverride : null;
        }

        public bool HasClrTypeOverride(INamedMeta namedMeta, out string? dataTypeOverride)
        {
            return this.TryResolveMeta(namedMeta, "ClrType", out dataTypeOverride);
        }

        public bool IsEnum(INamedMeta namedMeta)
        {
            bool isEnum = false;
            if (this.HasClrTypeOverride(namedMeta, out string? dataTypeOverride))
            {
                var trimmed = dataTypeOverride!.TrimEnd('?');
                isEnum = _config.Enums.Contains(trimmed);
            }
            return isEnum;
        }

        public bool IsIgnored(INamedMeta namedMeta)
        {
            this.TryResolveMeta(namedMeta, "Ignore", out bool isIgnored);
            return isIgnored;
        }

        public bool AllowInsert(MsSqlColumn column)
        {
            if (this.TryResolveMeta(column, "AllowInsert", out bool? allowInsert))
                return allowInsert!.Value;

            return true;
        }

        public bool AllowUpdate(MsSqlColumn column)
        {
            if (this.TryResolveMeta(column, "AllowUpdate", out bool? allowUpdate))
                return allowUpdate!.Value;

            return true;
        }

        private bool TryResolveMeta<T>(INamedMeta namedMeta, string key, out T? value)
        {
            value = default;
            if (string.IsNullOrEmpty(namedMeta.Meta))
                return false;

            _meta.TryGetValue(namedMeta, out var meta);
            if (meta is null)
            {
                meta = JsonConvert.DeserializeObject<Apply>(namedMeta.Meta);
                if (meta is null)
                    return false;
                _meta.Add(namedMeta, meta);
            }

            value = meta.ReflectItem<T>(key, false);

            return value is not null;
        }

        public IList<string> GetDeclaredEnumerationTypes()
            => _config.Enums;

        public bool NullableEnabled
            => _config.Nullable == NullableFeature.Enable;
    }
}
