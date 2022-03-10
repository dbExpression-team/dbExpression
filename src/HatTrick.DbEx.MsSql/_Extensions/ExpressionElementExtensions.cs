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

﻿using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql
{
    internal static class ExpressionElementExtensions
    {
        internal static FieldExpression? ToFieldExpression(this IExpressionElement expression)
        {
            if (expression is FieldExpression field)
                return field;

            if (expression is SelectExpression select)
                return ToFieldExpression(select.Expression);

            if (expression is ExpressionMediator mediator)
                return ToFieldExpression(mediator.Expression);

            return null;
        }

        internal static SelectExpression ToSelectExpression(this AnyElement expression, ISqlDatabaseMetadataProvider metadata)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (expression is SelectExpression select)
                return select;

            var field = expression.ToFieldExpression();

            if (field is null)
                return new SelectExpression(expression);

            if (metadata is null)
                throw new ArgumentNullException(nameof(metadata));

            //ensure the actual column name in the database is used in the sql statement.  if the column name was "overriden" in configuration, supply that name as an alias
            var dbName = metadata.FindFieldMetadata((field as ISqlMetadataIdentifierProvider).Identifier)?.Name ?? throw new DbExpressionException($"Cannot resolve metadata for {expression}.");
            var sourceName = (field as IExpressionNameProvider).Name;

            return dbName == sourceName ? new SelectExpression(expression) : new SelectExpression(expression, sourceName);
        }
    }
}
