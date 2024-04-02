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

using DbExpression.Sql.Expression;
using System;

namespace DbExpression.Sql.Assembler
{
    public interface ISqlStatementBuilder
    {
        #region interface
        ISqlParameterBuilder Parameters { get; }
        IAppender Appender { get; }
        #endregion

        #region methods
        SqlStatement CreateSqlStatement<TQuery>(TQuery expression)
           where TQuery : QueryExpression;
        void AppendElement<T>(T element, AssemblyContext context)
            where T : class, IExpressionElement;
        string GenerateAlias();
        string? ResolveTableAlias(IExpressionElement element);
        string? ResolveTableAlias(string tableName);
        string GetPlatformName(ISqlMetadataIdentifierProvider identifier);
        ISqlColumnMetadata GetPlatformMetadata(Field field);
        ISqlParameterMetadata GetPlatformMetadata(QueryParameter parameter);
        (Type ConvertedType, object? ConvertedValue) ConvertValue(object? value, Field? field);
        #endregion
    }
}
