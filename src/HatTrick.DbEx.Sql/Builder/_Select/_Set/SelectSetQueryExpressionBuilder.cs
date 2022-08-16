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

using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectSetQueryExpressionBuilder : QueryExpressionBuilder,
        SelectOneInitiation,
        SelectManyInitiation
    {
        #region internals
        private readonly SelectSetQueryExpression _expression = new();
        private readonly Func<ISelectSetQueryExecutionPipeline> selectSetQueryExpressionExecutionPipelineFactory;
        private readonly Func<SelectQueryExpression> typedQueryExpressionFactory;
        protected override QueryExpression Expression => 
            _expression.Expressions.Count > 1 && _expression.Expressions.ElementAt(0).ConcatenationExpression is not null 
                ? _expression : Current;

        protected Func<ISelectQueryExecutionPipeline> SelectQueryExpressionExecutionPipelineFactory { get; private set; }
        #endregion

        #region interface
        public SelectSetQueryExpression SelectSetQueryExpression => _expression;

        public SelectQueryExpression Current => SelectSetQueryExpression.Expressions.Last().SelectQueryExpression;
        #endregion

        #region constructors
        public SelectSetQueryExpressionBuilder(
            Func<SelectQueryExpression> typedQueryExpressionFactory,
            Func<ISelectSetQueryExecutionPipeline> selectSetQueryExpressionExecutionPipelineFactory,
            Func<ISelectQueryExecutionPipeline> selectQueryExpressionExecutionPipelineFactory
        )
        {
            this.typedQueryExpressionFactory = typedQueryExpressionFactory ?? throw new ArgumentNullException(nameof(typedQueryExpressionFactory));
            this.selectSetQueryExpressionExecutionPipelineFactory = selectSetQueryExpressionExecutionPipelineFactory ?? throw new ArgumentNullException(nameof(selectSetQueryExpressionExecutionPipelineFactory));
            this.SelectQueryExpressionExecutionPipelineFactory = selectQueryExpressionExecutionPipelineFactory ?? throw new ArgumentNullException(nameof(selectQueryExpressionExecutionPipelineFactory));
        }
        #endregion

        #region methods
        public SelectQueryExpression StartNew()
        {
            var exp = typedQueryExpressionFactory();
            SelectSetQueryExpression.Expressions.Add(new(exp));
            return exp;
        }

        #region UnionSelectAnyInitiation<TDatabase
        public void ApplyUnion()
        {
            SelectSetQueryExpression.Expressions.Last().ConcatenationExpression = new UnionExpression();
        }

        public void ApplyUnionAll()
        {
            SelectSetQueryExpression.Expressions.Last().ConcatenationExpression = new UnionAllExpression();
        }
        #endregion

        #region SelectOneInitiation
        /// <inheritdoc/>
        SelectEntity<TEntity> SelectOneInitiation.SelectOne<TEntity>()
            => CreateSelectEntityBuilder<TEntity>();

        /// <inheritdoc/>
        SelectValue<TEnum> SelectOneInitiation.SelectOne<TEnum>(AnyElement<TEnum> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TEnum?> SelectOneInitiation.SelectOne<TEnum>(AnyElement<TEnum?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<object> SelectOneInitiation.SelectOne(ObjectElement element)
            => CreateSelectValueBuilder<object>(element);

        /// <inheritdoc/>
        SelectValue<object?> SelectOneInitiation.SelectOne(NullableObjectElement element)
            => CreateSelectValueBuilder<object?>(element);

        /// <inheritdoc/>
        SelectObject<T> SelectOneInitiation.SelectOne<T>(ObjectElement<T> element)
            => CreateSelectObjectBuilder<T>(element);

        /// <inheritdoc/>
        SelectValue<T> SelectOneInitiation.SelectOne<T>(AliasedElement<T> element)
            => CreateSelectValueBuilder<T>(element);

        /// <inheritdoc/>
        SelectValue<bool> SelectOneInitiation.SelectOne(AnyElement<bool> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<bool?> SelectOneInitiation.SelectOne(AnyElement<bool?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<byte> SelectOneInitiation.SelectOne(AnyElement<byte> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<byte?> SelectOneInitiation.SelectOne(AnyElement<byte?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<byte[]> SelectOneInitiation.SelectOne(AnyElement<byte[]> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<DateTime> SelectOneInitiation.SelectOne(AnyElement<DateTime> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<DateTime?> SelectOneInitiation.SelectOne(AnyElement<DateTime?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<DateTimeOffset> SelectOneInitiation.SelectOne(AnyElement<DateTimeOffset> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<DateTimeOffset?> SelectOneInitiation.SelectOne(AnyElement<DateTimeOffset?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<decimal> SelectOneInitiation.SelectOne(AnyElement<decimal> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<decimal?> SelectOneInitiation.SelectOne(AnyElement<decimal?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<double> SelectOneInitiation.SelectOne(AnyElement<double> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<double?> SelectOneInitiation.SelectOne(AnyElement<double?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<Guid> SelectOneInitiation.SelectOne(AnyElement<Guid> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<Guid?> SelectOneInitiation.SelectOne(AnyElement<Guid?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<short> SelectOneInitiation.SelectOne(AnyElement<short> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<short?> SelectOneInitiation.SelectOne(AnyElement<short?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<int> SelectOneInitiation.SelectOne(AnyElement<int> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<int?> SelectOneInitiation.SelectOne(AnyElement<int?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<long> SelectOneInitiation.SelectOne(AnyElement<long> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<long?> SelectOneInitiation.SelectOne(AnyElement<long?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<float> SelectOneInitiation.SelectOne(AnyElement<float> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<float?> SelectOneInitiation.SelectOne(AnyElement<float?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<string> SelectOneInitiation.SelectOne(StringElement element)
            => CreateSelectValueBuilder<string>(element);

        /// <inheritdoc/>
        SelectValue<string?> SelectOneInitiation.SelectOne(NullableStringElement element)
            => CreateSelectValueBuilder<string?>(element);

        /// <inheritdoc/>
        SelectValue<TimeSpan> SelectOneInitiation.SelectOne(AnyElement<TimeSpan> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectValue<TimeSpan?> SelectOneInitiation.SelectOne(AnyElement<TimeSpan?> element)
            => CreateSelectValueBuilder(element);

        /// <inheritdoc/>
        SelectDynamic SelectOneInitiation.SelectOne(AnyElement element1, AnyElement element2, params AnyElement[] elements)
            => CreateSelectDynamicBuilder(element1, element2, elements);

        /// <inheritdoc/>
        SelectDynamic SelectOneInitiation.SelectOne(IEnumerable<AnyElement> elements)
            => CreateSelectDynamicBuilder(elements);

        /// <inheritdoc/>
        SelectDynamic SelectOneInitiation.SelectOne(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
            => CreateSelectDynamicBuilder(elements, additionalElements);
        #endregion

        #region SelectManyInitiation
        /// <inheritdoc />
        SelectEntities<TEntity> SelectManyInitiation.SelectMany<TEntity>()
            => CreateSelectEntitiesBuilder<TEntity>();

        /// <inheritdoc />
        SelectValues<TEnum> SelectManyInitiation.SelectMany<TEnum>(AnyElement<TEnum> element)
            => CreateSelectValuesBuilder<TEnum>(element);

        /// <inheritdoc />
        SelectValues<TEnum?> SelectManyInitiation.SelectMany<TEnum>(AnyElement<TEnum?> element)
            => CreateSelectValuesBuilder<TEnum?>(element);

        /// <inheritdoc />
        SelectValues<object> SelectManyInitiation.SelectMany(ObjectElement element)
            => CreateSelectValuesBuilder<object>(element);

        /// <inheritdoc />
        SelectValues<object?> SelectManyInitiation.SelectMany(NullableObjectElement element)
            => CreateSelectValuesBuilder<object?>(element);

        /// <inheritdoc />
        SelectObjects<T> SelectManyInitiation.SelectMany<T>(ObjectElement<T> element)
            => CreateSelectObjectsBuilder<T>(element);

        /// <inheritdoc />
        SelectValues<T> SelectManyInitiation.SelectMany<T>(AliasedElement<T> element)
            => CreateSelectValuesBuilder<T>(element);

        /// <inheritdoc />
        SelectValues<bool> SelectManyInitiation.SelectMany(AnyElement<bool> element)
            => CreateSelectValuesBuilder<bool>(element);

        /// <inheritdoc />
        SelectValues<bool?> SelectManyInitiation.SelectMany(AnyElement<bool?> element)
            => CreateSelectValuesBuilder<bool?>(element);

        /// <inheritdoc />
        SelectValues<byte> SelectManyInitiation.SelectMany(AnyElement<byte> element)
            => CreateSelectValuesBuilder<byte>(element);

        /// <inheritdoc />
        SelectValues<byte?> SelectManyInitiation.SelectMany(AnyElement<byte?> element)
            => CreateSelectValuesBuilder<byte?>(element);

        /// <inheritdoc />
        SelectValues<byte[]> SelectManyInitiation.SelectMany(AnyElement<byte[]> element)
            => CreateSelectValuesBuilder<byte[]>(element);

        /// <inheritdoc />
        SelectValues<DateTime> SelectManyInitiation.SelectMany(AnyElement<DateTime> element)
            => CreateSelectValuesBuilder<DateTime>(element);

        /// <inheritdoc />
        SelectValues<DateTime?> SelectManyInitiation.SelectMany(AnyElement<DateTime?> element)
            => CreateSelectValuesBuilder<DateTime?>(element);

        /// <inheritdoc />
        SelectValues<DateTimeOffset> SelectManyInitiation.SelectMany(AnyElement<DateTimeOffset> element)
            => CreateSelectValuesBuilder<DateTimeOffset>(element);

        /// <inheritdoc />
        SelectValues<DateTimeOffset?> SelectManyInitiation.SelectMany(AnyElement<DateTimeOffset?> element)
            => CreateSelectValuesBuilder<DateTimeOffset?>(element);

        /// <inheritdoc />
        SelectValues<decimal> SelectManyInitiation.SelectMany(AnyElement<decimal> element)
            => CreateSelectValuesBuilder<decimal>(element);

        /// <inheritdoc />
        SelectValues<decimal?> SelectManyInitiation.SelectMany(AnyElement<decimal?> element)
            => CreateSelectValuesBuilder<decimal?>(element);

        /// <inheritdoc />
        SelectValues<double> SelectManyInitiation.SelectMany(AnyElement<double> element)
            => CreateSelectValuesBuilder<double>(element);

        /// <inheritdoc />
        SelectValues<double?> SelectManyInitiation.SelectMany(AnyElement<double?> element)
            => CreateSelectValuesBuilder<double?>(element);

        /// <inheritdoc />
        SelectValues<Guid> SelectManyInitiation.SelectMany(AnyElement<Guid> element)
            => CreateSelectValuesBuilder<Guid>(element);

        /// <inheritdoc />
        SelectValues<Guid?> SelectManyInitiation.SelectMany(AnyElement<Guid?> element)
            => CreateSelectValuesBuilder<Guid?>(element);

        /// <inheritdoc />
        SelectValues<short> SelectManyInitiation.SelectMany(AnyElement<short> element)
            => CreateSelectValuesBuilder<short>(element);

        /// <inheritdoc />
        SelectValues<short?> SelectManyInitiation.SelectMany(AnyElement<short?> element)
            => CreateSelectValuesBuilder<short?>(element);

        /// <inheritdoc />
        SelectValues<int> SelectManyInitiation.SelectMany(AnyElement<int> element)
            => CreateSelectValuesBuilder<int>(element);

        /// <inheritdoc />
        SelectValues<int?> SelectManyInitiation.SelectMany(AnyElement<int?> element)
            => CreateSelectValuesBuilder<int?>(element);

        /// <inheritdoc />
        SelectValues<long> SelectManyInitiation.SelectMany(AnyElement<long> element)
            => CreateSelectValuesBuilder<long>(element);

        /// <inheritdoc />
        SelectValues<long?> SelectManyInitiation.SelectMany(AnyElement<long?> element)
            => CreateSelectValuesBuilder<long?>(element);

        /// <inheritdoc />
        SelectValues<float> SelectManyInitiation.SelectMany(AnyElement<float> element)
            => CreateSelectValuesBuilder<float>(element);

        /// <inheritdoc />
        SelectValues<float?> SelectManyInitiation.SelectMany(AnyElement<float?> element)
            => CreateSelectValuesBuilder<float?>(element);

        /// <inheritdoc />
        SelectValues<string> SelectManyInitiation.SelectMany(StringElement element)
            => CreateSelectValuesBuilder<string>(element);

        /// <inheritdoc />
        SelectValues<string?> SelectManyInitiation.SelectMany(NullableStringElement element)
            => CreateSelectValuesBuilder<string?>(element);

        /// <inheritdoc />
        SelectValues<TimeSpan> SelectManyInitiation.SelectMany(AnyElement<TimeSpan> element)
            => CreateSelectValuesBuilder<TimeSpan>(element);

        /// <inheritdoc />
        SelectValues<TimeSpan?> SelectManyInitiation.SelectMany(AnyElement<TimeSpan?> element)
            => CreateSelectValuesBuilder<TimeSpan?>(element);

        /// <inheritdoc />
        SelectDynamics SelectManyInitiation.SelectMany(AnyElement element1, AnyElement element2, params AnyElement[] elements)
            => CreateSelectDynamicsBuilder(element1, element2, elements);

        /// <inheritdoc />
        SelectDynamics SelectManyInitiation.SelectMany(IEnumerable<AnyElement> elements)
            => CreateSelectDynamicsBuilder(elements);

        /// <inheritdoc />
        SelectDynamics SelectManyInitiation.SelectMany(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
            => CreateSelectDynamicsBuilder(elements, additionalElements);
        #endregion

        #region create builders
        #region create select many builder
        protected virtual SelectValues<T> CreateSelectValuesBuilder<T>(AnyElement element)
        {
            StartNew().Select = new SelectExpressionSet(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            
            return new SelectValuesSelectQueryExpressionBuilder<T>(
                SelectQueryExpressionExecutionPipelineFactory,
                this
            );
        }

        protected virtual SelectObjects<TObject> CreateSelectObjectsBuilder<TObject>(AnyElement field)
            where TObject : class?
        {
            StartNew().Select = new SelectExpressionSet(field?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(field)));

            return new SelectObjectsSelectQueryExpressionBuilder<TObject>(
                SelectQueryExpressionExecutionPipelineFactory,
                this
            );
        }

        protected virtual SelectDynamics CreateSelectDynamicsBuilder(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
        {
            StartNew().Select = new(elements.Concat(additionalElements).Select(element => element.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element))));

            return new SelectDynamicsSelectQueryExpressionBuilder(
                SelectQueryExpressionExecutionPipelineFactory,
                this
            );
        }

        protected virtual SelectDynamics CreateSelectDynamicsBuilder(IEnumerable<AnyElement> elements)
        {
            StartNew().Select = new(new List<SelectExpression>(elements.Select(element => element.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)))));

            return new SelectDynamicsSelectQueryExpressionBuilder(
                SelectQueryExpressionExecutionPipelineFactory,
                this
            );
        }

        protected virtual SelectDynamics CreateSelectDynamicsBuilder(AnyElement element1, AnyElement element2, params AnyElement[] elements)
        {
            StartNew().Select = new(new List<SelectExpression>(elements.Length + 2)
            {
                element1?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element1)),
                element2?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element2))
            }.Concat(elements.Select(x => x.ToSelectExpression())));

            return new SelectDynamicsSelectQueryExpressionBuilder(
                SelectQueryExpressionExecutionPipelineFactory,
                this
            );
        }

        protected virtual SelectEntities<TEntity> CreateSelectEntitiesBuilder<TEntity>()
            where TEntity : class, IDbEntity, new()
            => throw new NotImplementedException("Cannot create an entity builder using this implementation.");
        #endregion

        #region create select one builder
        protected virtual SelectValue<T> CreateSelectValueBuilder<T>(AnyElement<T> element)
        {
            var exp = StartNew();
            exp.Top = 1;
            exp.Select = new SelectExpressionSet(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));

            return new SelectValueSelectQueryExpressionBuilder<T>(
                SelectQueryExpressionExecutionPipelineFactory,
                this
            );
        }

        protected virtual SelectValue<TValue> CreateSelectValueBuilder<TValue>(AnyElement element)
        {
            var exp = StartNew();
            exp.Top = 1;
            exp.Select = new SelectExpressionSet(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));

            return new SelectValueSelectQueryExpressionBuilder<TValue>(
                SelectQueryExpressionExecutionPipelineFactory,
                this
            );
        }

        protected virtual SelectObject<TObject> CreateSelectObjectBuilder<TObject>(ObjectElement<TObject> element)
            where TObject : class?
        {
            var exp = StartNew();
            exp.Top = 1;
            exp.Select = new SelectExpressionSet(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));

            return new SelectObjectSelectQueryExpressionBuilder<TObject>(
                SelectQueryExpressionExecutionPipelineFactory,
                this
            );
        }

        protected virtual SelectEntity<TEntity> CreateSelectEntityBuilder<TEntity>()
            where TEntity : class, IDbEntity, new()
            => throw new NotImplementedException("Cannot create an entity builder using this implementation.");

        private SelectDynamic CreateSelectDynamicBuilder(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
        {
            var exp = StartNew();
            exp.Top = 1;
            exp.Select = new SelectExpressionSet(elements.Concat(additionalElements).Select(element => element.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element))));

            return new SelectDynamicSelectQueryExpressionBuilder(
                SelectQueryExpressionExecutionPipelineFactory,
                this
            );
        }

        private SelectDynamic CreateSelectDynamicBuilder(IEnumerable<AnyElement> elements)
        {
            var exp = StartNew();
            exp.Top = 1;
            exp.Select = new SelectExpressionSet(elements.Select(element => element.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element))));

            return new SelectDynamicSelectQueryExpressionBuilder(
                SelectQueryExpressionExecutionPipelineFactory,
                this
            );
        }

        private SelectDynamic CreateSelectDynamicBuilder(AnyElement element1, AnyElement element2, params AnyElement[] elements)
        {
            var exp = StartNew();
            exp.Top = 1;
            exp.Select = new(new List<SelectExpression>(elements.Length + 2)
            {
                element1?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element1)),
                element2?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element2))
            }.Concat(elements.Select(x => x.ToSelectExpression())));

            return new SelectDynamicSelectQueryExpressionBuilder(
                SelectQueryExpressionExecutionPipelineFactory,
                this
            );
        }
        #endregion
        #endregion

        public ISelectSetQueryExecutionPipeline CreateExecutionPipeline()
            => selectSetQueryExpressionExecutionPipelineFactory() 
                    ?? throw new DbExpressionConfigurationException($"Could not resolve/create an execution pipeline for type '{SelectSetQueryExpression.GetType()}'.");
        #endregion
    }
}
