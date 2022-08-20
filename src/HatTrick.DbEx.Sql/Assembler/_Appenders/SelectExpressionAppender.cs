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

﻿using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SelectExpressionAppender : ExpressionElementAppender<SelectExpression>
    {
        #region methods
        public override void AppendElement(SelectExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.AppendElement(expression.Expression, context);

            var alias = expression as IExpressionAliasProvider;
            if (alias is not null && !string.IsNullOrWhiteSpace(alias.Alias))
            {
                AppendAlias(alias.Alias!, builder, context);
                return;
            }

            //if it is a field expression and the database column name is different than the entity property name (i.e. name override)
            //then the property name needs to be emmitted as an alias
            if (expression.Expression.AsFieldExpression() is FieldExpression field)
            {
                var columnName = builder.GetPlatformMetadata(field)?.Name ?? throw new DbExpressionException($"Cannot resolve metadata for {field}.");
                var entityPropertyName = (field as IExpressionNameProvider).Name;
                if (columnName != entityPropertyName)
                    AppendAlias(entityPropertyName, builder, context);
            }
        }

        protected virtual void AppendAlias(string alias, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write(" AS ")
                .Write(context.IdentifierDelimiter.Begin)
                .Write(alias)
                .Write(context.IdentifierDelimiter.End);
        }
        #endregion
    }
}
