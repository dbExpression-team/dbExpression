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
using System.Xml.Linq;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlQueryExpressionBuilder<TDatabase> : IQueryExpressionBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly IQueryExpressionFactory queryExpressionFactory;
        private readonly IQueryExpressionExecutionPipelineFactory executionPipelineFactory;
        #endregion

        #region constructors
        public MsSqlQueryExpressionBuilder(
            IQueryExpressionFactory queryExpressionFactory,
            IQueryExpressionExecutionPipelineFactory executionPipelineFactory
        )
        {
            this.queryExpressionFactory = queryExpressionFactory ?? throw new ArgumentNullException(nameof(queryExpressionFactory));
            this.executionPipelineFactory = executionPipelineFactory ?? throw new ArgumentNullException(nameof(executionPipelineFactory));
        }
        #endregion

        #region select one
        public virtual SelectEntity<TDatabase, TEntity> CreateSelectEntityBuilder<TEntity>(Table<TEntity> table)
            where TEntity : class, IDbEntity, new()
        {
            var builder = new SelectEntitySelectQueryExpressionBuilder<TDatabase, TEntity>(
                queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>,
                executionPipelineFactory.CreateSelectQueryExecutionPipeline,
                table
            );
            builder.SelectQueryExpression.Select = table.BuildInclusiveSelectExpression() ?? throw new DbExpressionException($"Select expressions for entity {typeof(TEntity)} were not provided.");
            return builder;
        }

        public virtual SelectDynamic<TDatabase> CreateSelectDynamicBuilder(AnyElement element1, AnyElement element2, params AnyElement[] elements)
        {
            return (new SelectDynamicSelectQueryExpressionBuilder<TDatabase>(
                queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>,
                executionPipelineFactory.CreateSelectQueryExecutionPipeline
            ) as SelectOneInitiation<TDatabase>).SelectOne(element1, element2, elements);
        }

        public virtual SelectDynamic<TDatabase> CreateSelectDynamicBuilder(IEnumerable<AnyElement> elements)
        {
            return (new SelectDynamicSelectQueryExpressionBuilder<TDatabase>(
                queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>,
                executionPipelineFactory.CreateSelectQueryExecutionPipeline
            ) as SelectOneInitiation<TDatabase>).SelectOne(elements);
        }

        public virtual SelectValue<TDatabase, TEnum> CreateSelectValueBuilder<TEnum>(AnyElement<TEnum> element)
            where TEnum : struct, Enum, IComparable
            => CreateSelectValueBuilder<TEnum>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, TEnum?> CreateSelectValueBuilder<TEnum>(AnyElement<TEnum?> element)
            where TEnum : struct, Enum, IComparable
            => CreateSelectValueBuilder<TEnum?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, object> CreateSelectValueBuilder(ObjectElement element)
            => CreateSelectValueBuilder<object>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element)!;

        public virtual SelectValue<TDatabase, object?> CreateSelectValueBuilder(NullableObjectElement element)
            => CreateSelectValueBuilder<object?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectObject<TDatabase, T> CreateSelectValueBuilder<T>(ObjectElement<T> element)
            where T : class?
            => CreateSelectValueBuilder<T>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, T> CreateSelectValueBuilder<T>(AliasedElement<T> element)
            => CreateSelectValueBuilder<T>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, bool> CreateSelectValueBuilder(AnyElement<bool> element)
            => CreateSelectValueBuilder<bool>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, bool?> CreateSelectValueBuilder(AnyElement<bool?> element)
            => CreateSelectValueBuilder<bool?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, byte> CreateSelectValueBuilder(AnyElement<byte> element)
            => CreateSelectValueBuilder<byte>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, byte?> CreateSelectValueBuilder(AnyElement<byte?> element)
            => CreateSelectValueBuilder<byte?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, byte[]> CreateSelectValueBuilder(AnyElement<byte[]> element)
            => CreateSelectValueBuilder<byte[]>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, DateTime> CreateSelectValueBuilder(AnyElement<DateTime> element)
            => CreateSelectValueBuilder<DateTime>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, DateTime?> CreateSelectValueBuilder(AnyElement<DateTime?> element)
            => CreateSelectValueBuilder<DateTime?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, DateTimeOffset> CreateSelectValueBuilder(AnyElement<DateTimeOffset> element)
            => CreateSelectValueBuilder<DateTimeOffset>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, DateTimeOffset?> CreateSelectValueBuilder(AnyElement<DateTimeOffset?> element)
            => CreateSelectValueBuilder<DateTimeOffset?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, decimal> CreateSelectValueBuilder(AnyElement<decimal> element)
            => CreateSelectValueBuilder<decimal>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, decimal?> CreateSelectValueBuilder(AnyElement<decimal?> element)
            => CreateSelectValueBuilder<decimal?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, double> CreateSelectValueBuilder(AnyElement<double> element)
            => CreateSelectValueBuilder<double>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, double?> CreateSelectValueBuilder(AnyElement<double?> element)
            => CreateSelectValueBuilder<double?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, Guid> CreateSelectValueBuilder(AnyElement<Guid> element)
            => CreateSelectValueBuilder<Guid>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, Guid?> CreateSelectValueBuilder(AnyElement<Guid?> element)
            => CreateSelectValueBuilder<Guid?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, short> CreateSelectValueBuilder(AnyElement<short> element)
            => CreateSelectValueBuilder<short>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, short?> CreateSelectValueBuilder(AnyElement<short?> element)
            => CreateSelectValueBuilder<short?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, int> CreateSelectValueBuilder(AnyElement<int> element)
            => CreateSelectValueBuilder<int>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, int?> CreateSelectValueBuilder(AnyElement<int?> element)
            => CreateSelectValueBuilder<int?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, long> CreateSelectValueBuilder(AnyElement<long> element)
            => CreateSelectValueBuilder<long>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, long?> CreateSelectValueBuilder(AnyElement<long?> element)
            => CreateSelectValueBuilder<long?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, float> CreateSelectValueBuilder(AnyElement<float> element)
            => CreateSelectValueBuilder<float>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, float?> CreateSelectValueBuilder(AnyElement<float?> element)
            => CreateSelectValueBuilder<float?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, string> CreateSelectValueBuilder(StringElement element)
            => CreateSelectValueBuilder<TimeSpan?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, string?> CreateSelectValueBuilder(NullableStringElement element)
            => CreateSelectValueBuilder<string?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, TimeSpan> CreateSelectValueBuilder(AnyElement<TimeSpan> element)
            => CreateSelectValueBuilder<TimeSpan>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);

        public virtual SelectValue<TDatabase, TimeSpan?> CreateSelectValueBuilder(AnyElement<TimeSpan?> element)
            => CreateSelectValueBuilder<TimeSpan?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectOne(element);
        #endregion

        #region select many
        public virtual SelectEntities<TDatabase, TEntity> CreateSelectEntitiesBuilder<TEntity>(Table<TEntity> table)
            where TEntity : class, IDbEntity, new()
        {
            var builder = new SelectEntitiesSelectQueryExpressionBuilder<TDatabase, TEntity>(
                queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>,
                executionPipelineFactory.CreateSelectQueryExecutionPipeline,
                table
            );
            builder.SelectQueryExpression.Select = table.BuildInclusiveSelectExpression() ?? throw new DbExpressionException($"Select expressions for entity {typeof(TEntity)} were not provided.");
            return builder;
        }

        public virtual SelectDynamics<TDatabase> CreateSelectDynamicsBuilder(AnyElement element1, AnyElement element2, params AnyElement[] elements)
        {
            return (new SelectDynamicsSelectQueryExpressionBuilder<TDatabase>(
                queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>,
                executionPipelineFactory.CreateSelectQueryExecutionPipeline
            ) as SelectManyInitiation<TDatabase>).SelectMany(element1, element2, elements);
        }

        public virtual SelectDynamics<TDatabase> CreateSelectDynamicsBuilder(IEnumerable<AnyElement> elements)
        {
            return (new SelectDynamicsSelectQueryExpressionBuilder<TDatabase>(
                queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>,
                executionPipelineFactory.CreateSelectQueryExecutionPipeline
            ) as SelectManyInitiation<TDatabase>).SelectMany(elements);
        }

        public virtual SelectValues<TDatabase, TEnum> CreateSelectValuesBuilder<TEnum>(AnyElement<TEnum> element)
            where TEnum : struct, Enum, IComparable
            => CreateSelectValuesBuilder<TEnum>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, TEnum?> CreateSelectValuesBuilder<TEnum>(AnyElement<TEnum?> element)
            where TEnum : struct, Enum, IComparable
            => CreateSelectValuesBuilder<TEnum?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, object> CreateSelectValuesBuilder(ObjectElement element)
            => CreateSelectValuesBuilder<object>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element)!;

        public virtual SelectValues<TDatabase, object?> CreateSelectValuesBuilder(NullableObjectElement element)
            => CreateSelectValuesBuilder<object?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectObjects<TDatabase, T> CreateSelectValuesBuilder<T>(ObjectElement<T> element)
            where T : class?
            => CreateSelectValuesBuilder<T>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany<T>(element);

        public virtual SelectValues<TDatabase, T> CreateSelectValuesBuilder<T>(AliasedElement<T> element)
            => CreateSelectValuesBuilder<T>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany<T>(element);
        
        public virtual SelectValues<TDatabase, bool> CreateSelectValuesBuilder(AnyElement<bool> element)
            => CreateSelectValuesBuilder<bool>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, bool?> CreateSelectValuesBuilder(AnyElement<bool?> element)
            => CreateSelectValuesBuilder<bool?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, byte> CreateSelectValuesBuilder(AnyElement<byte> element)
            => CreateSelectValuesBuilder<byte>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, byte?> CreateSelectValuesBuilder(AnyElement<byte?> element)
            => CreateSelectValuesBuilder<byte?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, byte[]> CreateSelectValuesBuilder(AnyElement<byte[]> element)
            => CreateSelectValuesBuilder<byte[]>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, DateTime> CreateSelectValuesBuilder(AnyElement<DateTime> element)
            => CreateSelectValuesBuilder<DateTime>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, DateTime?> CreateSelectValuesBuilder(AnyElement<DateTime?> element)
            => CreateSelectValuesBuilder<DateTime?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, DateTimeOffset> CreateSelectValuesBuilder(AnyElement<DateTimeOffset> element)
            => CreateSelectValuesBuilder<DateTimeOffset>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, DateTimeOffset?> CreateSelectValuesBuilder(AnyElement<DateTimeOffset?> element)
            => CreateSelectValuesBuilder<DateTimeOffset?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, decimal> CreateSelectValuesBuilder(AnyElement<decimal> element)
            => CreateSelectValuesBuilder<decimal>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, decimal?> CreateSelectValuesBuilder(AnyElement<decimal?> element)
            => CreateSelectValuesBuilder<decimal?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, double> CreateSelectValuesBuilder(AnyElement<double> element)
            => CreateSelectValuesBuilder<double>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, double?> CreateSelectValuesBuilder(AnyElement<double?> element)
            => CreateSelectValuesBuilder<double?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, Guid> CreateSelectValuesBuilder(AnyElement<Guid> element)
            => CreateSelectValuesBuilder<Guid>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, Guid?> CreateSelectValuesBuilder(AnyElement<Guid?> element)
            => CreateSelectValuesBuilder<Guid?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, short> CreateSelectValuesBuilder(AnyElement<short> element)
            => CreateSelectValuesBuilder<short>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, short?> CreateSelectValuesBuilder(AnyElement<short?> element)
            => CreateSelectValuesBuilder<short?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, int> CreateSelectValuesBuilder(AnyElement<int> element)
            => CreateSelectValuesBuilder<int>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, int?> CreateSelectValuesBuilder(AnyElement<int?> element)
            => CreateSelectValuesBuilder<int?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, long> CreateSelectValuesBuilder(AnyElement<long> element)
            => CreateSelectValuesBuilder<long>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, long?> CreateSelectValuesBuilder(AnyElement<long?> element)
            => CreateSelectValuesBuilder<long?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, float> CreateSelectValuesBuilder(AnyElement<float> element)
            => CreateSelectValuesBuilder<float>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, float?> CreateSelectValuesBuilder(AnyElement<float?> element)
            => CreateSelectValuesBuilder<float?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, string> CreateSelectValuesBuilder(StringElement element)
            => CreateSelectValuesBuilder<string>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, string?> CreateSelectValuesBuilder(NullableStringElement element)
            => CreateSelectValuesBuilder<string?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, TimeSpan> CreateSelectValuesBuilder(AnyElement<TimeSpan> element)
            => CreateSelectValuesBuilder<TimeSpan>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);

        public virtual SelectValues<TDatabase, TimeSpan?> CreateSelectValuesBuilder(AnyElement<TimeSpan?> element)
            => CreateSelectValuesBuilder<TimeSpan?>(queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>).SelectMany(element);


        private SelectOneInitiation<TDatabase> CreateSelectValueBuilder<TValue>(Func<SelectQueryExpression> queryExpressionFactory)
        {
            return new SelectValueSelectQueryExpressionBuilder<TDatabase, TValue>(
                queryExpressionFactory,
                executionPipelineFactory.CreateSelectQueryExecutionPipeline
            );
        }

        private SelectManyInitiation<TDatabase> CreateSelectValuesBuilder<TValue>(Func<SelectQueryExpression> queryExpressionFactory)
        {
            return new SelectValuesSelectQueryExpressionBuilder<TDatabase, TValue>(
                queryExpressionFactory,
                executionPipelineFactory.CreateSelectQueryExecutionPipeline
            );
        }
        #endregion

        #region update
        public virtual UpdateEntities<TDatabase> CreateUpdateExpressionBuilder(EntityFieldAssignment assignment, params EntityFieldAssignment[] assignments)
        {
            var query = queryExpressionFactory.CreateQueryExpression<UpdateQueryExpression>();
            query.Assign = new AssignmentExpressionSet(
                new List<AssignmentExpression>(assignments.Length + 1)
                {
                    assignment as AssignmentExpression ?? throw new DbExpressionException($"Expected {nameof(assignment)} to be assignable to {typeof(AssignmentExpression)}.")
                }
                .Concat(assignments.Select(x => x as AssignmentExpression ?? throw new DbExpressionException($"Expected all {nameof(assignments)} to be assignable to {typeof(AssignmentExpression)}.")))
            );
            return new UpdateQueryExpressionBuilder<TDatabase>(
                query,
                executionPipelineFactory.CreateUpdateQueryExecutionPipeline
            );
        }

        public virtual UpdateEntities<TDatabase> CreateUpdateExpressionBuilder(IEnumerable<EntityFieldAssignment> assignments)
        {
            var query = queryExpressionFactory.CreateQueryExpression<UpdateQueryExpression>();
            query.Assign = new AssignmentExpressionSet((assignments ?? throw new ArgumentNullException(nameof(assignments))).Select(x => x as AssignmentExpression ?? throw new DbExpressionException($"Expected all {nameof(assignments)} to be assignable to {typeof(AssignmentExpression)}.")));
            return new UpdateQueryExpressionBuilder<TDatabase>(
                query,
                executionPipelineFactory.CreateUpdateQueryExecutionPipeline
            );
        }
        #endregion

        #region delete
        public virtual DeleteEntities<TDatabase> CreateDeleteExpressionBuilder()
        {
            var query = queryExpressionFactory.CreateQueryExpression<DeleteQueryExpression>();
            return new DeleteQueryExpressionBuilder<TDatabase>(
                query,
                executionPipelineFactory.CreateDeleteQueryExecutionPipeline
            );
        }
        #endregion

        #region insert
        public virtual InsertEntity<TDatabase, TEntity> CreateInsertExpressionBuilder<TEntity>(TEntity instance)
            where TEntity : class, IDbEntity
        {
            var query = queryExpressionFactory.CreateQueryExpression<InsertQueryExpression>();
            return new InsertQueryExpressionBuilder<TDatabase, TEntity>(
                query,
                new[] { instance },
                executionPipelineFactory.CreateInsertQueryExecutionPipeline
            );
        }

        public virtual InsertEntities<TDatabase, TEntity> CreateInsertExpressionBuilder<TEntity>(TEntity entity, params TEntity[] entities)
            where TEntity : class, IDbEntity
        {
            var query = queryExpressionFactory.CreateQueryExpression<InsertQueryExpression>();
            return new InsertQueryExpressionBuilder<TDatabase, TEntity>(
                query,
                new List<TEntity>(entities.Length + 1) { entity }.Concat(entities),
                executionPipelineFactory.CreateInsertQueryExecutionPipeline
            );
        }

        public virtual InsertEntities<TDatabase, TEntity> CreateInsertExpressionBuilder<TEntity>(IEnumerable<TEntity> instances)
            where TEntity : class, IDbEntity
        {
            var query = queryExpressionFactory.CreateQueryExpression<InsertQueryExpression>();
            return new InsertQueryExpressionBuilder<TDatabase, TEntity>(
                query,
                instances ?? throw new ArgumentNullException(nameof(instances)),
                executionPipelineFactory.CreateInsertQueryExecutionPipeline
            );
        }
        #endregion

        #region stored procedure
        public virtual StoredProcedureContinuation<TDatabase> CreateStoredProcedureBuilder(StoredProcedureExpression entity)
        {
            var query = queryExpressionFactory.CreateQueryExpression<StoredProcedureQueryExpression>();
            return new StoredProcedureQueryExpressionBuilder<TDatabase>(
                query,
                entity,
                executionPipelineFactory.CreateStoredProcedureExecutionPipeline
            );
        }
        #endregion
    }
}
