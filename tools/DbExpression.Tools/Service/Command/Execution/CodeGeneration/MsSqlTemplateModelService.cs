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
using HatTrick.Model.MsSql;
using HatTrick.Model.Sql;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DbExpression.Tools.Service
{
    public class MsSqlTemplateModelService : TemplateModelService<MsSqlModel>
    {
        public MsSqlTemplateModelService(DbExConfig config) : base(config)
        {
        }

        public override string[] ResolveAppliedInterfaces(INamedMeta namedMeta)
        {
            var o = new Override();
            o.Apply.Interfaces.Add = new string[] { "IDbEntity" };
            if (!namedMeta.TryGetOverrides(out var value))
            {
                namedMeta.EnsureOverrides(o);
            }
            else
            {
                value!.Insert(0, o);
            }
            return base.ResolveAppliedInterfaces(namedMeta);
        }

        public override DatabasePairModel<MsSqlModel> CreateDatabaseModel(MsSqlModel database)
        {
            int currentIdentifier = 0;

            var features = new LanguageFeaturesModel(Config.LanguageFeatures.Nullable);
            var platform = new PlatformModel(
                        Config.Source!.Platform!.Key!.Value,
                        Config.Source!.Platform!.Version!
                    );

            var databasePair = new DatabasePairModel<MsSqlModel>(
                    currentIdentifier++,
                    platform,
                    new PackageCompatibilityModel
                    {
                        TemplateVersionIdentifier = PackageVersion.VersionIdentifier,
                        CompatibleTemplateVersionIdentifiers = PackageCompatibility.GetCompatibleTemplateVersions(Config.Source!.Platform!.Key!.Value).Select(x => $"\"{x}\"").ToArray(),
                    },
                    database,
                    new DatabaseExpressionModel(
                        features,
                        ResolveName(database),
                        ResolveRootNamespace(),
                        ResolveDatabaseAccessor()
                    ),
                    features
                );

            foreach (var schema in database.Schemas.Where(c => !IsIgnored(c)))
            {
                var schemaPair = new SchemaPairModel(
                        currentIdentifier++,
                        platform,
                        new SchemaModel(databasePair.Database, schema),
                        new SchemaExpressionModel(
                            features,
                            databasePair.DatabaseExpression,
                            schema,
                            $"{ResolveRootNamespace()}{ResolveName(schema)}",
                            ResolveName(schema)
                        )
                    );

                foreach (var entity in schema.Tables.Cast<INamedMeta>().Concat(schema.Views.Cast<INamedMeta>()))
                {
                    if (IsIgnored(entity))
                        continue;


                    EntityPairModel? entityPair = null;
                    if (entity is MsSqlTable table)
                    {
                        entityPair = new EntityPairModel(
                                currentIdentifier++,
                                platform,
                                new TableModel(schemaPair.Schema, table),
                                new EntityExpressionModel(
                                    features,
                                    schemaPair.SchemaExpression,
                                    ResolveName(table),
                                    ResolveBaseType(table),
                                    ResolveAppliedInterfaces(table)
                                )
                            );

                        foreach (var column in table.Columns.Where(c => !IsIgnored(c)))
                        {
                            var columnPair = new ColumnPairModel(
                                currentIdentifier++,
                                platform,
                                new ColumnModel(entityPair.Entity, column),
                                new FieldExpressionModel(
                                    features,
                                    entityPair.EntityExpression,
                                    column,
                                    ResolveName(column),
                                    GetClrTypeOverride(column),
                                    IsEnum(column),
                                    AllowInsert(column),
                                    AllowUpdate(column) && !column.IsComputed && !column.IsIdentity
                                )
                            );

                            entityPair.Columns.Add(columnPair);
                        }
                    }
                    else if (entity is MsSqlView view)
                    {
                        entityPair = new EntityPairModel(
                                currentIdentifier++,
                                platform,
                                new ViewModel(schemaPair.Schema, view),
                                new EntityExpressionModel(
                                    features,
                                    schemaPair.SchemaExpression,
                                    ResolveName(view),
                                    ResolveBaseType(view),
                                    ResolveAppliedInterfaces(view)
                                )
                            );

                        foreach (var column in view.Columns.Where(c => !IsIgnored(c)))
                        {
                            var columnPair = new ColumnPairModel(
                                currentIdentifier++,
                                platform,
                                new ColumnModel(entityPair.Entity, column),
                                new FieldExpressionModel(
                                    features,
                                    entityPair.EntityExpression,
                                    column,
                                    ResolveName(column),
                                    GetClrTypeOverride(column),
                                    IsEnum(column),
                                    false,
                                    false
                                )
                            );
                            entityPair.Columns.Add(columnPair);
                        }
                    }

                    if (entityPair is not null)
                    {
                        schemaPair.Entities.Add(entityPair);
                    }
                }

                foreach (var procedure in schema.Procedures.Where(p => !IsIgnored(p)))
                {
                    StoredProcedureModel procedureModel = new(schemaPair.Schema, procedure);
                    StoredProcedureExpressionModel procedureExpression = new(schemaPair.SchemaExpression, ResolveName(procedure));
                    StoredProcedurePairModel procedurePair = new(currentIdentifier++, platform, procedureModel, procedureExpression);

                    foreach (var parameter in procedure.Parameters.Where(p => !IsIgnored(p)))
                    {
                        ParameterModel parameterModel = new(procedureModel, parameter);
                        ParameterExpressionModel parameterExpression = new(
                            features,
                            procedureExpression,
                            parameter,
                            ResolveName(parameter),
                            GetClrTypeOverride(parameter),
                            IsEnum(parameter),
                            ResolveParameterDirection(parameter)
                        );
                        ParameterPairModel parameterPair = new(currentIdentifier++, platform, parameterModel, parameterExpression);
                        procedurePair.Parameters.Add(parameterPair);
                    }
                    schemaPair.StoredProcedures.Add(procedurePair);
                }

                databasePair.Schemas.Add(schemaPair);
            }


            databasePair.Documentation = new DocumentationItemsModel<MsSqlModel>(databasePair);

            return databasePair;
        }
    }
}
