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

﻿using HatTrick.DbEx.Tools.Model;
using HatTrick.DbEx.Tools.Service;
using HatTrick.Model.MsSql;
using System.Linq;

namespace HatTrick.DbEx.Tools.Builder
{
    public static class DatabaseModelBuilder
    {
        public static DatabasePairModel CreateModel(MsSqlModel database, CodeGenerationHelpers helpers)
        {
            var databasePair = new DatabasePairModel(
                     database,
                     new DatabaseExpressionModel(
                         helpers.ResolveName(database), 
                         helpers.ResolveRootNamespace()
                    )
                );

            foreach (var schema in database.Schemas.Values.Where(c => !helpers.IsIgnored(c)))
            {
                var schemaPair = new SchemaPairModel(
                        new SchemaModel(databasePair.Database, schema),
                        new SchemaExpressionModel(
                            databasePair.DatabaseExpression, 
                            schema,
                            $"{helpers.ResolveRootNamespace()}{helpers.ResolveName(schema)}",
                            helpers.ResolveName(schema)
                        )
                    );

                databasePair.Items.Add(schemaPair);

                foreach (var entity in schema.Tables.Values.Where(c => !helpers.IsIgnored(c)).Cast<INamedMeta>().Concat(schema.Views.Values))
                {
                    EntityPairModel entityPair = null;
                    if (entity is MsSqlTable table)
                    {
                        entityPair = new EntityPairModel(
                                new TableModel(schemaPair.Schema, table),
                                new EntityExpressionModel(
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
                                    entityPair.EntityExpression,
                                    column,
                                    helpers.ResolveName(column),
                                    helpers.GetClrTypeOverride(column),
                                    helpers.IsEnum(column),
                                    helpers.AllowInsert(column),
                                    helpers.AllowUpdate(column)
                                )
                            );

                            entityPair.Items.Add(columnPair);
                        }
                    }
                    else if (entity is MsSqlView view)
                    {
                        entityPair = new EntityPairModel(
                                new ViewModel(schemaPair.Schema, view),
                                new EntityExpressionModel(
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
                                    entityPair.EntityExpression,
                                    column, 
                                    helpers.ResolveName(column),
                                    helpers.GetClrTypeOverride(column),
                                    helpers.IsEnum(column),
                                    false,
                                    false
                                )
                            );

                            entityPair.Items.Add(columnPair);
                        }
                    }

                    schemaPair.Items.Add(entityPair);
                }
            }

            databasePair.Documentation = new DocumentationItemsModel(databasePair);

            return databasePair;
        }
    }
}
