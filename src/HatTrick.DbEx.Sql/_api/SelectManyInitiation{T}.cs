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
    public interface SelectManyInitiation<TDatabase>
#pragma warning restore IDE1006 // Naming Styles
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region entity
        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of entities.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="SelectEntities{TDatabase, TEntity}"/>, a fluent builder for constructing a sql SELECT query expression for a list of <typeparamref name="TEntity"/> entities.</returns>
        /// <typeparam name="TEntity">The entity type to select.</typeparam>
        SelectEntities<TDatabase, TEntity> SelectMany<TEntity>()
           where TEntity : class, IDbEntity, new();
        #endregion

        #region enum
        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="TEnum"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TEnum}"/>, a fluent builder for constructing a sql SELECT query expression for a list of <typeparamref name="TEnum"/> entities.</returns>
        SelectValues<TDatabase, TEnum> SelectMany<TEnum>(AnyElement<TEnum> element)
            where TEnum : struct, Enum, IComparable;

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="TEnum"/>? values.
        /// </summary>
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TEnum}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, TEnum?> SelectMany<TEnum>(AnyElement<TEnum?> element)
            where TEnum : struct, Enum, IComparable;
        #endregion

        #region object
        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="object"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ObjectElement" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, object}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, object>? SelectMany(ObjectElement element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="object"/>? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableObjectElement" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, object}"/>?, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, object?> SelectMany(NullableObjectElement element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="T"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ObjectElement{T}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, T}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        /// <typeparam name="T">The type of the object to select.</typeparam>
        SelectObjects<TDatabase, T> SelectMany<T>(ObjectElement<T> element)
            where T : class;

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="T"/>? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableObjectElement{T}" />?
        /// </param>
        /// <returns><see cref="SelectObjects{TDatabase, T}"/>?, a fluent builder for constructing a sql SELECT query expression.</returns>
        /// <typeparam name="T">The type of the object to select.</typeparam>
        SelectObjects<TDatabase, T?> SelectMany<T>(NullableObjectElement<T> element)
            where T : class?;
        #endregion

        #region data type
        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="bool" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, bool> SelectMany(AnyElement<bool> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="bool" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, bool?> SelectMany(AnyElement<bool?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="byte" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, byte> SelectMany(AnyElement<byte> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="byte" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, byte?> SelectMany(AnyElement<byte?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="byte" />[] values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte[]}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, byte[]> SelectMany(AnyElement<byte[]> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="DateTime" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, DateTime> SelectMany(AnyElement<DateTime> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="DateTime" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, DateTime?> SelectMany(AnyElement<DateTime?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="DateTimeOffset" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, DateTimeOffset> SelectMany(AnyElement<DateTimeOffset> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="DateTimeOffset" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, DateTimeOffset?> SelectMany(AnyElement<DateTimeOffset?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="decimal" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, decimal> SelectMany(AnyElement<decimal> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="decimal" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, decimal?> SelectMany(AnyElement<decimal?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="double" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, double> SelectMany(AnyElement<double> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="double" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, double?> SelectMany(AnyElement<double?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="Guid" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, Guid> SelectMany(AnyElement<Guid> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="Guid" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, Guid?> SelectMany(AnyElement<Guid?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="short" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, short> SelectMany(AnyElement<short> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="short" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, short?> SelectMany(AnyElement<short?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="int" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, int> SelectMany(AnyElement<int> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="int" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}" />?
        ///, for example "dbo.:column.Entity.Name}.CreditLimit"
        ///</param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, int?> SelectMany(AnyElement<int?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="long" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, long> SelectMany(AnyElement<long> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="long" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, long?> SelectMany(AnyElement<long?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="float" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, float> SelectMany(AnyElement<float> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="float" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, float?> SelectMany(AnyElement<float?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="string" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />?
        ///, for example "dbo.Address.Line1" or "db.fx.Concat("Value: ", dbo.Address.Line1)"
        ///</param>
        /// <returns><see cref="SelectValues{TDatabase, String}"/>?, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, string> SelectMany(StringElement element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="string" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, String}"/>?, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, string?> SelectMany(NullableStringElement element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="string" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, String}"/>?, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, string?> SelectMany(SelectExpression<string?> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="TimeSpan" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}" />
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, TimeSpan> SelectMany(AnyElement<TimeSpan> element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="TimeSpan" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}" />?
        /// </param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, TimeSpan?> SelectMany(AnyElement<TimeSpan?> element);
        #endregion

        #region dynamic
        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="System.Dynamic.ExpandoObject" /> objects.  The dynamic properties of each object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element1">Any expression</param>
        /// <param name="element2">Any expression</param>
        /// <param name="elements">Any expression</param>
        /// <returns><see cref="SelectDynamics{TDatabase}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectDynamics<TDatabase> SelectMany(AnyElement element1, AnyElement element2, params AnyElement[] elements);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="System.Dynamic.ExpandoObject" /> objects.  The dynamic properties of each object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="elements">A list of any expression</param>
        /// <returns><see cref="SelectDynamics{TDatabase}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectDynamics<TDatabase> SelectMany(IEnumerable<AnyElement> elements);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="System.Dynamic.ExpandoObject" /> objects.  The dynamic properties of each object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="elements">A list of any expression that is valid for a SELECT query expression.</param>
        /// <param name="additionalElements">Any additional fields to select as part of the SELECT query expression.</param>
        /// <returns><see cref="SelectDynamics{TDatabase}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectDynamics<TDatabase> SelectMany(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements);
        #endregion
    }
}
