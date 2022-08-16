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

using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlQueryExpressionBuilder : IQueryExpressionBuilder
    {
        #region internals
        private readonly IQueryExpressionFactory queryExpressionFactory;
        private readonly IQueryExecutionPipelineFactory executionPipelineFactory;
        #endregion

        #region constructors
        public MsSqlQueryExpressionBuilder(
            IQueryExpressionFactory queryExpressionFactory,
            IQueryExecutionPipelineFactory executionPipelineFactory
        )
        {
            this.queryExpressionFactory = queryExpressionFactory ?? throw new ArgumentNullException(nameof(queryExpressionFactory));
            this.executionPipelineFactory = executionPipelineFactory ?? throw new ArgumentNullException(nameof(executionPipelineFactory));
        }
        #endregion

        #region select one
        public virtual SelectEntity<TEntity> CreateSelectEntityBuilder<TEntity>(Table<TEntity> table)
            where TEntity : class, IDbEntity, new()
        {
            return (new EntitySelectSetQueryExpressionBuilder<TEntity>(
                queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>,
                executionPipelineFactory.CreateSelectSetQueryExecutionPipeline,
                executionPipelineFactory.CreateSelectQueryExecutionPipeline,
                table
            ) as SelectOneInitiation)!.SelectOne<TEntity>();
        }

        public virtual SelectDynamic CreateSelectDynamicBuilder(AnyElement element1, AnyElement element2, params AnyElement[] elements)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element1, element2, elements);

        public virtual SelectDynamic CreateSelectDynamicBuilder(IEnumerable<AnyElement> elements)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(elements);

        public virtual SelectValue<TEnum> CreateSelectValueBuilder<TEnum>(AnyElement<TEnum> element)
            where TEnum : struct, Enum, IComparable
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TEnum?> CreateSelectValueBuilder<TEnum>(AnyElement<TEnum?> element)
            where TEnum : struct, Enum, IComparable
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<object> CreateSelectValueBuilder(ObjectElement element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element)!;

        public virtual SelectValue<object?> CreateSelectValueBuilder(NullableObjectElement element)
           => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectObject<T> CreateSelectValueBuilder<T>(ObjectElement<T> element)
            where T : class?
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<T> CreateSelectValueBuilder<T>(AliasedElement<T> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<bool> CreateSelectValueBuilder(AnyElement<bool> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<bool?> CreateSelectValueBuilder(AnyElement<bool?> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<byte> CreateSelectValueBuilder(AnyElement<byte> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<byte?> CreateSelectValueBuilder(AnyElement<byte?> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<byte[]> CreateSelectValueBuilder(AnyElement<byte[]> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<DateTime> CreateSelectValueBuilder(AnyElement<DateTime> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<DateTime?> CreateSelectValueBuilder(AnyElement<DateTime?> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<DateTimeOffset> CreateSelectValueBuilder(AnyElement<DateTimeOffset> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<DateTimeOffset?> CreateSelectValueBuilder(AnyElement<DateTimeOffset?> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<decimal> CreateSelectValueBuilder(AnyElement<decimal> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<decimal?> CreateSelectValueBuilder(AnyElement<decimal?> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<double> CreateSelectValueBuilder(AnyElement<double> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<double?> CreateSelectValueBuilder(AnyElement<double?> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<Guid> CreateSelectValueBuilder(AnyElement<Guid> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<Guid?> CreateSelectValueBuilder(AnyElement<Guid?> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<short> CreateSelectValueBuilder(AnyElement<short> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<short?> CreateSelectValueBuilder(AnyElement<short?> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<int> CreateSelectValueBuilder(AnyElement<int> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<int?> CreateSelectValueBuilder(AnyElement<int?> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<long> CreateSelectValueBuilder(AnyElement<long> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<long?> CreateSelectValueBuilder(AnyElement<long?> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<float> CreateSelectValueBuilder(AnyElement<float> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<float?> CreateSelectValueBuilder(AnyElement<float?> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<string> CreateSelectValueBuilder(StringElement element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<string?> CreateSelectValueBuilder(NullableStringElement element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TimeSpan> CreateSelectValueBuilder(AnyElement<TimeSpan> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TimeSpan?> CreateSelectValueBuilder(AnyElement<TimeSpan?> element)
            => CreateSelectBuilder<SelectOneInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);
        #endregion

        #region select many
        public virtual SelectEntities<TEntity> CreateSelectEntitiesBuilder<TEntity>(Table<TEntity> table)
            where TEntity : class, IDbEntity, new()
        {
            return (new EntitySelectSetQueryExpressionBuilder<TEntity>(
                queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>,
                executionPipelineFactory.CreateSelectSetQueryExecutionPipeline,
                executionPipelineFactory.CreateSelectQueryExecutionPipeline,
                table
            ) as SelectManyInitiation)!.SelectMany<TEntity>();
        }

        public virtual SelectDynamics CreateSelectDynamicsBuilder(AnyElement element1, AnyElement element2, params AnyElement[] elements)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element1, element2, elements);

        public virtual SelectDynamics CreateSelectDynamicsBuilder(IEnumerable<AnyElement> elements)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(elements);

        public virtual SelectValues<TEnum> CreateSelectValuesBuilder<TEnum>(AnyElement<TEnum> element)
            where TEnum : struct, Enum, IComparable
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TEnum?> CreateSelectValuesBuilder<TEnum>(AnyElement<TEnum?> element)
            where TEnum : struct, Enum, IComparable
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<object> CreateSelectValuesBuilder(ObjectElement element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element)!;

        public virtual SelectValues<object?> CreateSelectValuesBuilder(NullableObjectElement element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectObjects<T> CreateSelectValuesBuilder<T>(ObjectElement<T> element)
            where T : class?
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany<T>(element);

        public virtual SelectValues<T> CreateSelectValuesBuilder<T>(AliasedElement<T> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany<T>(element);
        
        public virtual SelectValues<bool> CreateSelectValuesBuilder(AnyElement<bool> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<bool?> CreateSelectValuesBuilder(AnyElement<bool?> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<byte> CreateSelectValuesBuilder(AnyElement<byte> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<byte?> CreateSelectValuesBuilder(AnyElement<byte?> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<byte[]> CreateSelectValuesBuilder(AnyElement<byte[]> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<DateTime> CreateSelectValuesBuilder(AnyElement<DateTime> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<DateTime?> CreateSelectValuesBuilder(AnyElement<DateTime?> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<DateTimeOffset> CreateSelectValuesBuilder(AnyElement<DateTimeOffset> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<DateTimeOffset?> CreateSelectValuesBuilder(AnyElement<DateTimeOffset?> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<decimal> CreateSelectValuesBuilder(AnyElement<decimal> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<decimal?> CreateSelectValuesBuilder(AnyElement<decimal?> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<double> CreateSelectValuesBuilder(AnyElement<double> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<double?> CreateSelectValuesBuilder(AnyElement<double?> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<Guid> CreateSelectValuesBuilder(AnyElement<Guid> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<Guid?> CreateSelectValuesBuilder(AnyElement<Guid?> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<short> CreateSelectValuesBuilder(AnyElement<short> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<short?> CreateSelectValuesBuilder(AnyElement<short?> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<int> CreateSelectValuesBuilder(AnyElement<int> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<int?> CreateSelectValuesBuilder(AnyElement<int?> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<long> CreateSelectValuesBuilder(AnyElement<long> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<long?> CreateSelectValuesBuilder(AnyElement<long?> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<float> CreateSelectValuesBuilder(AnyElement<float> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<float?> CreateSelectValuesBuilder(AnyElement<float?> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<string> CreateSelectValuesBuilder(StringElement element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<string?> CreateSelectValuesBuilder(NullableStringElement element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TimeSpan> CreateSelectValuesBuilder(AnyElement<TimeSpan> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TimeSpan?> CreateSelectValuesBuilder(AnyElement<TimeSpan?> element)
            => CreateSelectBuilder<SelectManyInitiation>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        private TReturn CreateSelectBuilder<TReturn>(Func<SelectQueryExpression> queryExpressionFactory)
            where TReturn : class
        {
            return (new SelectSetQueryExpressionBuilder(
                queryExpressionFactory,
                executionPipelineFactory.CreateSelectSetQueryExecutionPipeline,
                executionPipelineFactory.CreateSelectQueryExecutionPipeline
            ) as TReturn) ?? throw new DbExpressionException($"Expected query builder to implement interface {typeof(TReturn)}, but it does not.");
        }
        #endregion

        #region update
        public virtual UpdateEntities CreateUpdateExpressionBuilder(EntityFieldAssignment assignment, params EntityFieldAssignment[] assignments)
        {
            var query = queryExpressionFactory.CreateQueryExpression<UpdateQueryExpression>();
            query.Assign = new AssignmentExpressionSet(
                new List<AssignmentExpression>(assignments.Length + 1)
                {
                    assignment as AssignmentExpression ?? throw new DbExpressionException($"Expected {nameof(assignment)} to be assignable to {typeof(AssignmentExpression)}.")
                }
                .Concat(assignments.Select(x => x as AssignmentExpression ?? throw new DbExpressionException($"Expected all {nameof(assignments)} to be assignable to {typeof(AssignmentExpression)}.")))
            );
            return new UpdateQueryExpressionBuilder(
                query,
                executionPipelineFactory.CreateUpdateQueryExecutionPipeline
            );
        }

        public virtual UpdateEntities CreateUpdateExpressionBuilder(IEnumerable<EntityFieldAssignment> assignments)
        {
            var query = queryExpressionFactory.CreateQueryExpression<UpdateQueryExpression>();
            query.Assign = new AssignmentExpressionSet((assignments ?? throw new ArgumentNullException(nameof(assignments))).Select(x => x as AssignmentExpression ?? throw new DbExpressionException($"Expected all {nameof(assignments)} to be assignable to {typeof(AssignmentExpression)}.")));
            return new UpdateQueryExpressionBuilder(
                query,
                executionPipelineFactory.CreateUpdateQueryExecutionPipeline
            );
        }
        #endregion

        #region delete
        public virtual DeleteEntities CreateDeleteExpressionBuilder()
        {
            var query = queryExpressionFactory.CreateQueryExpression<DeleteQueryExpression>();
            return new DeleteQueryExpressionBuilder(
                query,
                executionPipelineFactory.CreateDeleteQueryExecutionPipeline
            );
        }
        #endregion

        #region insert
        public virtual InsertEntity<TEntity> CreateInsertExpressionBuilder<TEntity>(TEntity instance)
            where TEntity : class, IDbEntity
        {
            var query = queryExpressionFactory.CreateQueryExpression<InsertQueryExpression>();
            return new InsertQueryExpressionBuilder<TEntity>(
                query,
                new[] { instance },
                executionPipelineFactory.CreateInsertQueryExecutionPipeline
            );
        }

        public virtual InsertEntities<TEntity> CreateInsertExpressionBuilder<TEntity>(TEntity entity, params TEntity[] entities)
            where TEntity : class, IDbEntity
        {
            var query = queryExpressionFactory.CreateQueryExpression<InsertQueryExpression>();
            return new InsertQueryExpressionBuilder<TEntity>(
                query,
                new List<TEntity>(entities.Length + 1) { entity }.Concat(entities),
                executionPipelineFactory.CreateInsertQueryExecutionPipeline
            );
        }

        public virtual InsertEntities<TEntity> CreateInsertExpressionBuilder<TEntity>(IEnumerable<TEntity> instances)
            where TEntity : class, IDbEntity
        {
            var query = queryExpressionFactory.CreateQueryExpression<InsertQueryExpression>();
            return new InsertQueryExpressionBuilder<TEntity>(
                query,
                instances ?? throw new ArgumentNullException(nameof(instances)),
                executionPipelineFactory.CreateInsertQueryExecutionPipeline
            );
        }
        #endregion

        #region stored procedure
        public virtual StoredProcedureContinuation CreateStoredProcedureBuilder(StoredProcedureExpression entity)
        {
            var query = queryExpressionFactory.CreateQueryExpression<StoredProcedureQueryExpression>();
            return new StoredProcedureQueryExpressionBuilder(
                query,
                entity,
                executionPipelineFactory.CreateStoredProcedureExecutionPipeline
            );
        }
        #endregion
    }
}
