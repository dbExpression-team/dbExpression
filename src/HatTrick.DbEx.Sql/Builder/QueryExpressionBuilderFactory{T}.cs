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
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public class QueryExpressionBuilderFactory<TDatabase> : IQueryExpressionBuilderFactory<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        protected IQueryExpressionFactory QueryExpressionFactory { get; init; }
        protected IQueryExpressionExecutionPipelineFactory ExecutionPipelineFactory { get; init; }
        #endregion

        #region constructors
        public QueryExpressionBuilderFactory(
            IQueryExpressionFactory queryExpressionFactory,
            IQueryExpressionExecutionPipelineFactory executionPipelineFactory
        )
        {
            this.QueryExpressionFactory = queryExpressionFactory ?? throw new ArgumentNullException(nameof(queryExpressionFactory));
            this.ExecutionPipelineFactory = executionPipelineFactory ?? throw new ArgumentNullException(nameof(executionPipelineFactory));
        }
        #endregion

        #region methods
        #region insert
        public InsertEntities<TDatabase, TEntity> CreateInsertQueryBuilder<TEntity>(TEntity instance, params TEntity[] instances)
            where TEntity : class, IDbEntity
        {
            return new InsertQueryExpressionBuilder<TDatabase, TEntity>(
                QueryExpressionFactory, 
                ExecutionPipelineFactory,
                new List<TEntity>(instances.Length + 1)
                {
                    instance
                }
                .Concat(instances));
        }

        public InsertEntities<TDatabase, TEntity> CreateInsertQueryBuilder<TEntity>(IEnumerable<TEntity> instances)
            where TEntity : class, IDbEntity
        {
            return new InsertQueryExpressionBuilder<TDatabase, TEntity>(
                QueryExpressionFactory, 
                ExecutionPipelineFactory, 
                instances
            );
        }

        public InsertEntity<TDatabase, TEntity> CreateInsertQueryBuilder<TEntity>(TEntity instance)
            where TEntity : class, IDbEntity
        {
            return new InsertQueryExpressionBuilder<TDatabase, TEntity>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                new List<TEntity>() { instance }
            );
        }
        #endregion

        #region delete
        public DeleteEntities<TDatabase> CreateDeleteQueryBuilder()
            => new DeleteQueryExpressionBuilder<TDatabase>(QueryExpressionFactory, ExecutionPipelineFactory);
        #endregion

        #region update
        /// <inheritdoc />
        public UpdateEntities<TDatabase> CreateUpdateQueryBuilder(EntityFieldAssignment assignment, params EntityFieldAssignment[] assignments)
        {
            return new UpdateQueryExpressionBuilder<TDatabase>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                new List<EntityFieldAssignment>(assignments.Length + 1)
                {
                    assignment
                }
                .Concat(assignments)
            );
        }

        /// <inheritdoc />
        public UpdateEntities<TDatabase> CreateUpdateQueryBuilder(IEnumerable<EntityFieldAssignment> assignments)
        {
            return new UpdateQueryExpressionBuilder<TDatabase>(
                    QueryExpressionFactory,
                    ExecutionPipelineFactory,
                    assignments
                );
        }
        #endregion

        #region select
        #region select many
        /// <inheritdoc />
        public SelectEntities<TDatabase, TEntity> CreateSelectEntitiesBuilder<TEntity>(Table<TEntity> table)
            where TEntity : class, IDbEntity, new() 
            => DoCreateSelectEntitiesBuilder(table);

        /// <inheritdoc />
        public SelectDynamics<TDatabase> CreateSelectDynamicsBuilder(AnyElement element1, AnyElement element2, params AnyElement[] elements)
            => DoCreateSelectDynamicsBuilder(element1, element2, elements);

        /// <inheritdoc />
        public SelectDynamics<TDatabase> CreateSelectDynamicsBuilder(IEnumerable<AnyElement> elements)
            => DoCreateSelectDynamicsBuilder(elements);

        /// <inheritdoc />
        public SelectValues<TDatabase, TEnum> CreateSelectValuesBuilder<TEnum>(AnyElement<TEnum> element)
            where TEnum : struct, Enum, IComparable 
            => DoCreateSelectValuesBuilder(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, TEnum?> CreateSelectValuesBuilder<TEnum>(AnyElement<TEnum?> element)
            where TEnum : struct, Enum, IComparable 
            => DoCreateSelectValuesBuilder(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, object> CreateSelectValuesBuilder(ObjectElement element)
            => DoCreateSelectValuesBuilder<object>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, object?> CreateSelectValuesBuilder(NullableObjectElement element)
            => DoCreateSelectValuesBuilder<object?>(element);

        /// <inheritdoc />
        public SelectObjects<TDatabase, T> CreateSelectValuesBuilder<T>(ObjectElement<T> element)
            where T : class? 
            => DoCreateSelectObjectsBuilder<T>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, T> CreateSelectValuesBuilder<T>(AliasedElement<T> element)
            => DoCreateSelectValuesBuilder<T>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, bool> CreateSelectValuesBuilder(AnyElement<bool> element)
            => DoCreateSelectValuesBuilder<bool>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, bool?> CreateSelectValuesBuilder(AnyElement<bool?> element)
            => DoCreateSelectValuesBuilder<bool?>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, byte> CreateSelectValuesBuilder(AnyElement<byte> element)
            => DoCreateSelectValuesBuilder<byte>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, byte?> CreateSelectValuesBuilder(AnyElement<byte?> element)
            => DoCreateSelectValuesBuilder<byte?>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, byte[]> CreateSelectValuesBuilder(ByteArrayElement element)
            => DoCreateSelectValuesBuilder<byte[]>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, byte[]?> CreateSelectValuesBuilder(NullableByteArrayElement element)
            => DoCreateSelectValuesBuilder<byte[]?>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, DateTime> CreateSelectValuesBuilder(AnyElement<DateTime> element)
            => DoCreateSelectValuesBuilder<DateTime>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, DateTime?> CreateSelectValuesBuilder(AnyElement<DateTime?> element)
            => DoCreateSelectValuesBuilder<DateTime?>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, DateTimeOffset> CreateSelectValuesBuilder(AnyElement<DateTimeOffset> element)
            => DoCreateSelectValuesBuilder<DateTimeOffset>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, DateTimeOffset?> CreateSelectValuesBuilder(AnyElement<DateTimeOffset?> element)
            => DoCreateSelectValuesBuilder<DateTimeOffset?>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, decimal> CreateSelectValuesBuilder(AnyElement<decimal> element)
            => DoCreateSelectValuesBuilder<decimal>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, decimal?> CreateSelectValuesBuilder(AnyElement<decimal?> element)
            => DoCreateSelectValuesBuilder<decimal?>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, double> CreateSelectValuesBuilder(AnyElement<double> element)
            => DoCreateSelectValuesBuilder<double>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, double?> CreateSelectValuesBuilder(AnyElement<double?> element)
            => DoCreateSelectValuesBuilder<double?>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, Guid> CreateSelectValuesBuilder(AnyElement<Guid> element)
            => DoCreateSelectValuesBuilder<Guid>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, Guid?> CreateSelectValuesBuilder(AnyElement<Guid?> element)
            => DoCreateSelectValuesBuilder<Guid?>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, short> CreateSelectValuesBuilder(AnyElement<short> element)
            => DoCreateSelectValuesBuilder<short>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, short?> CreateSelectValuesBuilder(AnyElement<short?> element)
            => DoCreateSelectValuesBuilder<short?>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, int> CreateSelectValuesBuilder(AnyElement<int> element)
            => DoCreateSelectValuesBuilder<int>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, int?> CreateSelectValuesBuilder(AnyElement<int?> element)
            => DoCreateSelectValuesBuilder<int?>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, long> CreateSelectValuesBuilder(AnyElement<long> element)
            => DoCreateSelectValuesBuilder<long>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, long?> CreateSelectValuesBuilder(AnyElement<long?> element)
            => DoCreateSelectValuesBuilder<long?>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, float> CreateSelectValuesBuilder(AnyElement<float> element)
            => DoCreateSelectValuesBuilder<float>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, float?> CreateSelectValuesBuilder(AnyElement<float?> element)
            => DoCreateSelectValuesBuilder<float?>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, string> CreateSelectValuesBuilder(StringElement element)
            => DoCreateSelectValuesBuilder<string>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, string?> CreateSelectValuesBuilder(NullableStringElement element)
            => DoCreateSelectValuesBuilder<string?>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, TimeSpan> CreateSelectValuesBuilder(AnyElement<TimeSpan> element)
            => DoCreateSelectValuesBuilder<TimeSpan>(element);

        /// <inheritdoc />
        public SelectValues<TDatabase, TimeSpan?> CreateSelectValuesBuilder(AnyElement<TimeSpan?> element)
            => DoCreateSelectValuesBuilder<TimeSpan?>(element);


        private SelectValues<TDatabase, T> DoCreateSelectValuesBuilder<T>(AnyElement element)
        {
            return new SelectValuesSelectQueryExpressionBuilder<TDatabase, T>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                element
            );
        }

        private SelectValues<TDatabase, T> DoCreateSelectValuesBuilder<T>(AnyElement<T> element)
        {
            return new SelectValuesSelectQueryExpressionBuilder<TDatabase, T>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                element
            );
        }

        private SelectObjects<TDatabase, TObject> DoCreateSelectObjectsBuilder<TObject>(AnyElement element)
            where TObject : class?
        {
            return new SelectObjectsSelectQueryExpressionBuilder<TDatabase, TObject>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                element
            );
        }

        private SelectDynamics<TDatabase> DoCreateSelectDynamicsBuilder(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
        {
            return new SelectDynamicsSelectQueryExpressionBuilder<TDatabase>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                elements.Concat(additionalElements)
            );
        }

        private SelectDynamics<TDatabase> DoCreateSelectDynamicsBuilder(IEnumerable<AnyElement> elements)
        {
            return new SelectDynamicsSelectQueryExpressionBuilder<TDatabase>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                elements
            );
        }

        private SelectDynamics<TDatabase> DoCreateSelectDynamicsBuilder(AnyElement element1, AnyElement element2, params AnyElement[] elements)
        {
            return new SelectDynamicsSelectQueryExpressionBuilder<TDatabase>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                new List<AnyElement>(elements.Length + 2)
                {
                    element1,
                    element2
                }.Concat(elements)
            );
        }

        private SelectEntities<TDatabase, TEntity> DoCreateSelectEntitiesBuilder<TEntity>(Table<TEntity> table)
            where TEntity : class, IDbEntity, new()
        {
            return new SelectEntitiesSelectQueryExpressionBuilder<TDatabase, TEntity>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                table
            );
        }
        #endregion

        #region select one
        /// <inheritdoc />
        public SelectEntity<TDatabase, TEntity> CreateSelectEntityBuilder<TEntity>(Table<TEntity> table)
            where TEntity : class, IDbEntity, new()
            => DoCreateSelectEntityBuilder(table);

        /// <inheritdoc />
        public SelectDynamic<TDatabase> CreateSelectDynamicBuilder(AnyElement element1, AnyElement element2, params AnyElement[] elements)
            => DoCreateSelectDynamicBuilder(element1, element2, elements);

        /// <inheritdoc />
        public SelectDynamic<TDatabase> CreateSelectDynamicBuilder(IEnumerable<AnyElement> elements)
            => DoCreateSelectDynamicBuilder(elements);

        /// <inheritdoc />
        public SelectValue<TDatabase, TEnum> CreateSelectValueBuilder<TEnum>(AnyElement<TEnum> element)
            where TEnum : struct, Enum, IComparable
            => DoCreateSelectValueBuilder(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, TEnum?> CreateSelectValueBuilder<TEnum>(AnyElement<TEnum?> element)
            where TEnum : struct, Enum, IComparable
            => DoCreateSelectValueBuilder(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, object?> CreateSelectValueBuilder(ObjectElement element)
            => DoCreateSelectValueBuilder<object?>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, object?> CreateSelectValueBuilder(NullableObjectElement element)
            => DoCreateSelectValueBuilder<object?>(element);

        /// <inheritdoc />
        public SelectObject<TDatabase, T> CreateSelectValueBuilder<T>(ObjectElement<T> element)
            where T : class?
            => DoCreateSelectObjectBuilder<T>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, T> CreateSelectValueBuilder<T>(AliasedElement<T> element)
            => DoCreateSelectValueBuilder<T>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, bool> CreateSelectValueBuilder(AnyElement<bool> element)
            => DoCreateSelectValueBuilder<bool>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, bool?> CreateSelectValueBuilder(AnyElement<bool?> element)
            => DoCreateSelectValueBuilder<bool?>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, byte> CreateSelectValueBuilder(AnyElement<byte> element)
            => DoCreateSelectValueBuilder<byte>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, byte?> CreateSelectValueBuilder(AnyElement<byte?> element)
            => DoCreateSelectValueBuilder<byte?>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, byte[]> CreateSelectValueBuilder(ByteArrayElement element)
            => DoCreateSelectValueBuilder<byte[]>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, byte[]?> CreateSelectValueBuilder(NullableByteArrayElement element)
            => DoCreateSelectValueBuilder<byte[]?>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, DateTime> CreateSelectValueBuilder(AnyElement<DateTime> element)
            => DoCreateSelectValueBuilder<DateTime>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, DateTime?> CreateSelectValueBuilder(AnyElement<DateTime?> element)
            => DoCreateSelectValueBuilder<DateTime?>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, DateTimeOffset> CreateSelectValueBuilder(AnyElement<DateTimeOffset> element)
            => DoCreateSelectValueBuilder<DateTimeOffset>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, DateTimeOffset?> CreateSelectValueBuilder(AnyElement<DateTimeOffset?> element)
            => DoCreateSelectValueBuilder<DateTimeOffset?>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, decimal> CreateSelectValueBuilder(AnyElement<decimal> element)
            => DoCreateSelectValueBuilder<decimal>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, decimal?> CreateSelectValueBuilder(AnyElement<decimal?> element)
            => DoCreateSelectValueBuilder<decimal?>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, double> CreateSelectValueBuilder(AnyElement<double> element)
            => DoCreateSelectValueBuilder<double>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, double?> CreateSelectValueBuilder(AnyElement<double?> element)
            => DoCreateSelectValueBuilder<double?>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, Guid> CreateSelectValueBuilder(AnyElement<Guid> element)
            => DoCreateSelectValueBuilder<Guid>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, Guid?> CreateSelectValueBuilder(AnyElement<Guid?> element)
            => DoCreateSelectValueBuilder<Guid?>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, short> CreateSelectValueBuilder(AnyElement<short> element)
            => DoCreateSelectValueBuilder<short>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, short?> CreateSelectValueBuilder(AnyElement<short?> element)
            => DoCreateSelectValueBuilder<short?>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, int> CreateSelectValueBuilder(AnyElement<int> element)
            => DoCreateSelectValueBuilder<int>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, int?> CreateSelectValueBuilder(AnyElement<int?> element)
            => DoCreateSelectValueBuilder<int?>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, long> CreateSelectValueBuilder(AnyElement<long> element)
            => DoCreateSelectValueBuilder<long>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, long?> CreateSelectValueBuilder(AnyElement<long?> element)
            => DoCreateSelectValueBuilder<long?>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, float> CreateSelectValueBuilder(AnyElement<float> element)
            => DoCreateSelectValueBuilder<float>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, float?> CreateSelectValueBuilder(AnyElement<float?> element)
            => DoCreateSelectValueBuilder<float?>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, string> CreateSelectValueBuilder(StringElement element)
            => DoCreateSelectValueBuilder<string>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, string?> CreateSelectValueBuilder(NullableStringElement element)
            => DoCreateSelectValueBuilder<string?>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, TimeSpan> CreateSelectValueBuilder(AnyElement<TimeSpan> element)
            => DoCreateSelectValueBuilder<TimeSpan>(element);

        /// <inheritdoc />
        public SelectValue<TDatabase, TimeSpan?> CreateSelectValueBuilder(AnyElement<TimeSpan?> element)
            => DoCreateSelectValueBuilder<TimeSpan?>(element);


        private SelectValue<TDatabase, T> DoCreateSelectValueBuilder<T>(AnyElement<T> element)
        {
            return new SelectValueSelectQueryExpressionBuilder<TDatabase, T>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                element
            );
        }

        private SelectValue<TDatabase, TValue> DoCreateSelectValueBuilder<TValue>(AnyElement element)
        {
            return new SelectValueSelectQueryExpressionBuilder<TDatabase, TValue>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                element
            );
        }

        private SelectObject<TDatabase, TObject> DoCreateSelectObjectBuilder<TObject>(ObjectElement<TObject> element)
            where TObject : class?
        {
            return new SelectObjectSelectQueryExpressionBuilder<TDatabase, TObject>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                element
            );
        }

        SelectEntity<TDatabase, TEntity> DoCreateSelectEntityBuilder<TEntity>(Table<TEntity> table)
            where TEntity : class, IDbEntity, new()
        {
            return new SelectEntitySelectQueryExpressionBuilder<TDatabase, TEntity>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                table
            );
        }

        SelectDynamic<TDatabase> DoCreateSelectDynamicBuilder(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
        {
            return new SelectDynamicSelectQueryExpressionBuilder<TDatabase>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                elements.Concat(additionalElements)
            );
        }

        SelectDynamic<TDatabase> DoCreateSelectDynamicBuilder(IEnumerable<AnyElement> elements)
        {
            return new SelectDynamicSelectQueryExpressionBuilder<TDatabase>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                elements
            );
        }

        SelectDynamic<TDatabase> DoCreateSelectDynamicBuilder(AnyElement element1, AnyElement element2, params AnyElement[] elements)
        {
            var expressions = new List<AnyElement>(elements.Length + 2)
            {
                element1,
                element2
            }.Concat(elements);

            return new SelectDynamicSelectQueryExpressionBuilder<TDatabase>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                expressions
            );
        }
        #endregion
        #endregion
        #endregion
    }
}