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
        public static void WithDefaults<TDatabase>(this IExpressionElementAppenderFactoryContinuationConfigurationBuilder<TDatabase> builder)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            builder
                .ForElementType<SelectQueryExpression>().Use<MsSqlSelectQueryExpressionAppender>()
                .ForElementType<InsertQueryExpression>().Use<MsSqlInsertQueryExpressionAppender>()
                .ForElementType<UpdateQueryExpression>().Use<MsSqlUpdateQueryExpressionAppender>()
                .ForElementType<DeleteQueryExpression>().Use<MsSqlDeleteQueryExpressionAppender>()
                .ForElementType<StoredProcedureQueryExpression>().Use<MsSqlStoredProcedureQueryExpressionAppender>()

                //functions
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
                .ForElementType<RoundFunctionExpression>().Use<RoundFunctionExpressionAppender>()
                .ForElementType<LogFunctionExpression>().Use<LogFunctionExpressionAppender>()
                .ForElementType<SoundexFunctionExpression>().Use<SoundexFunctionExpressionAppender>();

            Sql.Configuration.SqlDatabaseRuntimeServiceBuilderExtensions.WithDefaults(builder);
        }
    }
}
