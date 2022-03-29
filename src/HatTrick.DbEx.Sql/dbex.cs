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

﻿using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public static class dbex
    {
        /// <summary>
        /// Create an alias of a table and field for use with SELECT statements or in composition with other functions where the data type of the aliased expression is required.
        /// </summary>
        /// <returns><see cref="AliasExpression{T}"/> for use with any operation accepting a <see cref="AnyElement{T}"/>.</returns>
        /// <typeparam name="T">The type applied to the return of the alias.</typeparam>
        /// <remarks>Use this form when creating aliases where the return type is required.</remarks>
        public static AliasExpression<T> Alias<T>(string tableName, string fieldName)
            => new((tableName, fieldName));

        /// <summary>
        /// Create an alias of a table and field for use with other expressions where the data type of the aliased field is not required.  Typically, these are expressions like order by clauses and group by clauses (although you can use the generic form as well).
        /// </summary>
        /// <returns><see cref="AliasExpression"/> for use with any operation accepting a <see cref="AnyObjectElement"/>.</returns>
        /// <remarks>This version is required when creating aliases of any element that equates to a <see cref="String"/> type (<see cref="AnyStringElement"/> element).</remarks>
        public static AliasExpression<object> Alias(string tableName, string fieldName)
            => new((tableName, fieldName));

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableBooleanElement Coerce(AnyElement<bool> element)
            => new NullableBooleanExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a non-nullable.
        /// </summary>
        public static BooleanElement Coerce(AnyElement<bool?> element)
            => new BooleanExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableByteElement Coerce(AnyElement<byte> element)
            => new NullableByteExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a non-nullable.
        /// </summary>
        public static ByteElement Coerce(AnyElement<byte?> element)
            => new ByteExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableByteArrayElement Coerce(AnyElement<byte[]> element)
            => new NullableByteArrayExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableDateTimeElement Coerce(AnyElement<DateTime> element)
            => new NullableDateTimeExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a non-nullable.
        /// </summary>
        public static DateTimeElement Coerce(AnyElement<DateTime?> element)
            => new DateTimeExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableDateTimeOffsetElement Coerce(AnyElement<DateTimeOffset> element)
            => new NullableDateTimeOffsetExpressionMediator(element);

        // <summary>
        /// Change the encapsulated type of an element to a non-nullable.
        /// </summary>
        public static DateTimeOffsetElement Coerce(AnyElement<DateTimeOffset?> element)
            => new DateTimeOffsetExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableDecimalElement Coerce(AnyElement<decimal> element)
            => new NullableDecimalExpressionMediator(element);

        // <summary>
        /// Change the encapsulated type of an element to a non-nullable.
        /// </summary>
        public static DecimalElement Coerce(AnyElement<decimal?> element)
            => new DecimalExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableDoubleElement Coerce(AnyElement<double> element)
            => new NullableDoubleExpressionMediator(element);

        // <summary>
        /// Change the encapsulated type of an element to a non-nullable.
        /// </summary>
        public static DoubleElement Coerce(AnyElement<double?> element)
            => new DoubleExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableEnumElement<TEnum> Coerce<TEnum>(EnumElement<TEnum> element)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumExpressionMediator<TEnum>(element);

        /// <summary>
        /// Change the encapsulated type of an element to a non-nullable.
        /// </summary>
        public static EnumElement<TEnum> Coerce<TEnum>(NullableEnumElement<TEnum> element)
            where TEnum : struct, Enum, IComparable
            => new EnumExpressionMediator<TEnum>(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableGuidElement Coerce(AnyElement<Guid> element)
            => new NullableGuidExpressionMediator(element);

        // <summary>
        /// Change the encapsulated type of an element to a non-nullable.
        /// </summary>
        public static GuidElement Coerce(AnyElement<Guid?> element)
            => new GuidExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableInt16Element Coerce(AnyElement<short> element)
            => new NullableInt16ExpressionMediator(element);

        // <summary>
        /// Change the encapsulated type of an element to a non-nullable.
        /// </summary>
        public static Int16Element Coerce(AnyElement<short?> element)
            => new Int16ExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableInt32Element Coerce(AnyElement<int> element)
            => new NullableInt32ExpressionMediator(element);

        // <summary>
        /// Change the encapsulated type of an element to a non-nullable.
        /// </summary>
        public static Int32Element Coerce(AnyElement<int?> element)
            => new Int32ExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableInt64Element Coerce(AnyElement<long> element)
            => new NullableInt64ExpressionMediator(element);

        // <summary>
        /// Change the encapsulated type of an element to a non-nullable.
        /// </summary>
        public static Int64Element Coerce(AnyElement<long?> element)
            => new Int64ExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableSingleElement Coerce(AnyElement<float> element)
            => new NullableSingleExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableStringElement Coerce(StringElement element)
            => new NullableStringExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a non-nullable.
        /// </summary>
        public static StringElement Coerce(NullableStringElement element)
            => new StringExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableTimeSpanElement Coerce(AnyElement<TimeSpan> element)
            => new NullableTimeSpanExpressionMediator(element);

        // <summary>
        /// Change the encapsulated type of an element to a non-nullable.
        /// </summary>
        public static TimeSpanElement Coerce(AnyElement<TimeSpan?> element)
            => new TimeSpanExpressionMediator(element);

        /// <summary>
        /// Start constructing a list of <see cref="EntityFieldAssignment"/> containing update assignments for an <typeparamref name="TEntity"/> based on the differences between two <typeparamref name="TEntity"/> entities.  
        /// The completion of this fluent builder is useful for building an UPDATE query expression for updating an <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <returns><see cref="EntityFieldAssignmentsContinuation{TEntity}"/>, a fluent continuation for the construction of a list of <see cref="EntityFieldAssignment"/>s.</returns>
        public static EntityFieldAssignmentsContinuation<TEntity> BuildAssignmentsFor<TEntity>(Table<TEntity> entity)
            where TEntity : class, IDbEntity
            => new EntityComparisonAssignmentBuilder<TEntity>(entity);

        /// <summary>
        /// Get a list of all the columns for an <typeparamref name="TEntity"/> entity for use with a select query expression (effectively a "SELECT *").
        /// </summary>
        /// <returns>A <see cref="SelectExpressionSet"/> containing a list of <see cref="SelectExpression"/>s representing all columns for a table.</returns>
        /// <remarks>The list will not include any fields/columns that were marked to ignore as part of configuration.</remarks>
        public static IEnumerable<AnyElement> SelectAllFor<TEntity>(Table<TEntity> entity)
            where TEntity : class, IDbEntity
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            return entity.BuildInclusiveSelectExpression().Expressions.Cast<AnyElement>();
        }

        /// <summary>
        /// Get a list of all the columns for an <typeparamref name="TEntity"/> entity for use with a select query expression (effectively a "SELECT *").
        /// </summary>
        /// <returns>A <see cref="SelectExpressionSet"/> containing a list of <see cref="SelectExpression"/>s representing all columns for a table.</returns>
        /// <remarks>The list will not include any fields/columns that were marked to ignore as part of configuration.</remarks>
        public static IEnumerable<AnyElement> SelectAllFor<TEntity>(Table<TEntity> entity, string aliasPrefix)
            where TEntity : class, IDbEntity
        {
            return SelectAllFor(entity, name => $"{aliasPrefix}{name}");
        }

        /// <summary>
        /// Get a list of all the columns for an <typeparamref name="TEntity"/> entity for use with a select query expression (effectively a "SELECT *").
        /// </summary>
        /// <returns>A <see cref="SelectExpressionSet"/> containing a list of <see cref="SelectExpression"/>s representing all columns for a table.</returns>
        /// <remarks>The list will not include any fields/columns that were marked to ignore as part of configuration.</remarks>
        public static IEnumerable<AnyElement> SelectAllFor<TEntity>(Table<TEntity> entity, Func<string,string> alias)
            where TEntity : class, IDbEntity
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (alias is null)
                throw new ArgumentNullException(nameof(alias));

            return entity.BuildInclusiveSelectExpression(alias).Expressions.Cast<AnyElement>();
        }

        /// <summary>
        /// Get the default mapping delegate to map values from a field reader to a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <returns>A <see cref="SelectExpressionSet"/> containing a list of <see cref="SelectExpression"/>s representing all columns for a table.</returns>
        /// <remarks>The list will not include any fields/columns that were marked to ignore as part of configuration.</remarks>
        public static Action<ISqlFieldReader, TEntity> GetDefaultMappingFor<TEntity>(Table<TEntity> entity)
            where TEntity : class, IDbEntity
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            return entity.HydrateEntity;
        }
    }
#pragma warning restore IDE1006 // Naming Styles
}
