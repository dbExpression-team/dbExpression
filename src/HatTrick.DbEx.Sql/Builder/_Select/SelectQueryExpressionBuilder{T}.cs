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

using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectQueryExpressionBuilder<TDatabase> : QueryExpressionBuilder<TDatabase>,
        SelectOneInitiation<TDatabase>,
        SelectManyInitiation<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private SelectQueryExpression _rootExpression;
        protected override QueryExpression Expression => _rootExpression;
        protected SelectQueryExpression Current { get; private set; }
        protected Func<SelectQueryExpression> QueryExpressionFactory { get; private set; }
        protected Func<ISelectQueryExpressionExecutionPipeline> ExecutionPipelineFactory { get; private set; }
        #endregion

        #region interface
        public SelectQueryExpression SelectQueryExpression => _rootExpression;
        #endregion

        #region constructors
        public SelectQueryExpressionBuilder(
            Func<SelectQueryExpression> queryExpressionFactory,
            Func<ISelectQueryExpressionExecutionPipeline> selectQueryExpressionExecutionPipelineFactory
        )
        {
            QueryExpressionFactory = queryExpressionFactory ?? throw new ArgumentNullException(nameof(queryExpressionFactory));
            ExecutionPipelineFactory = selectQueryExpressionExecutionPipelineFactory ?? throw new ArgumentNullException(nameof(selectQueryExpressionExecutionPipelineFactory));

            Current = _rootExpression = queryExpressionFactory.Invoke();
        }

        protected SelectQueryExpressionBuilder(
            Func<SelectQueryExpression> queryExpressionFactory,
            Func<ISelectQueryExpressionExecutionPipeline> executionPipelineFactory,
            SelectQueryExpression rootExpression,
            SelectQueryExpression currentExpression
        )
        {
            QueryExpressionFactory = queryExpressionFactory ?? throw new ArgumentNullException(nameof(queryExpressionFactory));
            ExecutionPipelineFactory = executionPipelineFactory ?? throw new ArgumentNullException(nameof(executionPipelineFactory));

            _rootExpression = rootExpression;
            Current = currentExpression;
        }
        #endregion

        #region methods
        protected virtual void ApplyFrom<T>(Table<T> entity)
            where T : class, IDbEntity
        {
            Current.From = new FromExpression(entity ?? throw new ArgumentNullException(nameof(entity)));
        }

        protected virtual void ApplyFrom(AnySelectSubquery query)
        {
            Current.From = new FromExpression((query as IQueryExpressionProvider)?.Expression ?? throw new ArgumentNullException(nameof(query)));
        }

        protected void ApplyTop(int value)
        {
            Current.Top = value;
        }

        protected void ApplyDistinct()
        {
            Current.Distinct = true;
        }

        protected void ApplyWhere(AnyWhereExpression? expression)
        {
            if (expression is null)
                return;

            if (expression is FilterExpression single)
            {
                if (Current.Where is null)
                    Current.Where = new(single);
                else
                    Current.Where &= single;
            }
            else if (expression is FilterExpressionSet set)
            {
                if (expression is IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements> provider && provider.Expression?.Args is not null && provider.Expression.Args.Any())
                {
                    if (Current.Where is null)
                        Current.Where = set;
                    else
                        Current.Where &= set;
                }
            }
        }

        protected void ApplyOrderBy(IEnumerable<AnyOrderByExpression>? orderBy)
        {
            if (orderBy is null || !orderBy.Any())
                return;

            Current.OrderBy &= new OrderByExpressionSet(orderBy);
        }

        protected void ApplyGroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            if (groupBy is null || !groupBy.Any())
                return;

            Current.GroupBy &= new GroupByExpressionSet(groupBy);
        }

        protected void ApplyHaving(AnyHavingExpression? having)
        {
            if (having is null)
                return;

            if (having is not FilterExpressionSet set)
                set = new(having);

            Current.Having &= new HavingExpression(set);
        }

        protected void ApplyCrossJoin(AnyEntity entity)
        {
            Current.Joins = Current.Joins is null ?
                new JoinExpressionSet(new JoinExpression(entity, JoinOperationExpressionOperator.CROSS, null))
                :
                new JoinExpressionSet(Current.Joins.Expressions.Concat(new JoinExpression[1] { new JoinExpression(entity, JoinOperationExpressionOperator.CROSS, null) }));
        }

        protected void ApplyOffset(int value)
            => Current.Offset = value;

        protected void ApplyLimit(int value)
            => Current.Limit = value;
        #endregion

        #region methods
        #region UnionSelectAnyInitiation<TDatabase>
        protected void ApplyUnion()
        {
            var exp = QueryExpressionFactory.Invoke();
            Current.ContinuationExpression = new QueryExpressionContinuationExpression(exp, new UnionExpression());
            Current = exp;
        }

        protected void ApplyUnionAll()
        {
            var exp = QueryExpressionFactory.Invoke();
            Current.ContinuationExpression = new QueryExpressionContinuationExpression(exp, new UnionAllExpression());
            Current = exp;
        }
        #endregion

        #region SelectOneInitiation<TDatabase>
        /// <inheritdoc/>
        SelectEntity<TDatabase, TEntity> SelectOneInitiation<TDatabase>.SelectOne<TEntity>()
            => CreateSelectEntityBuilder<TEntity>();

        /// <inheritdoc/>
        SelectValue<TDatabase, TEnum> SelectOneInitiation<TDatabase>.SelectOne<TEnum>(AnyElement<TEnum> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, TEnum?> SelectOneInitiation<TDatabase>.SelectOne<TEnum>(AnyElement<TEnum?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, object> SelectOneInitiation<TDatabase>.SelectOne(ObjectElement element)
            => CreateSelectValueBuilder<object>(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, object?> SelectOneInitiation<TDatabase>.SelectOne(NullableObjectElement element)
            => CreateSelectValueBuilder<object?>(element);

        /// <inheritdoc/>
        SelectObject<TDatabase, T> SelectOneInitiation<TDatabase>.SelectOne<T>(ObjectElement<T> element)
            => CreateSelectObjectBuilder<T>(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, T> SelectOneInitiation<TDatabase>.SelectOne<T>(AliasedElement<T> element)
            => CreateSelectValueBuilder<T>(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, bool> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<bool> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, bool?> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<bool?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, byte> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<byte> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, byte?> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<byte?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, byte[]> SelectOneInitiation<TDatabase>.SelectOne(ByteArrayElement element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, byte[]?> SelectOneInitiation<TDatabase>.SelectOne(NullableByteArrayElement element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, DateTime> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<DateTime> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, DateTime?> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<DateTime?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, DateTimeOffset> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<DateTimeOffset> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, DateTimeOffset?> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<DateTimeOffset?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, decimal> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<decimal> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, decimal?> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<decimal?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, double> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<double> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, double?> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<double?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, Guid> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<Guid> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, Guid?> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<Guid?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, short> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<short> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, short?> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<short?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, int> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<int> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, int?> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<int?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, long> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<long> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, long?> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<long?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, float> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<float> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, float?> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<float?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, string> SelectOneInitiation<TDatabase>.SelectOne(StringElement element)
            => CreateSelectValueBuilder<string>(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, string?> SelectOneInitiation<TDatabase>.SelectOne(NullableStringElement element)
            => CreateSelectValueBuilder<string?>(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, TimeSpan> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<TimeSpan> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TDatabase, TimeSpan?> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<TimeSpan?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectDynamic<TDatabase> SelectOneInitiation<TDatabase>.SelectOne(AnyElement element1, AnyElement element2, params AnyElement[] elements)
            => CreateSelectDynamicBuilder(element1, element2, elements);

        /// <inheritdoc/>
        SelectDynamic<TDatabase> SelectOneInitiation<TDatabase>.SelectOne(IEnumerable<AnyElement> elements)
            => CreateSelectDynamicBuilder(elements);

        /// <inheritdoc/>
        SelectDynamic<TDatabase> SelectOneInitiation<TDatabase>.SelectOne(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
            => CreateSelectDynamicBuilder(elements, additionalElements);
        #endregion

        #region SelectManyInitiation<TDatabase>
        /// <inheritdoc />
        SelectEntities<TDatabase, TEntity> SelectManyInitiation<TDatabase>.SelectMany<TEntity>()
            => CreateSelectEntitiesBuilder<TEntity>();

        /// <inheritdoc />
        SelectValues<TDatabase, TEnum> SelectManyInitiation<TDatabase>.SelectMany<TEnum>(AnyElement<TEnum> element)
            => CreateSelectValuesBuilder<TEnum>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, TEnum?> SelectManyInitiation<TDatabase>.SelectMany<TEnum>(AnyElement<TEnum?> element)
            => CreateSelectValuesBuilder<TEnum?>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, object> SelectManyInitiation<TDatabase>.SelectMany(ObjectElement element)
            => CreateSelectValuesBuilder<object>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, object?> SelectManyInitiation<TDatabase>.SelectMany(NullableObjectElement element)
            => CreateSelectValuesBuilder<object?>(element);

        /// <inheritdoc />
        SelectObjects<TDatabase, T> SelectManyInitiation<TDatabase>.SelectMany<T>(ObjectElement<T> element)
            => CreateSelectObjectsBuilder<T>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, T> SelectManyInitiation<TDatabase>.SelectMany<T>(AliasedElement<T> element)
            => CreateSelectValuesBuilder<T>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, bool> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<bool> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, bool?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<bool?> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, byte> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<byte> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, byte?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<byte?> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, byte[]> SelectManyInitiation<TDatabase>.SelectMany(ByteArrayElement element)
            => CreateSelectValuesBuilder<byte[]>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, byte[]?> SelectManyInitiation<TDatabase>.SelectMany(NullableByteArrayElement element)
            => CreateSelectValuesBuilder<byte[]?>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, DateTime> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<DateTime> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, DateTime?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<DateTime?> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, DateTimeOffset> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<DateTimeOffset> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, DateTimeOffset?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<DateTimeOffset?> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, decimal> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<decimal> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, decimal?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<decimal?> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, double> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<double> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, double?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<double?> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, Guid> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<Guid> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, Guid?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<Guid?> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, short> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<short> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, short?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<short?> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, int> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<int> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, int?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<int?> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, long> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<long> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, long?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<long?> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, float> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<float> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, float?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<float?> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, string> SelectManyInitiation<TDatabase>.SelectMany(StringElement element)
            => CreateSelectValuesBuilder<string>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, string?> SelectManyInitiation<TDatabase>.SelectMany(NullableStringElement element)
            => CreateSelectValuesBuilder<string?>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, TimeSpan> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<TimeSpan> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, TimeSpan?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<TimeSpan?> element)
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectDynamics<TDatabase> SelectManyInitiation<TDatabase>.SelectMany(AnyElement element1, AnyElement element2, params AnyElement[] elements)
            => CreateSelectDynamicsBuilder(element1, element2, elements);

        /// <inheritdoc />
        SelectDynamics<TDatabase> SelectManyInitiation<TDatabase>.SelectMany(IEnumerable<AnyElement> elements)
            => CreateSelectDynamicsBuilder(elements);

        /// <inheritdoc />
        SelectDynamics<TDatabase> SelectManyInitiation<TDatabase>.SelectMany(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
            => CreateSelectDynamicsBuilder(elements, additionalElements);
        #endregion

        #region create builders
        #region create select many builder
        protected virtual SelectValues<TDatabase, T> CreateSelectValuesBuilder<T>(AnyElement element)
        {
            Current.Select = new SelectExpressionSet(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            
            return new SelectValuesSelectQueryExpressionBuilder<TDatabase, T>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                SelectQueryExpression,
                Current
            );
        }

        protected virtual SelectValues<TDatabase, T> CreateSelectValuesBuilder<T>(AnyElement<T> element)
        {
            Current.Select = new SelectExpressionSet(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));

            return new SelectValuesSelectQueryExpressionBuilder<TDatabase, T>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                SelectQueryExpression,
                Current
            );
        }

        protected virtual SelectObjects<TDatabase, TObject> CreateSelectObjectsBuilder<TObject>(AnyElement field)
            where TObject : class?
        {
            Current.Select = new SelectExpressionSet(field?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(field)));

            return new SelectObjectsSelectQueryExpressionBuilder<TDatabase, TObject>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                SelectQueryExpression,
                Current
            );
        }

        protected virtual SelectDynamics<TDatabase> CreateSelectDynamicsBuilder(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
        {
            Current.Select = new(elements.Concat(additionalElements).Select(element => element.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element))));

            return new SelectDynamicsSelectQueryExpressionBuilder<TDatabase>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                SelectQueryExpression,
                Current
            );
        }

        protected virtual SelectDynamics<TDatabase> CreateSelectDynamicsBuilder(IEnumerable<AnyElement> elements)
        {
            Current.Select = new(new List<SelectExpression>(elements.Select(element => element.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)))));

            return new SelectDynamicsSelectQueryExpressionBuilder<TDatabase>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                SelectQueryExpression,
                Current
            );
        }

        protected virtual SelectDynamics<TDatabase> CreateSelectDynamicsBuilder(AnyElement element1, AnyElement element2, params AnyElement[] elements)
        {
            Current.Select = new(new List<SelectExpression>(elements.Length + 2)
            {
                element1?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element1)),
                element2?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element2))
            }.Concat(elements.Select(x => x.ToSelectExpression())));

            return new SelectDynamicsSelectQueryExpressionBuilder<TDatabase>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                SelectQueryExpression,
                Current
            );
        }

        protected virtual SelectEntities<TDatabase, TEntity> CreateSelectEntitiesBuilder<TEntity>()
            where TEntity : class, IDbEntity, new()
        {
            return new SelectEntitiesSelectQueryExpressionBuilder<TDatabase, TEntity>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                (Table<TEntity>)null!,
                SelectQueryExpression,
                Current
            );
        }
        #endregion

        #region create select one builder
        protected virtual SelectValue<TDatabase, T> CreateSelectValueBuilder<T>(AnyElement<T> element)
        {
            ApplyTop(1);
            Current.Select = new SelectExpressionSet(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));

            return new SelectValueSelectQueryExpressionBuilder<TDatabase, T>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                SelectQueryExpression,
                Current
            );
        }

        protected virtual SelectValue<TDatabase, TValue> CreateSelectValueBuilder<TValue>(AnyElement element)
        {
            ApplyTop(1);
            Current.Select = new SelectExpressionSet(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));

            return new SelectValueSelectQueryExpressionBuilder<TDatabase, TValue>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                SelectQueryExpression,
                Current
            );
        }

        protected virtual SelectObject<TDatabase, TObject> CreateSelectObjectBuilder<TObject>(ObjectElement<TObject> element)
            where TObject : class?
        {
            ApplyTop(1);
            Current.Select = new SelectExpressionSet(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));

            return new SelectObjectSelectQueryExpressionBuilder<TDatabase, TObject>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                SelectQueryExpression,
                Current
            );
        }

        protected virtual SelectEntity<TDatabase, TEntity> CreateSelectEntityBuilder<TEntity>()
            where TEntity : class, IDbEntity, new()
            => throw new NotImplementedException("Cannot create an entity builder using this implementation.");

        private SelectDynamic<TDatabase> CreateSelectDynamicBuilder(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
        {
            ApplyTop(1);
            Current.Select = new SelectExpressionSet(elements.Concat(additionalElements).Select(element => element.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element))));

            return new SelectDynamicSelectQueryExpressionBuilder<TDatabase>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                SelectQueryExpression,
                Current
            );
        }

        private SelectDynamic<TDatabase> CreateSelectDynamicBuilder(IEnumerable<AnyElement> elements)
        {
            ApplyTop(1);
            Current.Select = new SelectExpressionSet(elements.Select(element => element.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element))));

            return new SelectDynamicSelectQueryExpressionBuilder<TDatabase>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                SelectQueryExpression,
                Current
            );
        }

        private SelectDynamic<TDatabase> CreateSelectDynamicBuilder(AnyElement element1, AnyElement element2, params AnyElement[] elements)
        {
            ApplyTop(1);
            Current.Select = new(new List<SelectExpression>(elements.Length + 2)
            {
                element1?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element1)),
                element2?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element2))
            }.Concat(elements.Select(x => x.ToSelectExpression())));

            return new SelectDynamicSelectQueryExpressionBuilder<TDatabase>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                SelectQueryExpression,
                Current
            );
        }
        #endregion
        #endregion

        protected ISelectQueryExpressionExecutionPipeline CreateExecutionPipeline()
            => ExecutionPipelineFactory() 
                    ?? throw new DbExpressionConfigurationException(ExceptionMessages.ServiceResolution(SelectQueryExpression.GetType()));

        #endregion
    }
}
