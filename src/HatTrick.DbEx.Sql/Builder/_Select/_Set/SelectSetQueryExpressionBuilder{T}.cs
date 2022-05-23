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

using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectSetQueryExpressionBuilder<TDatabase> : QueryExpressionBuilder<TDatabase>,
        SelectOneInitiation<TDatabase>,
        SelectManyInitiation<TDatabase>,
        UnionSelectAnyInitiation<TDatabase>,
        UnionSelectAnyContinuation<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly SelectSetQueryExpression _expression;
        protected override QueryExpression Expression => SelectSetQueryExpression;
        protected SelectSetQueryExpression SelectSetQueryExpression => _expression;
        #endregion

        #region interface
        #region UnionSelectAnyInitiation<TDatabase
        public UnionSelectAnyContinuation<TDatabase> Union
        {
            get
            {
                SelectSetQueryExpression.Expressions.Last().ConcatenationExpression = new UnionExpression();
                return this;
            }
        }

        public UnionSelectAnyContinuation<TDatabase> UnionAll
        {
            get
            {
                SelectSetQueryExpression.Expressions.Last().ConcatenationExpression = new UnionAllExpression();
                return this;
            }
        }
        #endregion
        #endregion

        #region constructors
        public SelectSetQueryExpressionBuilder(SelectSetQueryExpression expression, SqlDatabaseRuntimeConfiguration config)
            : base(config)
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }
        #endregion

        #region methods
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
        SelectObject<TDatabase, T?> SelectOneInitiation<TDatabase>.SelectOne<T>(NullableObjectElement<T> element)
            where T : class
            => CreateSelectObjectBuilder<T>(element);

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
        SelectValue<TDatabase, string?> SelectOneInitiation<TDatabase>.SelectOne(SelectExpression<string?> element)
            => CreateSelectValueBuilder(element);

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
            => CreateSelectValuesBuilder(element);

        /// <inheritdoc />
        SelectValues<TDatabase, TEnum?> SelectManyInitiation<TDatabase>.SelectMany<TEnum>(AnyElement<TEnum?> element)
            => CreateSelectValuesBuilder(element);

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
        SelectObjects<TDatabase, T?> SelectManyInitiation<TDatabase>.SelectMany<T>(NullableObjectElement<T> element)
            where T : class
            => CreateSelectObjectsBuilder<T>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, bool> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<bool> element)
            => CreateSelectValuesBuilder<bool>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, bool?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<bool?> element)
            => CreateSelectValuesBuilder<bool?>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, byte> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<byte> element)
            => CreateSelectValuesBuilder<byte>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, byte?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<byte?> element)
            => CreateSelectValuesBuilder<byte?>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, byte[]> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<byte[]> element)
            => CreateSelectValuesBuilder<byte[]>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, DateTime> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<DateTime> element)
            => CreateSelectValuesBuilder<DateTime>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, DateTime?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<DateTime?> element)
            => CreateSelectValuesBuilder<DateTime?>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, DateTimeOffset> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<DateTimeOffset> element)
            => CreateSelectValuesBuilder<DateTimeOffset>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, DateTimeOffset?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<DateTimeOffset?> element)
            => CreateSelectValuesBuilder<DateTimeOffset?>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, decimal> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<decimal> element)
            => CreateSelectValuesBuilder<decimal>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, decimal?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<decimal?> element)
            => CreateSelectValuesBuilder<decimal?>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, double> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<double> element)
            => CreateSelectValuesBuilder<double>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, double?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<double?> element)
            => CreateSelectValuesBuilder<double?>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, Guid> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<Guid> element)
            => CreateSelectValuesBuilder<Guid>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, Guid?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<Guid?> element)
            => CreateSelectValuesBuilder<Guid?>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, short> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<short> element)
            => CreateSelectValuesBuilder<short>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, short?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<short?> element)
            => CreateSelectValuesBuilder<short?>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, int> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<int> element)
            => CreateSelectValuesBuilder<int>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, int?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<int?> element)
            => CreateSelectValuesBuilder<int?>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, long> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<long> element)
            => CreateSelectValuesBuilder<long>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, long?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<long?> element)
            => CreateSelectValuesBuilder<long?>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, float> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<float> element)
            => CreateSelectValuesBuilder<float>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, float?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<float?> element)
            => CreateSelectValuesBuilder<float?>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, string> SelectManyInitiation<TDatabase>.SelectMany(StringElement element)
            => CreateSelectValuesBuilder<string>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, string?> SelectManyInitiation<TDatabase>.SelectMany(NullableStringElement element)
            => CreateSelectValuesBuilder<string?>(element);

        /// <inheritdoc />
        SelectValues<TDatabase, string?> SelectManyInitiation<TDatabase>.SelectMany(SelectExpression<string?> element)
            => CreateSelectValuesBuilder<string?>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, TimeSpan> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<TimeSpan> element)
            => CreateSelectValuesBuilder<TimeSpan>((AnyElement)element);

        /// <inheritdoc />
        SelectValues<TDatabase, TimeSpan?> SelectManyInitiation<TDatabase>.SelectMany(AnyElement<TimeSpan?> element)
            => CreateSelectValuesBuilder<TimeSpan?>((AnyElement)element);

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

        #region UnionSelectAnyContinuation<TDatabase>
        /// <inheritdoc />
        SelectEntities<TDatabase, TEntity> UnionSelectAnyContinuation<TDatabase>.SelectOne<TEntity>()
            => CreateSelectEntitiesBuilder<TEntity>().Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, TEnum> UnionSelectAnyContinuation<TDatabase>.SelectOne<TEnum>(AnyElement<TEnum> element)
            => CreateSelectValuesBuilder(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, TEnum?> UnionSelectAnyContinuation<TDatabase>.SelectOne<TEnum>(AnyElement<TEnum?> element)
            => CreateSelectValuesBuilder(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, object> UnionSelectAnyContinuation<TDatabase>.SelectOne(ObjectElement element)
            => CreateSelectValuesBuilder<object>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, object?> UnionSelectAnyContinuation<TDatabase>.SelectOne(NullableObjectElement element)
            => CreateSelectValuesBuilder<object?>(element).Top(1);

        /// <inheritdoc />
        SelectObjects<TDatabase, T> UnionSelectAnyContinuation<TDatabase>.SelectOne<T>(ObjectElement<T> element)
            => CreateSelectObjectsBuilder<T>(element).Top(1);

        /// <inheritdoc />
        SelectObjects<TDatabase, T?> UnionSelectAnyContinuation<TDatabase>.SelectOne<T>(NullableObjectElement<T> element)
            where T : class
            => CreateSelectObjectsBuilder<T>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, bool> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<bool> element)
            => CreateSelectValuesBuilder<bool>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, bool?> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<bool?> element)
            => CreateSelectValuesBuilder<bool?>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, byte> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<byte> element)
            => CreateSelectValuesBuilder<byte>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, byte?> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<byte?> element)
            => CreateSelectValuesBuilder<byte?>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, byte[]> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<byte[]> element)
            => CreateSelectValuesBuilder<byte[]>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, DateTime> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<DateTime> element)
            => CreateSelectValuesBuilder<DateTime>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, DateTime?> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<DateTime?> element)
            => CreateSelectValuesBuilder<DateTime?>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, DateTimeOffset> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<DateTimeOffset> element)
            => CreateSelectValuesBuilder<DateTimeOffset>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, DateTimeOffset?> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<DateTimeOffset?> element)
            => CreateSelectValuesBuilder<DateTimeOffset?>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, decimal> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<decimal> element)
            => CreateSelectValuesBuilder<decimal>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, decimal?> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<decimal?> element)
            => CreateSelectValuesBuilder<decimal?>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, double> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<double> element)
            => CreateSelectValuesBuilder<double>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, double?> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<double?> element)
            => CreateSelectValuesBuilder<double?>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, Guid> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<Guid> element)
            => CreateSelectValuesBuilder<Guid>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, Guid?> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<Guid?> element)
            => CreateSelectValuesBuilder<Guid?>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, short> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<short> element)
            => CreateSelectValuesBuilder<short>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, short?> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<short?> element)
            => CreateSelectValuesBuilder<short?>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, int> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<int> element)
            => CreateSelectValuesBuilder<int>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, int?> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<int?> element)
            => CreateSelectValuesBuilder<int?>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, long> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<long> element)
            => CreateSelectValuesBuilder<long>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, long?> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<long?> element)
            => CreateSelectValuesBuilder<long?>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, float> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<float> element)
            => CreateSelectValuesBuilder<float>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, float?> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<float?> element)
            => CreateSelectValuesBuilder<float?>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, string> UnionSelectAnyContinuation<TDatabase>.SelectOne(StringElement element)
            => CreateSelectValuesBuilder<string>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, string?> UnionSelectAnyContinuation<TDatabase>.SelectOne(NullableStringElement element)
            => CreateSelectValuesBuilder<string?>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, string?> UnionSelectAnyContinuation<TDatabase>.SelectOne(SelectExpression<string?> element)
            => CreateSelectValuesBuilder<string?>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, TimeSpan> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<TimeSpan> element)
            => CreateSelectValuesBuilder<TimeSpan>(element).Top(1);

        /// <inheritdoc />
        SelectValues<TDatabase, TimeSpan?> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement<TimeSpan?> element)
            => CreateSelectValuesBuilder<TimeSpan?>(element).Top(1);

        /// <inheritdoc />
        SelectDynamics<TDatabase> UnionSelectAnyContinuation<TDatabase>.SelectOne(AnyElement element1, AnyElement element2, params AnyElement[] elements)
            => CreateSelectDynamicsBuilder(element1, element2, elements).Top(1);

        /// <inheritdoc />
        SelectDynamics<TDatabase> UnionSelectAnyContinuation<TDatabase>.SelectOne(IEnumerable<AnyElement> elements)
            => CreateSelectDynamicsBuilder(elements).Top(1);

        /// <inheritdoc />
        SelectDynamics<TDatabase> UnionSelectAnyContinuation<TDatabase>.SelectOne(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
            => CreateSelectDynamicsBuilder(elements, additionalElements).Top(1);
        #endregion

        #region create builders
        #region create select many builder
        private SelectValues<TDatabase, TValue> CreateSelectValuesBuilder<TValue>(AnyElement field)
        {
            SelectQueryExpression expression = new();
            expression.Select = new SelectExpressionSet(field?.ToSelectExpression(Configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(field)));

            var builder = new SelectValuesSelectQueryExpressionBuilder<TDatabase, TValue>(expression, Configuration, () => this, () => new SelectValuesSelectSetQueryExpressionBuilder<TDatabase, TValue>(SelectSetQueryExpression, Configuration));
            SelectSetQueryExpression.Expressions.Add(new SelectQueryConcatenationExpression(expression));
            return builder;
        }
        
        private SelectValues<TDatabase, T> CreateSelectValuesBuilder<T>(AnyElement<T> element)
        {
            SelectQueryExpression expression = new();
            expression.Select = new SelectExpressionSet(element?.ToSelectExpression(Configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(element)));

            var builder = new SelectValuesSelectQueryExpressionBuilder<TDatabase, T>(expression, Configuration, () => this, () => new SelectValuesSelectSetQueryExpressionBuilder<TDatabase, T>(SelectSetQueryExpression, Configuration));
            SelectSetQueryExpression.Expressions.Add(new SelectQueryConcatenationExpression(expression));
            return builder;
        }
        
        private SelectObjects<TDatabase, TObject> CreateSelectObjectsBuilder<TObject>(ObjectElement<TObject> element)
            where TObject : class
        {
            SelectQueryExpression expression = new();
            expression.Select = new SelectExpressionSet(element?.ToSelectExpression(Configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(element)));

            var builder = new SelectObjectsSelectQueryExpressionBuilder<TDatabase, TObject>(expression, Configuration, () => this, () => new SelectObjectsSelectSetQueryExpressionBuilder<TDatabase, TObject>(SelectSetQueryExpression, Configuration));
            SelectSetQueryExpression.Expressions.Add(new SelectQueryConcatenationExpression(expression));
            return builder;
        }

        private SelectObjects<TDatabase, TObject?> CreateSelectObjectsBuilder<TObject>(NullableObjectElement<TObject> element)
            where TObject : class?
        {
            SelectQueryExpression expression = new();
            expression.Select = new SelectExpressionSet(element?.ToSelectExpression(Configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(element)));

            var builder = new SelectObjectsSelectQueryExpressionBuilder<TDatabase, TObject?>(expression, Configuration, () => this, () => new SelectObjectsSelectSetQueryExpressionBuilder<TDatabase, TObject?>(SelectSetQueryExpression, Configuration));
            SelectSetQueryExpression.Expressions.Add(new SelectQueryConcatenationExpression(expression));
            return builder;
        }

        private SelectEntities<TDatabase, TEntity> CreateSelectEntitiesBuilder<TEntity>()
            where TEntity : class, IDbEntity, new()
        {
            SelectQueryExpression expression = new();

            var builder = new SelectEntitiesSelectQueryExpressionBuilder<TDatabase, TEntity>(expression, Configuration, () => this, () => new SelectEntitiesSelectSetQueryExpressionBuilder<TDatabase, TEntity>(SelectSetQueryExpression, Configuration));
            SelectSetQueryExpression.Expressions.Add(new SelectQueryConcatenationExpression(expression));
            return builder;
        }

        private SelectDynamics<TDatabase> CreateSelectDynamicsBuilder(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
        {
            SelectQueryExpression expression = new();
            expression.Select = new(elements.Concat(additionalElements).Select(element => element.ToSelectExpression(Configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(element))));

            var builder = new SelectDynamicsSelectQueryExpressionBuilder<TDatabase>(expression, Configuration, () => this, () => new SelectDynamicsSelectSetQueryExpressionBuilder<TDatabase>(SelectSetQueryExpression, Configuration));
            SelectSetQueryExpression.Expressions.Add(new SelectQueryConcatenationExpression(expression));
            return builder;
        }

        private SelectDynamics<TDatabase> CreateSelectDynamicsBuilder(IEnumerable<AnyElement> elements)
        {
            SelectQueryExpression expression = new();
            expression.Select = new(new List<SelectExpression>(elements.Select(element => element.ToSelectExpression(Configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(element)))));

            var builder = new SelectDynamicsSelectQueryExpressionBuilder<TDatabase>(expression, Configuration, () => this, () => new SelectDynamicsSelectSetQueryExpressionBuilder<TDatabase>(SelectSetQueryExpression, Configuration));
            SelectSetQueryExpression.Expressions.Add(new SelectQueryConcatenationExpression(expression));
            return builder;
        }

        private SelectDynamics<TDatabase> CreateSelectDynamicsBuilder(AnyElement element1, AnyElement element2, params AnyElement[] elements)
        {
            SelectQueryExpression expression = new();
            expression.Select = new(new List<SelectExpression>(elements.Length + 2)
            {
                element1?.ToSelectExpression(Configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(element1)),
                element2?.ToSelectExpression(Configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(element2))
            }.Concat(elements.Select(x => x.ToSelectExpression(Configuration.MetadataProvider))));

            var builder = new SelectDynamicsSelectQueryExpressionBuilder<TDatabase>(expression, Configuration, () => this, () => new SelectDynamicsSelectSetQueryExpressionBuilder<TDatabase>(SelectSetQueryExpression, Configuration));
            SelectSetQueryExpression.Expressions.Add(new SelectQueryConcatenationExpression(expression));
            return builder;
        }
        #endregion

        #region create select one builder
        private SelectValue<TDatabase, T> CreateSelectValueBuilder<T>(AnyElement<T> element)
        {
            SelectQueryExpression expression = new();
            expression.Top = 1;
            expression.Select = new SelectExpressionSet(element?.ToSelectExpression(Configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(element)));

            var builder = new SelectValueSelectQueryExpressionBuilder<TDatabase, T>(expression, Configuration, () => this, () => new SelectValueSelectSetQueryExpressionBuilder<TDatabase, T>(SelectSetQueryExpression, Configuration));
            SelectSetQueryExpression.Expressions.Add(new SelectQueryConcatenationExpression(expression));
            return builder;
        }

        private SelectValue<TDatabase, TValue> CreateSelectValueBuilder<TValue>(AnyElement element)
        {
            SelectQueryExpression expression = new();
            expression.Top = 1;
            expression.Select = new SelectExpressionSet(element?.ToSelectExpression(Configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(element)));

            var builder = new SelectValueSelectQueryExpressionBuilder<TDatabase, TValue>(expression, Configuration, () => this, () => new SelectValueSelectSetQueryExpressionBuilder<TDatabase, TValue>(SelectSetQueryExpression, Configuration));
            SelectSetQueryExpression.Expressions.Add(new SelectQueryConcatenationExpression(expression));
            return builder;
        }

        private SelectObject<TDatabase, TObject> CreateSelectObjectBuilder<TObject>(ObjectElement<TObject> element)
            where TObject : class
        {
            SelectQueryExpression expression = new();
            expression.Top = 1;
            expression.Select = new SelectExpressionSet(element?.ToSelectExpression(Configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(element)));

            var builder = new SelectObjectSelectQueryExpressionBuilder<TDatabase, TObject>(expression, Configuration, () => this, () => new SelectObjectSelectSetQueryExpressionBuilder<TDatabase, TObject>(SelectSetQueryExpression, Configuration));
            SelectSetQueryExpression.Expressions.Add(new SelectQueryConcatenationExpression(expression));
            return builder;
        }

        private SelectObject<TDatabase, TObject?> CreateSelectObjectBuilder<TObject>(NullableObjectElement<TObject> element)
            where TObject : class?
        {
            SelectQueryExpression expression = new();
            expression.Top = 1;
            expression.Select = new SelectExpressionSet(element?.ToSelectExpression(Configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(element)));

            var builder = new SelectObjectSelectQueryExpressionBuilder<TDatabase, TObject?>(expression, Configuration, () => this, () => new SelectObjectSelectSetQueryExpressionBuilder<TDatabase, TObject?>(SelectSetQueryExpression, Configuration));
            SelectSetQueryExpression.Expressions.Add(new SelectQueryConcatenationExpression(expression));
            return builder;
        }

        private SelectEntity<TDatabase, TEntity> CreateSelectEntityBuilder<TEntity>()
            where TEntity : class, IDbEntity, new()
        {
            SelectQueryExpression expression = new();
            expression.Top = 1;

            var builder = new SelectEntitySelectQueryExpressionBuilder<TDatabase, TEntity>(expression, Configuration, () => this, () => new SelectEntitySelectSetQueryExpressionBuilder<TDatabase, TEntity>(SelectSetQueryExpression, Configuration));
            SelectSetQueryExpression.Expressions.Add(new SelectQueryConcatenationExpression(expression));
            return builder;
        }

        private SelectDynamic<TDatabase> CreateSelectDynamicBuilder(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
        {
            SelectQueryExpression expression = new();
            expression.Top = 1;
            expression.Select = new SelectExpressionSet(elements.Concat(additionalElements).Select(element => element.ToSelectExpression(Configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(element))));

            var builder = new SelectDynamicSelectQueryExpressionBuilder<TDatabase>(expression, Configuration, () => this, () => new SelectDynamicSelectSetQueryExpressionBuilder<TDatabase>(SelectSetQueryExpression, Configuration));
            SelectSetQueryExpression.Expressions.Add(new SelectQueryConcatenationExpression(expression));
            return builder;
        }

        private SelectDynamic<TDatabase> CreateSelectDynamicBuilder(IEnumerable<AnyElement> elements)
        {
            SelectQueryExpression expression = new();
            expression.Top = 1;
            expression.Select = new SelectExpressionSet(elements.Select(element => element.ToSelectExpression(Configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(element))));

            var builder = new SelectDynamicSelectQueryExpressionBuilder<TDatabase>(expression, Configuration, () => this, () => new SelectDynamicSelectSetQueryExpressionBuilder<TDatabase>(SelectSetQueryExpression, Configuration));
            SelectSetQueryExpression.Expressions.Add(new SelectQueryConcatenationExpression(expression));
            return builder;
        }

        private SelectDynamic<TDatabase> CreateSelectDynamicBuilder(AnyElement element1, AnyElement element2, params AnyElement[] elements)
        {
            SelectQueryExpression expression = new();
            expression.Select = new(new List<SelectExpression>(elements.Length + 2)
            {
                element1?.ToSelectExpression(Configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(element1)),
                element2?.ToSelectExpression(Configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(element2))
            }.Concat(elements.Select(x => x.ToSelectExpression(Configuration.MetadataProvider))));
            expression.Top = 1;

            var builder = new SelectDynamicSelectQueryExpressionBuilder<TDatabase>(expression, Configuration, () => this, () => new SelectDynamicSelectSetQueryExpressionBuilder<TDatabase>(SelectSetQueryExpression, Configuration));
            SelectSetQueryExpression.Expressions.Add(new SelectQueryConcatenationExpression(expression));
            return builder;
        }
        #endregion
        #endregion

        #region create pipelines
        protected virtual ISelectQueryExpressionExecutionPipeline CreateExecuteSinglePipeline()
            => Configuration.ExecutionPipelineFactory?.CreateQueryExecutionPipeline(Configuration, SelectSetQueryExpression.Expressions.Single().SelectQueryExpression) ?? throw new DbExpressionConfigurationException($"Could not resolve/create an execution pipeline for type '{SelectSetQueryExpression.GetType()}',  please review and ensure the correct configuration for DbExpression.");

        protected virtual ISelectSetQueryExpressionExecutionPipeline CreateExecuteSetPipeline()
            => Configuration.ExecutionPipelineFactory?.CreateQueryExecutionPipeline(Configuration, SelectSetQueryExpression) ?? throw new DbExpressionConfigurationException($"Could not resolve/create an execution pipeline for type '{SelectSetQueryExpression.GetType()}',  please review and ensure the correct Configurationuration for DbExpression.");
        #endregion
        #endregion
    }
}
