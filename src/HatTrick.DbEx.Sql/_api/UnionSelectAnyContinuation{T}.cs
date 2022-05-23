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
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface UnionSelectAnyContinuation<TDatabase> :
#pragma warning restore IDE1006 // Naming Styles
        SelectManyInitiation<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region entity
        /// <summary>
        /// Start constructing a sql SELECT query expression for a single entity.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="SelectEntities{TDatabase, TEntity}"/>, a fluent builder for constructing a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        /// <typeparam name="TEntity">The entity type to select.</typeparam>
        SelectEntities<TDatabase, TEntity> SelectOne<TEntity>()
            where TEntity : class, IDbEntity, new();
        #endregion

        #region enum
        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="TEnum"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}" />
        /// </param>
        /// <returns><see cref="Sql.SelectValues{TDatabase, TEnum}"/>, a fluent builder for constructing a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        /// <typeparam name="TEnum">The type of the Enum to select.</typeparam>
        SelectValues<TDatabase, TEnum> SelectOne<TEnum>(AnyElement<TEnum> element)
            where TEnum : struct, Enum, IComparable;

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="TEnum"/>? value.  
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TEnum}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        /// <typeparam name="TEnum">The type of the Enum to select.</typeparam>
        SelectValues<TDatabase, TEnum?> SelectOne<TEnum>(AnyElement<TEnum?> element)
            where TEnum : struct, Enum, IComparable;
        #endregion

        #region object
        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="object"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ObjectElement" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, object}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, object> SelectOne(ObjectElement element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="object"/>? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableObjectElement" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, object}"/>?, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, object?> SelectOne(NullableObjectElement element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="T"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ObjectElement{T}" />
        /// </param>
        /// <returns><see cref="SelectObjects{TDatabase, T}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        /// <typeparam name="T">The type of the object to select.</typeparam>
        SelectObjects<TDatabase, T> SelectOne<T>(ObjectElement<T> element)
            where T : class;

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="T"/>? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableObjectElement{T}" />?
        /// </param>
        /// <returns><see cref="SelectObjects{TDatabase, T}"/>?, a fluent builder for constructing a sql SELECT query expression.</returns>
        /// <typeparam name="T">The type of the object to select.</typeparam>
        SelectObjects<TDatabase, T?> SelectOne<T>(NullableObjectElement<T> element)
            where T : class?;
        #endregion

        #region data type
        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="bool" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />
        ///</param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, bool> SelectOne(AnyElement<bool> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="bool" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />?
        ///</param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, bool?> SelectOne(AnyElement<bool?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="byte" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />
        ///</param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, byte> SelectOne(AnyElement<byte> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="byte" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />?
        ///</param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, byte?> SelectOne(AnyElement<byte?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="byte" />[] value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte[]}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, byte[]> SelectOne(AnyElement<byte[]> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="DateTime" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, DateTime> SelectOne(AnyElement<DateTime> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="DateTime" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, DateTime?> SelectOne(AnyElement<DateTime?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="DateTimeOffset" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, DateTimeOffset> SelectOne(AnyElement<DateTimeOffset> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="DateTimeOffset" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, DateTimeOffset?> SelectOne(AnyElement<DateTimeOffset?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="decimal" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, decimal> SelectOne(AnyElement<decimal> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="decimal" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, decimal?> SelectOne(AnyElement<decimal?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="double" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, double> SelectOne(AnyElement<double> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="double" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, double?> SelectOne(AnyElement<double?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="Guid" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, Guid> SelectOne(AnyElement<Guid> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="Guid" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, Guid?> SelectOne(AnyElement<Guid?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="short" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, short> SelectOne(AnyElement<short> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="short" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />?
        /// </param>
        /// <returns><see cref="SelectValue{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, short?> SelectOne(AnyElement<short?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="int" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, int> SelectOne(AnyElement<int> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="int" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, int?> SelectOne(AnyElement<int?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="long" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, long> SelectOne(AnyElement<long> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="long" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, long?> SelectOne(AnyElement<long?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="float" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, float> SelectOne(AnyElement<float> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="float" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, float?> SelectOne(AnyElement<float?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="string" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />?
        /// </param>
        /// <returns><see cref="SelectValue{TDatabase, String}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, string> SelectOne(StringElement element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="string" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, String}"/>?, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, string?> SelectOne(NullableStringElement element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="string" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, String}"/>?, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, string?> SelectOne(SelectExpression<string?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="TimeSpan" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, TimeSpan> SelectOne(AnyElement<TimeSpan> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="TimeSpan" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, TimeSpan?> SelectOne(AnyElement<TimeSpan?> element);
        #endregion

        #region dynamic
        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="System.Dynamic.ExpandoObject" /> object.  The properties of the object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element1">Any expression</param>
        /// <param name="element2">Any expression</param>
        /// <param name="elements">Any expression</param>
        /// <returns><see cref="SelectDynamics{TDatabase}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectDynamics<TDatabase> SelectOne(AnyElement element1, AnyElement element2, params AnyElement[] elements);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="System.Dynamic.ExpandoObject" /> object.  The properties of the object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element1">Any expression</param>
        /// <param name="elements">A list of any expression</param>
        /// <returns><see cref="SelectDynamics{TDatabase}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectDynamics<TDatabase> SelectOne(IEnumerable<AnyElement> elements);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="System.Dynamic.ExpandoObject" /> object.  The properties of the object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="elements">A list of any expression that is valid for a SELECT query expression.</param>
        /// <param name="additionalElements">Any additional fields to select as part of the SELECT query expression.</param>
        /// <returns><see cref="SelectDynamics{TDatabase}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectDynamics<TDatabase> SelectOne(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements);
        #endregion
    }
}
