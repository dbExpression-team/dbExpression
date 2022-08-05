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

using HatTrick.DbEx.MsSql.Assembler;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Configuration
{
    public static partial class SqlDatabaseRuntimeServiceBuilderExtensions
    {
        public static void WithDefaults<TDatabase>(this ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase> builder)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            builder
                .ForQueryType<StoredProcedureQueryExpression>().Use<MsSqlStoredProcedureSqlStatementAssembler<TDatabase>>()
                .ForSelect().Use<MsSqlSelectSqlStatementAssembler<TDatabase>>()
                .ForInsert().Use<MsSqlInsertSqlStatementAssembler<TDatabase>>()
                .ForUpdate().Use<MsSqlUpdateSqlStatementAssembler<TDatabase>>()
                .ForDelete().Use<MsSqlDeleteSqlStatementAssembler<TDatabase>>();

            Sql.Configuration.SqlDatabaseRuntimeServiceBuilderExtensions.WithDefaults(builder);
        }

        public static void WithDefaults<TDatabase>(IExpressionElementAppenderFactoryContinuationConfigurationBuilder<TDatabase> builder)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            builder
                .ForElementType<DateAddFunctionExpression>().Use<DateAddFunctionExpressionAppender>()
                .ForElementType<DateDiffFunctionExpression>().Use<DateDiffFunctionExpressionAppender>()
                .ForElementType<DatePartFunctionExpression>().Use<DatePartFunctionExpressionAppender>()
                .ForElementType<GetDateFunctionExpression>().Use<GetDateFunctionExpressionAppender>()
                .ForElementType<GetUtcDateFunctionExpression>().Use<GetUtcDateFunctionExpressionAppender>()
                .ForElementType<NewIdFunctionExpression>().Use<NewIdFunctionExpressionAppender>()
                .ForElementType<SysDateTimeFunctionExpression>().Use<SysDateTimeFunctionExpressionAppender>()
                .ForElementType<SysDateTimeOffsetFunctionExpression>().Use<SysDateTimeOffsetFunctionExpressionAppender>()
                .ForElementType<SysUtcDateTimeFunctionExpression>().Use<SysUtcDateTimeFunctionExpressionAppender>()
                .ForElementType<LengthFunctionExpression>().Use<LengthFunctionExpressionAppender>()
                .ForElementType<PatIndexFunctionExpression>().Use<PatIndexFunctionExpressionAppender>()
                .ForElementType<CharIndexFunctionExpression>().Use<CharIndexFunctionExpressionAppender>()
                .ForElementType<RoundFunctionExpression>().Use<RoundFunctionExpressionAppender>();

            Sql.Configuration.SqlDatabaseRuntimeServiceBuilderExtensions.WithDefaults(builder);
        }
    }
}
