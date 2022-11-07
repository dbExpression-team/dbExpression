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

using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public static class SqlDatabaseRuntimeServiceBuilderExtensions
    {
        public static void WithDefaults<TDatabase>(this IQueryExpressionContinuationConfigurationBuilder<TDatabase> builder)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            builder
                .ForQueryType<StoredProcedureQueryExpression>().Use<StoredProcedureQueryExpression>()
                .ForSelect().Use<SelectQueryExpression>()
                .ForInsert().Use<InsertQueryExpression>()
                .ForUpdate().Use<UpdateQueryExpression>()
                .ForDelete().Use<DeleteQueryExpression>();
        }

        public static void WithDefaults<TDatabase>(this IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase> builder)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            builder
                .ForPipelineType<IStoredProcedureExpressionExecutionPipeline>().Use<StoredProcedureQueryExpressionExecutionPipeline>()
                .ForSelect().Use<SelectQueryExpressionExecutionPipeline>()
                .ForInsert().Use<InsertQueryExpressionExecutionPipeline>()
                .ForUpdate().Use<UpdateQueryExpressionExecutionPipeline>()
                .ForDelete().Use<DeleteQueryExpressionExecutionPipeline>();
        }

        public static void WithDefaults<TDatabase>(this IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> builder)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            builder
                .ForValueType<bool>().Use<NullableValueConverter<bool>>()
                .ForValueType<byte>().Use<ValueConverter<byte>>()
                .ForValueType<char>().Use<ValueConverter<char>>()
                .ForValueType<DateTime>().Use<DateTimeValueConverter>()
                .ForValueType<DateTimeOffset>().Use<DateTimeOffsetValueConverter>()
                .ForValueType<decimal>().Use<ValueConverter<decimal>>()
                .ForValueType<double>().Use<ValueConverter<double>>()
                .ForValueType<float>().Use<ValueConverter<float>>()
                .ForValueType<Guid>().Use<ValueConverter<Guid>>()
                .ForValueType<int>().Use<ValueConverter<int>>()
                .ForValueType<long>().Use<ValueConverter<long>>()
                .ForValueType<short>().Use<ValueConverter<short>>()
                .ForValueType<TimeSpan>().Use<ValueConverter<TimeSpan>>()

                .ForValueType<bool?>().Use<NullableValueConverter<bool?>>()
                .ForValueType<byte?>().Use<NullableValueConverter<byte?>>()
                .ForValueType<char?>().Use<NullableValueConverter<char?>>()
                .ForValueType<DateTime?>().Use<NullableDateTimeValueConverter>()
                .ForValueType<DateTimeOffset?>().Use<NullableDateTimeOffsetValueConverter>()
                .ForValueType<decimal?>().Use<NullableValueConverter<decimal?>>()
                .ForValueType<double?>().Use<NullableValueConverter<double?>>()
                .ForValueType<float?>().Use<NullableValueConverter<float?>>()
                .ForValueType<Guid?>().Use<NullableValueConverter<Guid?>>()
                .ForValueType<int?>().Use<NullableValueConverter<int?>>()
                .ForValueType<long?>().Use<NullableValueConverter<long?>>()
                .ForValueType<short?>().Use<NullableValueConverter<short?>>()
                .ForValueType<TimeSpan?>().Use<NullableValueConverter<TimeSpan?>>()

                .ForValueType<string>().Use<StringValueConverter>()
                .ForValueType<string?>().Use<NullableStringValueConverter>()
                .ForValueType<byte[]>().Use<NullableObjectConverter<byte[]>>()
                .ForValueType<byte[]?>().Use<NullableObjectConverter<byte[]?>>()
                .ForValueType<object>().Use<ObjectConverter>();
        }

        public static void WithDefaults<TDatabase>(this IExpressionElementAppenderFactoryContinuationConfigurationBuilder<TDatabase> builder)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            builder
                .ForElementType<SelectQueryExpression>().Use<SelectQueryExpressionAppender>()
                .ForElementType<UpdateQueryExpression>().Use<UpdateQueryExpressionAppender>()
                .ForElementType<DeleteQueryExpression>().Use<DeleteQueryExpressionAppender>()
                .ForElementType<QueryExpressionContinuationExpression>().Use<QueryExpressionContinuationExpressionAppender>()
                .ForElementType<SchemaExpression>().Use<SchemaExpressionAppender>()
                .ForElementType<EntityExpression>().Use<EntityExpressionAppender>()
                .ForElementType<FieldExpression>().Use<FieldExpressionAppender>()
                .ForElementType<AssignmentExpression>().Use<AssignmentExpressionAppender>()
                .ForElementType<AssignmentExpressionSet>().Use<AssignmentExpressionSetAppender>()
                .ForElementType<SelectExpression>().Use<SelectExpressionAppender>()
                .ForElementType<SelectExpressionSet>().Use<SelectExpressionSetAppender>()
                .ForElementType<FromExpression>().Use<FromExpressionAppender>()
                .ForElementType<FilterExpression>().Use<FilterExpressionAppender>()
                .ForElementType<FilterExpressionSet>().Use<FilterExpressionSetAppender>()
                .ForElementType<JoinExpression>().Use<JoinExpressionAppender>()
                .ForElementType<JoinExpressionSet>().Use<JoinExpressionSetAppender>()
                .ForElementType<GroupByExpression>().Use<GroupByExpressionAppender>()
                .ForElementType<GroupByExpressionSet>().Use<GroupByExpressionSetAppender>()
                .ForElementType<HavingExpression>().Use<HavingExpressionAppender>()
                .ForElementType<OrderByExpression>().Use<OrderByExpressionAppender>()
                .ForElementType<OrderByExpressionSet>().Use<OrderByExpressionSetAppender>()
                .ForElementType<ArithmeticExpression>().Use<ArithmeticExpressionAppender>()
                .ForElementType<ExpressionMediator>().Use<ExpressionMediatorAppender>()
                .ForElementType<CastFunctionExpression>().Use<CastFunctionExpressionAppender>()
                .ForElementType<CoalesceFunctionExpression>().Use<CoalesceFunctionExpressionAppender>()
                .ForElementType<ConcatFunctionExpression>().Use<ConcatFunctionExpressionAppender>()
                .ForElementType<IsNullFunctionExpression>().Use<IsNullFunctionExpressionAppender>()
                .ForElementType<AverageFunctionExpression>().Use<AverageFunctionExpressionAppender>()
                .ForElementType<MinimumFunctionExpression>().Use<MinimumFunctionExpressionAppender>()
                .ForElementType<MaximumFunctionExpression>().Use<MaximumFunctionExpressionAppender>()
                .ForElementType<CountFunctionExpression>().Use<CountFunctionExpressionAppender>()
                .ForElementType<SumFunctionExpression>().Use<SumFunctionExpressionAppender>()
                .ForElementType<StandardDeviationFunctionExpression>().Use<StandardDeviationFunctionExpressionAppender>()
                .ForElementType<PopulationStandardDeviationFunctionExpression>().Use<PopulationStandardDeviationFunctionExpressionAppender>()
                .ForElementType<VarianceFunctionExpression>().Use<VarianceFunctionExpressionAppender>()
                .ForElementType<PopulationVarianceFunctionExpression>().Use<PopulationVarianceFunctionExpressionAppender>()
                .ForElementType<CurrentTimestampFunctionExpression>().Use<CurrentTimestampFunctionExpressionAppender>()
                .ForElementType<FloorFunctionExpression>().Use<FloorFunctionExpressionAppender>()
                .ForElementType<CeilingFunctionExpression>().Use<CeilingFunctionExpressionAppender>()
                .ForElementType<TrimFunctionExpression>().Use<TrimFunctionExpressionAppender>()
                .ForElementType<LTrimFunctionExpression>().Use<LTrimFunctionExpressionAppender>()
                .ForElementType<RTrimFunctionExpression>().Use<RTrimFunctionExpressionAppender>()
                .ForElementType<LeftFunctionExpression>().Use<LeftFunctionExpressionAppender>()
                .ForElementType<RightFunctionExpression>().Use<RightFunctionExpressionAppender>()
                .ForElementType<AbsFunctionExpression>().Use<AbsFunctionExpressionAppender>()
                .ForElementType<SubstringFunctionExpression>().Use<SubstringFunctionExpressionAppender>()
                .ForElementType<ReplaceFunctionExpression>().Use<ReplaceFunctionExpressionAppender>()
                .ForElementType<LiteralExpression>().Use<LiteralExpressionAppender>()
                .ForElementType<AliasExpression>().Use<AliasExpressionAppender>()
                .ForElementType<InExpression>().Use<InExpressionAppender>()
                .ForElementType<LikeExpression>().Use<LikeExpressionAppender>()
                .ForElementType<DbTypeExpression>().Use<DbTypeExpressionAppender>()
                .ForElementType<StoredProcedureExpression>().Use<StoredProcedureExpressionAppender>()
                .ForElementType<ParameterExpression>().Use<ParameterExpressionAppender>()
                .ForElementType<UnionExpression>().Use<UnionExpressionAppender>()
                .ForElementType<UnionAllExpression>().Use<UnionAllExpressionAppender>()
                .ForElementType<NullExpression>().Use<NullExpressionAppender>()
                .ForElementType<SinFunctionExpression>().Use<SinFunctionExpressionAppender>()
                .ForElementType<ASinFunctionExpression>().Use<ASinFunctionExpressionAppender>()
                .ForElementType<TanFunctionExpression>().Use<TanFunctionExpressionAppender>()
                .ForElementType<ATanFunctionExpression>().Use<ATanFunctionExpressionAppender>()
                .ForElementType<CosFunctionExpression>().Use<CosFunctionExpressionAppender>()
                .ForElementType<ACosFunctionExpression>().Use<ACosFunctionExpressionAppender>()
                .ForElementType<CotFunctionExpression>().Use<CotFunctionExpressionAppender>()
                .ForElementType<SqrtFunctionExpression>().Use<SqrtFunctionExpressionAppender>()
                .ForElementType<ExpFunctionExpression>().Use<ExpFunctionExpressionAppender>()
                .ForElementType<RandFunctionExpression>().Use<RandFunctionExpressionAppender>()
                .ForElementType<SquareFunctionExpression>().Use<SquareFunctionExpressionAppender>();
        }
    }
}
