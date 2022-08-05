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

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectSetQueryExpressionBuilder<TDatabase> : QueryExpressionBuilder<TDatabase>,
        SelectOneInitiation<TDatabase>,
        SelectManyInitiation<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly SelectSetQueryExpression _expression = new();
        private readonly Func<ISelectSetQueryExecutionPipeline<TDatabase>> selectSetQueryExpressionExecutionPipelineFactory;
        private readonly Func<SelectQueryExpression> typedQueryExpressionFactory;
        protected override QueryExpression Expression => 
            _expression.Expressions.Count > 1 && _expression.Expressions.ElementAt(0).ConcatenationExpression is not null 
                ? _expression : Current;

        protected Func<ISelectQueryExecutionPipeline<TDatabase>> SelectQueryExpressionExecutionPipelineFactory { get; private set; }
        #endregion

        #region interface
        public SelectSetQueryExpression SelectSetQueryExpression => _expression;

        public SelectQueryExpression Current => SelectSetQueryExpression.Expressions.Last().SelectQueryExpression;
        #endregion

        #region constructors
        public SelectSetQueryExpressionBuilder(
            ISqlDatabaseRuntime database,
            Func<SelectQueryExpression> typedQueryExpressionFactory,
            Func<ISelectSetQueryExecutionPipeline<TDatabase>> selectSetQueryExpressionExecutionPipelineFactory,
            Func<ISelectQueryExecutionPipeline<TDatabase>> selectQueryExpressionExecutionPipelineFactory
       ) : base(database)
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
        SelectValue<TDatabase, byte[]> SelectOneInitiation<TDatabase>.SelectOne(AnyElement<byte[]> element)
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
            => CreateSelectValuesBuilder<bool>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, bool?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<bool?> element)
            => CreateSelectValuesBuilder<bool?>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, byte> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<byte> element)
            => CreateSelectValuesBuilder<byte>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, byte?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<byte?> element)
            => CreateSelectValuesBuilder<byte?>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, byte[]> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<byte[]> element)
            => CreateSelectValuesBuilder<byte[]>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, DateTime> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<DateTime> element)
            => CreateSelectValuesBuilder<DateTime>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, DateTime?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<DateTime?> element)
            => CreateSelectValuesBuilder<DateTime?>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, DateTimeOffset> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<DateTimeOffset> element)
            => CreateSelectValuesBuilder<DateTimeOffset>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, DateTimeOffset?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<DateTimeOffset?> element)
            => CreateSelectValuesBuilder<DateTimeOffset?>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, decimal> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<decimal> element)
            => CreateSelectValuesBuilder<decimal>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, decimal?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<decimal?> element)
            => CreateSelectValuesBuilder<decimal?>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, double> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<double> element)
            => CreateSelectValuesBuilder<double>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, double?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<double?> element)
            => CreateSelectValuesBuilder<double?>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, Guid> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<Guid> element)
            => CreateSelectValuesBuilder<Guid>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, Guid?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<Guid?> element)
            => CreateSelectValuesBuilder<Guid?>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, short> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<short> element)
            => CreateSelectValuesBuilder<short>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, short?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<short?> element)
            => CreateSelectValuesBuilder<short?>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, int> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<int> element)
            => CreateSelectValuesBuilder<int>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, int?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<int?> element)
            => CreateSelectValuesBuilder<int?>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, long> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<long> element)
            => CreateSelectValuesBuilder<long>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, long?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<long?> element)
            => CreateSelectValuesBuilder<long?>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, float> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<float> element)
            => CreateSelectValuesBuilder<float>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, float?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<float?> element)
            => CreateSelectValuesBuilder<float?>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, string> SelectManyInitiation<TDatabase>.SelectMany(StringElement element)
            => CreateSelectValuesBuilder<string>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, string?> SelectManyInitiation<TDatabase>.SelectMany(NullableStringElement element)
            => CreateSelectValuesBuilder<string?>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, TimeSpan> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<TimeSpan> element)
            => CreateSelectValuesBuilder<TimeSpan>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, TimeSpan?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<TimeSpan?> element)
            => CreateSelectValuesBuilder<TimeSpan?>(element);

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
            StartNew().Select = new SelectExpressionSet(element?.ToSelectExpression(Database.MetadataProvider) ?? throw new ArgumentNullException(nameof(element)));
            
            return new SelectValuesSelectQueryExpressionBuilder<TDatabase, T>(
                Database,
                SelectQueryExpressionExecutionPipelineFactory,
                this
            );
        }

        protected virtual SelectObjects<TDatabase, TObject> CreateSelectObjectsBuilder<TObject>(AnyElement field)
            where TObject : class?
        {
            StartNew().Select = new SelectExpressionSet(field?.ToSelectExpression(Database.MetadataProvider) ?? throw new ArgumentNullException(nameof(field)));

            return new SelectObjectsSelectQueryExpressionBuilder<TDatabase, TObject>(
                Database,
                SelectQueryExpressionExecutionPipelineFactory,
                this
            );
        }

        protected virtual SelectDynamics<TDatabase> CreateSelectDynamicsBuilder(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
        {
            StartNew().Select = new(elements.Concat(additionalElements).Select(element => element.ToSelectExpression(Database.MetadataProvider) ?? throw new ArgumentNullException(nameof(element))));

            return new SelectDynamicsSelectQueryExpressionBuilder<TDatabase>(
                Database,
                SelectQueryExpressionExecutionPipelineFactory,
                this
            );
        }

        protected virtual SelectDynamics<TDatabase> CreateSelectDynamicsBuilder(IEnumerable<AnyElement> elements)
        {
            StartNew().Select = new(new List<SelectExpression>(elements.Select(element => element.ToSelectExpression(Database.MetadataProvider) ?? throw new ArgumentNullException(nameof(element)))));

            return new SelectDynamicsSelectQueryExpressionBuilder<TDatabase>(
                Database,
                SelectQueryExpressionExecutionPipelineFactory,
                this
            );
        }

        protected virtual SelectDynamics<TDatabase> CreateSelectDynamicsBuilder(AnyElement element1, AnyElement element2, params AnyElement[] elements)
        {
            StartNew().Select = new(new List<SelectExpression>(elements.Length + 2)
            {
                element1?.ToSelectExpression(Database.MetadataProvider) ?? throw new ArgumentNullException(nameof(element1)),
                element2?.ToSelectExpression(Database.MetadataProvider) ?? throw new ArgumentNullException(nameof(element2))
            }.Concat(elements.Select(x => x.ToSelectExpression(Database.MetadataProvider))));

            return new SelectDynamicsSelectQueryExpressionBuilder<TDatabase>(
                Database,
                SelectQueryExpressionExecutionPipelineFactory,
                this
            );
        }

        protected virtual SelectEntities<TDatabase, TEntity> CreateSelectEntitiesBuilder<TEntity>()
            where TEntity : class, IDbEntity, new()
            => throw new NotImplementedException("Cannot create an entity builder using this implementation.");
        #endregion

        #region create select one builder
        protected virtual SelectValue<TDatabase, T> CreateSelectValueBuilder<T>(AnyElement<T> element)
        {
            var exp = StartNew();
            exp.Top = 1;
            exp.Select = new SelectExpressionSet(element?.ToSelectExpression(Database.MetadataProvider) ?? throw new ArgumentNullException(nameof(element)));

            return new SelectValueSelectQueryExpressionBuilder<TDatabase, T>(
                Database,
                SelectQueryExpressionExecutionPipelineFactory,
                this
            );
        }

        protected virtual SelectValue<TDatabase, TValue> CreateSelectValueBuilder<TValue>(AnyElement element)
        {
            var exp = StartNew();
            exp.Top = 1;
            exp.Select = new SelectExpressionSet(element?.ToSelectExpression(Database.MetadataProvider) ?? throw new ArgumentNullException(nameof(element)));

            return new SelectValueSelectQueryExpressionBuilder<TDatabase, TValue>(
                Database,
                SelectQueryExpressionExecutionPipelineFactory,
                this
            );
        }

        protected virtual SelectObject<TDatabase, TObject> CreateSelectObjectBuilder<TObject>(ObjectElement<TObject> element)
            where TObject : class?
        {
            var exp = StartNew();
            exp.Top = 1;
            exp.Select = new SelectExpressionSet(element?.ToSelectExpression(Database.MetadataProvider) ?? throw new ArgumentNullException(nameof(element)));

            return new SelectObjectSelectQueryExpressionBuilder<TDatabase, TObject>(
                Database,
                SelectQueryExpressionExecutionPipelineFactory,
                this
            );
        }

        protected virtual SelectEntity<TDatabase, TEntity> CreateSelectEntityBuilder<TEntity>()
            where TEntity : class, IDbEntity, new()
            => throw new NotImplementedException("Cannot create an entity builder using this implementation.");

        private SelectDynamic<TDatabase> CreateSelectDynamicBuilder(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
        {
            var exp = StartNew();
            exp.Top = 1;
            exp.Select = new SelectExpressionSet(elements.Concat(additionalElements).Select(element => element.ToSelectExpression(Database.MetadataProvider) ?? throw new ArgumentNullException(nameof(element))));

            return new SelectDynamicSelectQueryExpressionBuilder<TDatabase>(
                Database,
                SelectQueryExpressionExecutionPipelineFactory,
                this
            );
        }

        private SelectDynamic<TDatabase> CreateSelectDynamicBuilder(IEnumerable<AnyElement> elements)
        {
            var exp = StartNew();
            exp.Top = 1;
            exp.Select = new SelectExpressionSet(elements.Select(element => element.ToSelectExpression(Database.MetadataProvider) ?? throw new ArgumentNullException(nameof(element))));

            return new SelectDynamicSelectQueryExpressionBuilder<TDatabase>(
                Database,
                SelectQueryExpressionExecutionPipelineFactory,
                this
            );
        }

        private SelectDynamic<TDatabase> CreateSelectDynamicBuilder(AnyElement element1, AnyElement element2, params AnyElement[] elements)
        {
            var exp = StartNew();
            exp.Top = 1;
            exp.Select = new(new List<SelectExpression>(elements.Length + 2)
            {
                element1?.ToSelectExpression(Database.MetadataProvider) ?? throw new ArgumentNullException(nameof(element1)),
                element2?.ToSelectExpression(Database.MetadataProvider) ?? throw new ArgumentNullException(nameof(element2))
            }.Concat(elements.Select(x => x.ToSelectExpression(Database.MetadataProvider))));

            return new SelectDynamicSelectQueryExpressionBuilder<TDatabase>(
                Database,
                SelectQueryExpressionExecutionPipelineFactory,
                this
            );
        }
        #endregion
        #endregion

        public ISelectSetQueryExecutionPipeline<TDatabase> CreateExecutionPipeline()
            => selectSetQueryExpressionExecutionPipelineFactory() 
                    ?? throw new DbExpressionConfigurationException($"Could not resolve/create an execution pipeline for type '{SelectSetQueryExpression.GetType()}'.");
        #endregion
    }
}
