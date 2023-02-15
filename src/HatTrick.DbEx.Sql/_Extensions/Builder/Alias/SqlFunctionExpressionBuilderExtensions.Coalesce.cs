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

using __ = HatTrick.DbEx.Sql.Builder.SqlFunctionExpressionBuilder;

namespace HatTrick.DbEx.Sql.Builder.Alias
{
    public static partial class SqlFunctionExpressionBuilderExtensions
    {
        #region object
        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableObjectCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public static NullableObjectCoalesceFunctionExpression Coalesce(this __ _, (string TableName, string FieldName) element, IComparable value)
            => new(new List<AnyElement> { new AliasExpression<object>(element), new LiteralExpression<object>(value) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An alias of an expression, if this value evaluates to a (database) NULL, NULL will be returned.</param>
        /// <returns><see cref="NullableObjectCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public static NullableObjectCoalesceFunctionExpression Coalesce(this __ _, (string TableName, string FieldName) element1, (string TableName, string FieldName) element2)
            => new(new List<AnyElement> { new AliasExpression<object>(element1), new AliasExpression<object>(element2) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableObjectCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public static NullableObjectCoalesceFunctionExpression Coalesce(this __ _, (string TableName, string FieldName) element1, (string TableName, string FieldName) element2, IComparable value)
            => new(new List<AnyElement> { new AliasExpression<object>(element1), new AliasExpression<object>(element2), new LiteralExpression<object>(value) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, NULL will be returned.</param>
        /// <returns><see cref="NullableObjectCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public static NullableObjectCoalesceFunctionExpression Coalesce(this __ _, (string TableName, string FieldName) element1, AnyElement element2)
            => new(new List<AnyElement> { new AliasExpression<object>(element1), element2 });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableObjectCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public static NullableObjectCoalesceFunctionExpression Coalesce(this __ _, (string TableName, string FieldName) element1, AnyElement element2, IComparable value)
            => new(new List<AnyElement> { new AliasExpression<object>(element1), element2, new LiteralExpression<object>(value) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An alias of an expression, if this value evaluates to a (database) NULL, NULL will be returned.</param>
        /// <returns><see cref="NullableObjectCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public static NullableObjectCoalesceFunctionExpression Coalesce(this __ _, AnyElement element1, (string TableName, string FieldName) element2)
            => new(new List<AnyElement> { element1, new AliasExpression<object>(element2) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableObjectCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public static NullableObjectCoalesceFunctionExpression Coalesce(this __ _, AnyElement element1, (string TableName, string FieldName) element2, IComparable value)
            => new(new List<AnyElement> { element1, new AliasExpression<object>(element2), new LiteralExpression<object>(value) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="element3"/> value will be evaluated.</param>
        /// <param name="element3">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, NULL will be returned.</param>
        /// <returns><see cref="NullableObjectCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public static NullableObjectCoalesceFunctionExpression Coalesce(this __ _, AnyElement element1, (string TableName, string FieldName) element2, AnyElement element3)
            => new(new List<AnyElement> { element1, new AliasExpression<object>(element2), element3 });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="element3"/> value will be evaluated.</param>
        /// <param name="element3">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableObjectCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public static NullableObjectCoalesceFunctionExpression Coalesce(this __ _, AnyElement element1, (string TableName, string FieldName) element2, AnyElement element3, IComparable value)
            => new(new List<AnyElement> { element1, new AliasExpression<object>(element2), element3, new LiteralExpression<object>(value) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="element3"/> value will be evaluated.</param>
        /// <param name="element3">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, NULL will be returned.</param>
        /// <returns><see cref="NullableObjectCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public static NullableObjectCoalesceFunctionExpression Coalesce(this __ _, AnyElement element1, AnyElement element2, (string TableName, string FieldName) element3)
            => new(new List<AnyElement> { element1, element2, new AliasExpression<object>(element3) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="element3"/> value will be evaluated.</param>
        /// <param name="element3">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableObjectCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public static NullableObjectCoalesceFunctionExpression Coalesce(this __ _, AnyElement element1, AnyElement element2, (string TableName, string FieldName) element3, IComparable value)
            => new(new List<AnyElement> { element1, element2, new AliasExpression<object>(element3), new LiteralExpression<object>(value) });
        #endregion

        #region generic data type
        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="CoalesceFunctionExpression{TValue}"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public static CoalesceFunctionExpression<TValue> Coalesce<TValue>(this __ _, (string TableName, string FieldName) element, IComparable value)
            => new(new List<AnyElement> { new AliasExpression<TValue>(element), new LiteralExpression<object>(value) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An alias of an expression, if this value evaluates to a (database) NULL, NULL will be returned.</param>
        /// <returns><see cref="NullableCoalesceFunctionExpression{TValue}"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public static NullableCoalesceFunctionExpression<TValue> Coalesce<TValue>(this __ _, (string TableName, string FieldName) element1, (string TableName, string FieldName) element2)
            where TValue : IComparable
            => new(new List<AnyElement> { new AliasExpression<object>(element1), new AliasExpression<object>(element2) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="CoalesceFunctionExpression{TValue}"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public static CoalesceFunctionExpression<TValue> Coalesce<TValue>(this __ _, (string TableName, string FieldName) element1, (string TableName, string FieldName) element2, IComparable value)
            => new(new List<AnyElement> { new AliasExpression<object>(element1), new AliasExpression<object>(element2), new LiteralExpression<object>(value) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, NULL will be returned.</param>
        /// <returns><see cref="NullableCoalesceFunctionExpression{TValue}"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public static NullableCoalesceFunctionExpression<TValue> Coalesce<TValue>(this __ _, (string TableName, string FieldName) element1, AnyElement element2)
            where TValue : IComparable
            => new(new List<AnyElement> { new AliasExpression<object>(element1), element2 });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="CoalesceFunctionExpression{TValue}"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public static CoalesceFunctionExpression<TValue> Coalesce<TValue>(this __ _, (string TableName, string FieldName) element1, AnyElement element2, IComparable value)
            => new(new List<AnyElement> { new AliasExpression<object>(element1), element2, new LiteralExpression<object>(value) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An alias of an expression, if this value evaluates to a (database) NULL, NULL will be returned.</param>
        /// <returns><see cref="CoalesceFunctionExpression{TValue}"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public static CoalesceFunctionExpression<TValue> Coalesce<TValue>(this __ _, AnyElement element1, (string TableName, string FieldName) element2)
            => new(new List<AnyElement> { element1, new AliasExpression<object>(element2) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="CoalesceFunctionExpression{TValue}"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public static CoalesceFunctionExpression<TValue> Coalesce<TValue>(this __ _, AnyElement element1, (string TableName, string FieldName) element2, IComparable value)
            => new(new List<AnyElement> { element1, new AliasExpression<object>(element2), new LiteralExpression<object>(value) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="element3"/> value will be evaluated.</param>
        /// <param name="element3">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, NULL will be returned.</param>
        /// <returns><see cref="NullableCoalesceFunctionExpression{TValue}"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public static NullableCoalesceFunctionExpression<TValue> Coalesce<TValue>(this __ _, AnyElement element1, (string TableName, string FieldName) element2, AnyElement element3)
            where TValue : IComparable
            => new(new List<AnyElement> { element1, new AliasExpression<object>(element2), element3 });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="element3"/> value will be evaluated.</param>
        /// <param name="element3">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="CoalesceFunctionExpression{TValue}"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public static CoalesceFunctionExpression<TValue> Coalesce<TValue>(this __ _, AnyElement element1, (string TableName, string FieldName) element2, AnyElement element3, IComparable value)
            => new(new List<AnyElement> { element1, new AliasExpression<object>(element2), element3, new LiteralExpression<object>(value) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="element3"/> value will be evaluated.</param>
        /// <param name="element3">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, NULL will be returned.</param>
        /// <returns><see cref="NullableCoalesceFunctionExpression{TValue}"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public static NullableCoalesceFunctionExpression<TValue> Coalesce<TValue>(this __ _, AnyElement element1, AnyElement element2, (string TableName, string FieldName) element3)
            where TValue : IComparable
            => new(new List<AnyElement> { element1, element2, new AliasExpression<object>(element3) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="element3"/> value will be evaluated.</param>
        /// <param name="element3">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="CoalesceFunctionExpression{TValue}"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public static CoalesceFunctionExpression<TValue> Coalesce<TValue>(this __ _, AnyElement element1, AnyElement element2, (string TableName, string FieldName) element3, IComparable value)
            => new(new List<AnyElement> { element1, element2, new AliasExpression<object>(element3), new LiteralExpression<object>(value) });
        #endregion

        #region enum
        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="EnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="EnumElement{TEnum}"/>.</returns>
        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(this __ _, (string TableName, string FieldName) element, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new(new List<AnyElement<TEnum>> { new AliasExpression<TEnum>(element) }, new LiteralExpression<TEnum>(value));

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="NullableEnumElement{TEnum}"/>.</returns>
        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(this __ _, (string TableName, string FieldName) element, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new(new List<AnyElement<TEnum?>> { new AliasExpression<TEnum?>(element) }, new LiteralExpression<TEnum?>(value));

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="EnumElement{TEnum}"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="EnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="EnumElement{TEnum}"/>.</returns>
        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(this __ _, (string TableName, string FieldName) element1, EnumElement<TEnum> element2)
            where TEnum : struct, Enum, IComparable
            => new(new List<AnyElement<TEnum>> { new AliasExpression<TEnum>(element1) }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An alias of an expression, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="EnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="EnumElement{TEnum}"/>.</returns>
        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(this __ _, (string TableName, string FieldName) element1, NullableEnumElement<TEnum> element2, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new(new List<AnyElement<TEnum?>> { new AliasExpression<TEnum?>(element1), element2 }, new LiteralExpression<TEnum>(value));

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An alias of an expression, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="NullableEnumElement{TEnum}"/>.</returns>
        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(this __ _, NullableEnumElement<TEnum> element1, (string TableName, string FieldName) element2, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new(new List<AnyElement<TEnum?>> { element1, new AliasExpression<TEnum?>(element2) }, new LiteralExpression<TEnum?>(value));

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An alias of an expression, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="EnumElement{TEnum}"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="EnumElement{TEnum}"/>.</returns>
        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(this __ _, NullableEnumElement<TEnum> element1, (string TableName, string FieldName) element2, EnumElement<TEnum> element3)
            where TEnum : struct, Enum, IComparable
            => new(new List<AnyElement<TEnum?>> { element1, new AliasExpression<TEnum?>(element2) }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An alias of an expression, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="EnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="EnumElement{TEnum}"/>.</returns>
        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(this __ _, NullableEnumElement<TEnum> element1, (string TableName, string FieldName) element2, NullableEnumElement<TEnum> element3, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new(new List<AnyElement<TEnum?>> { element1, new AliasExpression<TEnum?>(element2), element3 }, new LiteralExpression<TEnum>(value));

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An alias of an expression, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="NullableEnumElement{TEnum}"/>.</returns>
        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(this __ _, NullableEnumElement<TEnum> element1, (string TableName, string FieldName) element2, NullableEnumElement<TEnum> element3, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new(new List<AnyElement<TEnum?>> { element1, new AliasExpression<TEnum?>(element2), element3 }, new LiteralExpression<TEnum?>(value));

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An alias of an expression, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="EnumElement{TEnum}"/>.</returns>
        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(this __ _, NullableEnumElement<TEnum> element1, NullableEnumElement<TEnum> element2, (string TableName, string FieldName) element3)
            where TEnum : struct, Enum, IComparable
            => new(new List<AnyElement<TEnum?>> { element1, element2 }, new AliasExpression<TEnum?>(element3));

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An alias of an expression, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="EnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="EnumElement{TEnum}"/>.</returns>
        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(this __ _, NullableEnumElement<TEnum> element1, NullableEnumElement<TEnum> element2, (string TableName, string FieldName) element3, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new(new List<AnyElement<TEnum?>> { element1, element2, new AliasExpression<TEnum?>(element3) }, new LiteralExpression<TEnum>(value));

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/coalesce>read the docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An alias of an expression, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="NullableEnumElement{TEnum}"/>.</returns>
        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(this __ _, NullableEnumElement<TEnum> element1, NullableEnumElement<TEnum> element2, (string TableName, string FieldName) element3, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new(new List<AnyElement<TEnum?>> { element1, element2, new AliasExpression<TEnum?>(element3) }, new LiteralExpression<TEnum?>(value));
        #endregion
    }
}
