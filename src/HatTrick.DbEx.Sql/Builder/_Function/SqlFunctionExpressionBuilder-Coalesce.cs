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
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public partial class SqlFunctionExpressionBuilder
    {
        #region object
        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableObjectCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public NullableObjectCoalesceFunctionExpression Coalesce(AnyElement element, IComparable value)
            => new(new List<AnyElement> { element, new LiteralExpression<object>(value) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableObjectCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public NullableObjectCoalesceFunctionExpression Coalesce(AnyElement element1, AnyElement element2, IComparable value)
            => new(new List<AnyElement> { element1, element2, new LiteralExpression<object>(value) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element3"/> value will be evaluated.</param>
        /// <param name="element3">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableObjectCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public NullableObjectCoalesceFunctionExpression Coalesce(AnyElement element1, AnyElement element2, AnyElement element3, IComparable value)
            => new(new List<AnyElement> { element1, element2, element3, new LiteralExpression<object>(value) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element3"/> value will be evaluated.</param>
        /// <param name="element3">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element4"/> value will be evaluated.</param>
        /// <param name="element4">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableObjectCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public NullableObjectCoalesceFunctionExpression Coalesce(AnyElement element1, AnyElement element2, AnyElement element3, AnyElement element4, IComparable value)
            => new(new List<AnyElement> { element1, element2, element3, element4, new LiteralExpression<object>(value) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element3"/> value will be evaluated.</param>
        /// <param name="element3">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element4"/> value will be evaluated.</param>
        /// <param name="element4">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element5"/> value will be evaluated.</param>
        /// <param name="element5">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableObjectCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public NullableObjectCoalesceFunctionExpression Coalesce(AnyElement element1, AnyElement element2, AnyElement element3, AnyElement element4, AnyElement element5, IComparable value)
            => new(new List<AnyElement> { element1, element2, element3, element4, element5, new LiteralExpression<object>(value) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="elements">A list of expressions of type <see cref="AnyElement"/>, the first non (database) NULL value will be returned.</param>
        /// <returns><see cref="NullableObjectCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="NullableObjectElement"/>.</returns>
        public NullableObjectCoalesceFunctionExpression Coalesce(params AnyElement[] elements)
            => new(elements.ToList());
        #endregion

        #region generic data type
        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.  Use this generic version to specify the resulting value type the function is expected to return.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="CoalesceFunctionExpression{TValue}"/> for use with any operation accepting a <see cref="AnyElement"/>.</returns>
        public CoalesceFunctionExpression<TValue> Coalesce<TValue>(AnyElement element, IComparable value)
            => new(new List<AnyElement> { element, new LiteralExpression<object>(value) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.  Use this generic version to specify the resulting value type the function is expected to return.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="CoalesceFunctionExpression{TValue}"/> for use with any operation accepting a <see cref="AnyElement"/>.</returns>
        public CoalesceFunctionExpression<TValue> Coalesce<TValue>(AnyElement element1, AnyElement element2, IComparable value)
            => new(new List<AnyElement> { element1, element2, new LiteralExpression<object>(value) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.  Use this generic version to specify the resulting value type the function is expected to return.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element3"/> value will be evaluated.</param>
        /// <param name="element3">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="CoalesceFunctionExpression{TValue}"/> for use with any operation accepting a <see cref="AnyElement"/>.</returns>
        public CoalesceFunctionExpression<TValue> Coalesce<TValue>(AnyElement element1, AnyElement element2, AnyElement element3, IComparable value)
            => new(new List<AnyElement> { element1, element2, element3, new LiteralExpression<object>(value) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.  Use this generic version to specify the resulting value type the function is expected to return.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element3"/> value will be evaluated.</param>
        /// <param name="element3">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element4"/> value will be evaluated.</param>
        /// <param name="element4">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="CoalesceFunctionExpression{TValue}"/> for use with any operation accepting a <see cref="AnyElement"/>.</returns>
        public CoalesceFunctionExpression<TValue> Coalesce<TValue>(AnyElement element1, AnyElement element2, AnyElement element3, AnyElement element4, IComparable value)
            => new(new List<AnyElement> { element1, element2, element3, element4, new LiteralExpression<object>(value) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.  Use this generic version to specify the resulting value type the function is expected to return.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> value will be evaluated.</param>
        /// <param name="element2">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element3"/> value will be evaluated.</param>
        /// <param name="element3">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element4"/> value will be evaluated.</param>
        /// <param name="element4">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="element5"/> value will be evaluated.</param>
        /// <param name="element5">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="CoalesceFunctionExpression{TValue}"/> for use with any operation accepting a <see cref="AnyElement"/>.</returns>
        public CoalesceFunctionExpression<TValue> Coalesce<TValue>(AnyElement element1, AnyElement element2, AnyElement element3, AnyElement element4, AnyElement element5, IComparable value)
            => new(new List<AnyElement> { element1, element2, element3, element4, element5, new LiteralExpression<object>(value) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.  Use this generic version to specify the resulting value type the function is expected to return.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="elements">A list of expressions of type <see cref="AnyElement"/>, the first non (database) NULL value will be returned.</param>
        /// <returns><see cref="CoalesceFunctionExpression{TValue}"/> for use with any operation accepting a <see cref="AnyElement"/>.</returns>
        public CoalesceFunctionExpression<TValue> Coalesce<TValue>(params AnyElement[] elements)
            => new(elements.ToList());
        #endregion

        #region enum
        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="EnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="EnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="EnumElement{TEnum}"/>.</returns>
        public EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumElement<TEnum> element, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new(new List<EnumElement<TEnum>> { element }, new LiteralExpression<TEnum>(value));

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="NullableEnumElement{TEnum}"/>.</returns>
        public NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumElement<TEnum> element1, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new(new List<NullableEnumElement<TEnum>> { element1 }, new LiteralExpression<TEnum?>(value));

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="EnumElement{TEnum}"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="EnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="EnumElement{TEnum}"/>.</returns>
        public EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumElement<TEnum> element1, EnumElement<TEnum> element2)
            where TEnum : struct, Enum, IComparable
            => new(new List<NullableEnumElement<TEnum>> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="EnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="EnumElement{TEnum}"/>.</returns>
        public EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumElement<TEnum> element1, NullableEnumElement<TEnum> element2, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new(new List<NullableEnumElement<TEnum>> { element1, element2 }, new LiteralExpression<TEnum>(value));

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="NullableEnumElement{TEnum}"/>.</returns>
        public NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumElement<TEnum> element1, NullableEnumElement<TEnum> element2, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new(new List<NullableEnumElement<TEnum>> { element1, element2 }, new LiteralExpression<TEnum?>(value));

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="EnumElement{TEnum}"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="EnumElement{TEnum}"/>.</returns>
        public EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumElement<TEnum> element1, NullableEnumElement<TEnum> element2, EnumElement<TEnum> element3)
            where TEnum : struct, Enum, IComparable
            => new(new List<NullableEnumElement<TEnum>> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="EnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="EnumElement{TEnum}"/>.</returns>
        public EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumElement<TEnum> element1, NullableEnumElement<TEnum> element2, NullableEnumElement<TEnum> element3, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new(new List<NullableEnumElement<TEnum>> { element1, element2, element3 }, new LiteralExpression<TEnum>(value));

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="NullableEnumElement{TEnum}"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="NullableEnumElement{TEnum}"/>.</returns>
        public NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumElement<TEnum> element1, NullableEnumElement<TEnum> element2, NullableEnumElement<TEnum> element3, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new(new List<NullableEnumElement<TEnum>> { element1, element2, element3 }, new LiteralExpression<TEnum?>(value));

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="elements">A list of expressions of type <see cref="NullableEnumElement{TEnum}"/>, the first non (database) NULL value in this list will be returned.</param>
        /// <returns><see cref="NullableEnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyElement{TEnum}"/>?.</returns>
        public NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(params NullableEnumElement<TEnum>[] elements)
            where TEnum : struct, Enum, IComparable
            => new(elements.ToList());
        #endregion
    }
}
