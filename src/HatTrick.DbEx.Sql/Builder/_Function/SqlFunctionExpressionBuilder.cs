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

﻿using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    /// <summary>
    /// Methods to construct database platform aggregation and conversion functions, for example "Min", "Max" "Avg".
    /// </summary>
#pragma warning disable CA1052 // Static holder types should be Static or NotInheritable
    public partial class SqlFunctionExpressionBuilder
#pragma warning restore CA1052 // Static holder types should be Static or NotInheritable
    {
        #region concat
        #region object
        /// <summary>
        /// Construct an expression for the CONCAT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/concat-transact-sql">Microsoft docs on CONCAT</see></para>
        /// </summary>
        /// <param name="elements">A list of expressions of type <see cref="AnyObjectElement"/> to join into a single string.</param>
        /// <returns><see cref="StringConcatFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="StringElement"/>.</returns>
        public static StringConcatFunctionExpression Concat(params AnyObjectElement[] elements)
            => new StringConcatFunctionExpression(elements);

        /// <summary>
        /// Construct an expression for the CONCAT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/concat-transact-sql">Microsoft docs on CONCAT</see></para>
        /// </summary>
        /// <param name="value">The beginning part of the joined string.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyObjectElement"/> to add to the string after <paramref name="value"/>.</param>
        /// <returns><see cref="StringConcatFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="StringElement"/>.</returns>
        public static StringConcatFunctionExpression Concat(string value, params AnyObjectElement[] elements)
            => new StringConcatFunctionExpression(new List<AnyElement> { new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(elements).ToArray());

        /// <summary>
        /// Construct an expression for the CONCAT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/concat-transact-sql">Microsoft docs on CONCAT</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyObjectElement"/>, the beginning part of the joined string.</param>
        /// <param name="value">The part of the joined string after <paramref name="element1"/>.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyStringElement"/> to add to the string after <paramref name="value"/>.</param>
        /// <returns><see cref="StringConcatFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="StringElement"/>.</returns>
        public static StringConcatFunctionExpression Concat(AnyObjectElement element1, string value, params AnyStringElement[] elements)
            => new StringConcatFunctionExpression(new List<AnyElement> { element1, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(elements).ToArray());

        /// <summary>
        /// Construct an expression for the CONCAT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/concat-transact-sql">Microsoft docs on CONCAT</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyStringElement"/>, the beginning part of the joined string.</param>
        /// <param name="element2">An expression of type <see cref="AnyObjectElement"/>, the part of the joined string after <paramref name="element1"/>.</param>
        /// <param name="value">The part of the joined string after <paramref name="element2"/>.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyStringElement"/> to add to the string after <paramref name="value"/>.</param>
        /// <returns><see cref="StringConcatFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="StringElement"/>.</returns>
        public static StringConcatFunctionExpression Concat(AnyStringElement element1, AnyObjectElement element2, string value, params AnyStringElement[] elements)
            => new StringConcatFunctionExpression(new List<AnyElement> { element1, element2, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(elements).ToArray());

        /// <summary>
        /// Construct an expression for the CONCAT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/concat-transact-sql">Microsoft docs on CONCAT</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyStringElement"/>, the beginning part of the joined string.</param>
        /// <param name="element2">An expression of type <see cref="AnyStringElement"/>, the part of the joined string after <paramref name="element1"/>.</param>
        /// <param name="element3">An expression of type <see cref="AnyObjectElement"/>, the part of the joined string after <paramref name="element2"/>.</param>
        /// <param name="value">The part of the joined string after <paramref name="element3"/>.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyStringElement"/> to add to the string after <paramref name="value"/>.</param>
        /// <returns><see cref="StringConcatFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="StringElement"/>.</returns>
        public static StringConcatFunctionExpression Concat(AnyStringElement element1, AnyStringElement element2, AnyObjectElement element3, string value, params AnyStringElement[] elements)
            => new StringConcatFunctionExpression(new List<AnyElement> { element1, element2, element3, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(elements).ToArray());

        /// <summary>
        /// Construct an expression for the CONCAT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/concat-transact-sql">Microsoft docs on CONCAT</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyStringElement"/>, the beginning part of the joined string.</param>
        /// <param name="element2">An expression of type <see cref="AnyStringElement"/>, the part of the joined string after <paramref name="element1"/>.</param>
        /// <param name="element3">An expression of type <see cref="AnyStringElement"/>, the part of the joined string after <paramref name="element2"/>.</param>
        /// <param name="element4">An expression of type <see cref="AnyObjectElement"/>, the part of the joined string after <paramref name="element3"/>.</param>
        /// <param name="value">The part of the joined string after <paramref name="element4"/>.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyStringElement"/> to add to the string after <paramref name="value"/>.</param>
        /// <returns><see cref="StringConcatFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="StringElement"/>.</returns>
        public static StringConcatFunctionExpression Concat(AnyStringElement element1, AnyStringElement element2, AnyStringElement element3, AnyObjectElement element4, string value, params AnyStringElement[] elements)
            => new StringConcatFunctionExpression(new List<AnyElement> { element1, element2, element3, element4, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(elements).ToArray());
        #endregion

        #region string
        /// <summary>
        /// Construct an expression for the CONCAT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/concat-transact-sql">Microsoft docs on CONCAT</see></para>
        /// </summary>
        /// <param name="elements">A list of expressions of type <see cref="AnyStringElement"/> to join into a single string.</param>
        /// <returns><see cref="StringConcatFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="StringElement"/>.</returns>
        public static StringConcatFunctionExpression Concat(params AnyStringElement[] elements)
            => new StringConcatFunctionExpression(elements);

        /// <summary>
        /// Construct an expression for the CONCAT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/concat-transact-sql">Microsoft docs on CONCAT</see></para>
        /// </summary>
        /// <param name="value">The beginning part of the joined string.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyStringElement"/> to add to the string after <paramref name="value"/>.</param>
        /// <returns><see cref="StringConcatFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="StringElement"/>.</returns>
        public static StringConcatFunctionExpression Concat(string value, params AnyStringElement[] elements)
            => new StringConcatFunctionExpression(new List<AnyStringElement> { new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(elements).ToArray());

        /// <summary>
        /// Construct an expression for the CONCAT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/concat-transact-sql">Microsoft docs on CONCAT</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyStringElement"/>, the beginning part of the joined string.</param>
        /// <param name="value">The part of the joined string after <paramref name="element1"/>.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyStringElement"/> to add to the string after <paramref name="value"/>.</param>
        /// <returns><see cref="StringConcatFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="StringElement"/>.</returns>
        public static StringConcatFunctionExpression Concat(AnyStringElement element1, string value, params AnyStringElement[] elements)
            => new StringConcatFunctionExpression(new List<AnyStringElement> { element1, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(elements).ToArray());

        /// <summary>
        /// Construct an expression for the CONCAT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/concat-transact-sql">Microsoft docs on CONCAT</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyStringElement"/>, the beginning part of the joined string.</param>
        /// <param name="element2">An expression of type <see cref="AnyStringElement"/>, the part of the joined string after <paramref name="element1"/>.</param>
        /// <param name="value">The part of the joined string after <paramref name="element2"/>.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyStringElement"/> to add to the string after <paramref name="value"/>.</param>
        /// <returns><see cref="StringConcatFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="StringElement"/>.</returns>
        public static StringConcatFunctionExpression Concat(AnyStringElement element1, AnyStringElement element2, string value, params AnyStringElement[] elements)
            => new StringConcatFunctionExpression(new List<AnyStringElement> { element1, element2, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(elements).ToArray());

        /// <summary>
        /// Construct an expression for the CONCAT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/concat-transact-sql">Microsoft docs on CONCAT</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyStringElement"/>, the beginning part of the joined string.</param>
        /// <param name="element2">An expression of type <see cref="AnyStringElement"/>, the part of the joined string after <paramref name="element1"/>.</param>
        /// <param name="element3">An expression of type <see cref="AnyStringElement"/>, the part of the joined string after <paramref name="element2"/>.</param>
        /// <param name="value">The part of the joined string after <paramref name="element3"/>.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyStringElement"/> to add to the string after <paramref name="value"/>.</param>
        /// <returns><see cref="StringConcatFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="StringElement"/>.</returns>
        public static StringConcatFunctionExpression Concat(AnyStringElement element1, AnyStringElement element2, AnyStringElement element3, string value, params AnyStringElement[] elements)
            => new StringConcatFunctionExpression(new List<AnyStringElement> { element1, element2, element3, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(elements).ToArray());

        /// <summary>
        /// Construct an expression for the CONCAT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/concat-transact-sql">Microsoft docs on CONCAT</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyStringElement"/>, the beginning part of the joined string.</param>
        /// <param name="element2">An expression of type <see cref="AnyStringElement"/>, the part of the joined string after <paramref name="element1"/>.</param>
        /// <param name="element3">An expression of type <see cref="AnyStringElement"/>, the part of the joined string after <paramref name="element2"/>.</param>
        /// <param name="element4">An expression of type <see cref="AnyStringElement"/>, the part of the joined string after <paramref name="element3"/>.</param>
        /// <param name="value">The part of the joined string after <paramref name="element4"/>.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyStringElement"/> to add to the string after <paramref name="value"/>.</param>
        /// <returns><see cref="StringConcatFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="StringElement"/>.</returns>
        public static StringConcatFunctionExpression Concat(AnyStringElement element1, AnyStringElement element2, AnyStringElement element3, AnyStringElement element4, string value, params AnyStringElement[] elements)
            => new StringConcatFunctionExpression(new List<AnyStringElement> { element1, element2, element3, element4, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(elements).ToArray());
        #endregion
        #endregion

        #region coalesce
        #region object
        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="ObjectCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyObjectElement"/>.</returns>
        public static ObjectCoalesceFunctionExpression Coalesce(AnyElement element, object value)
            => new ObjectCoalesceFunctionExpression(new List<AnyElement> { element, new ObjectExpressionMediator(new LiteralExpression<object>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="ObjectCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyObjectElement"/>.</returns>
        public static ObjectCoalesceFunctionExpression Coalesce(AnyElement element1, AnyElement element2, object value)
            => new ObjectCoalesceFunctionExpression(new List<AnyElement> { element1, element2, new ObjectExpressionMediator(new LiteralExpression<object>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="ObjectCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyObjectElement"/>.</returns>
        public static ObjectCoalesceFunctionExpression Coalesce(AnyElement element1, AnyElement element2, AnyElement element3, object value)
            => new ObjectCoalesceFunctionExpression(new List<AnyElement> { element1, element2, element3, new ObjectExpressionMediator(new LiteralExpression<object>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element4">An expression of type <see cref="AnyElement"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyElement"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> evaluate to a (database) NULL, the first non (database) NULL value in this list will be returned.</param>
        /// <returns><see cref="ObjectCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyObjectElement"/>.</returns>
        public static ObjectCoalesceFunctionExpression Coalesce(AnyElement element1, AnyElement element2, AnyElement element3, AnyElement element4, params AnyElement[] elements)
            => new ObjectCoalesceFunctionExpression(new List<AnyElement> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region bool
        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyBooleanElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="BooleanCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyBooleanElement"/> or <see cref="BooleanElement"/>.</returns>
        public static BooleanCoalesceFunctionExpression Coalesce(AnyBooleanElement element, bool value)
            => new BooleanCoalesceFunctionExpression(new List<AnyBooleanElement> { element, new BooleanExpressionMediator(new LiteralExpression<bool>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyBooleanElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableBooleanCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyBooleanElement"/> or <see cref="NullableBooleanElement"/>.</returns>
        public static NullableBooleanCoalesceFunctionExpression Coalesce(AnyBooleanElement element1, bool? value)
            => new NullableBooleanCoalesceFunctionExpression(new List<AnyBooleanElement> { element1, new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyBooleanElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="BooleanElement"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableBooleanCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyBooleanElement"/> or <see cref="NullableBooleanElement"/>.</returns>
        public static NullableBooleanCoalesceFunctionExpression Coalesce(AnyBooleanElement element1, BooleanElement element2)
            => new NullableBooleanCoalesceFunctionExpression(new List<AnyBooleanElement> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyBooleanElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableBooleanElement"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableBooleanCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyBooleanElement"/> or <see cref="NullableBooleanElement"/>.</returns>
        public static NullableBooleanCoalesceFunctionExpression Coalesce(AnyBooleanElement element1, NullableBooleanElement element2)
            => new NullableBooleanCoalesceFunctionExpression(new List<AnyBooleanElement> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyBooleanElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyBooleanElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="BooleanCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyBooleanElement"/> or <see cref="BooleanElement"/>.</returns>
        public static BooleanCoalesceFunctionExpression Coalesce(AnyBooleanElement element1, AnyBooleanElement element2, bool value)
            => new BooleanCoalesceFunctionExpression(new List<AnyBooleanElement> { element1, element2, new BooleanExpressionMediator(new LiteralExpression<bool>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyBooleanElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyBooleanElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableBooleanCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyBooleanElement"/> or <see cref="NullableBooleanElement"/>.</returns>
        public static NullableBooleanCoalesceFunctionExpression Coalesce(AnyBooleanElement element1, AnyBooleanElement element2, bool? value)
            => new NullableBooleanCoalesceFunctionExpression(new List<AnyBooleanElement> { element1, element2, new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyBooleanElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyBooleanElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="BooleanElement"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableBooleanCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyBooleanElement"/> or <see cref="NullableBooleanElement"/>.</returns>
        public static NullableBooleanCoalesceFunctionExpression Coalesce(AnyBooleanElement element1, AnyBooleanElement element2, BooleanElement element3)
            => new NullableBooleanCoalesceFunctionExpression(new List<AnyBooleanElement> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyBooleanElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyBooleanElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="NullableBooleanElement"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableBooleanCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyBooleanElement"/> or <see cref="NullableBooleanElement"/>.</returns>
        public static NullableBooleanCoalesceFunctionExpression Coalesce(AnyBooleanElement element1, AnyBooleanElement element2, NullableBooleanElement element3)
            => new NullableBooleanCoalesceFunctionExpression(new List<AnyBooleanElement> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyBooleanElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyBooleanElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyBooleanElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="BooleanCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyBooleanElement"/> or <see cref="BooleanElement"/>.</returns>
        public static BooleanCoalesceFunctionExpression Coalesce(AnyBooleanElement element1, AnyBooleanElement element2, AnyBooleanElement element3, bool value)
            => new BooleanCoalesceFunctionExpression(new List<AnyBooleanElement> { element1, element2, element3, new BooleanExpressionMediator(new LiteralExpression<bool>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyBooleanElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyBooleanElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyBooleanElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableBooleanCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyBooleanElement"/> or <see cref="NullableBooleanElement"/>.</returns>
        public static NullableBooleanCoalesceFunctionExpression Coalesce(AnyBooleanElement element1, AnyBooleanElement element2, AnyBooleanElement element3, bool? value)
            => new NullableBooleanCoalesceFunctionExpression(new List<AnyBooleanElement> { element1, element2, element3, new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyBooleanElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyBooleanElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyBooleanElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element4">An expression of type <see cref="AnyBooleanElement"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyBooleanElement"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> evaluate to a (database) NULL, the first non (database) NULL value in this list will be returned.</param>
        /// <returns><see cref="NullableBooleanCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyBooleanElement"/> or <see cref="NullableBooleanElement"/>.</returns>
        public static NullableBooleanCoalesceFunctionExpression Coalesce(AnyBooleanElement element1, AnyBooleanElement element2, AnyBooleanElement element3, AnyBooleanElement element4, params AnyBooleanElement[] elements)
            => new NullableBooleanCoalesceFunctionExpression(new List<AnyBooleanElement> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region byte
        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyByteElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="ByteCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="ByteElement"/>.</returns>
        public static ByteCoalesceFunctionExpression Coalesce(AnyByteElement element, byte value)
            => new ByteCoalesceFunctionExpression(new List<AnyByteElement> { element, new ByteExpressionMediator(new LiteralExpression<byte>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyByteElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableByteCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="NullableByteElement"/>.</returns>
        public static NullableByteCoalesceFunctionExpression Coalesce(AnyByteElement element1, byte? value)
            => new NullableByteCoalesceFunctionExpression(new List<AnyByteElement> { element1, new NullableByteExpressionMediator(new LiteralExpression<byte?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyByteElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="ByteElement"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableByteCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="NullableByteElement"/>.</returns>
        public static NullableByteCoalesceFunctionExpression Coalesce(AnyByteElement element1, ByteElement element2)
            => new NullableByteCoalesceFunctionExpression(new List<AnyByteElement> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyByteElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableByteElement"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableByteCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="NullableByteElement"/>.</returns>
        public static NullableByteCoalesceFunctionExpression Coalesce(AnyByteElement element1, NullableByteElement element2)
            => new NullableByteCoalesceFunctionExpression(new List<AnyByteElement> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyByteElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyByteElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="ByteCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="ByteElement"/>.</returns>
        public static ByteCoalesceFunctionExpression Coalesce(AnyByteElement element1, AnyByteElement element2, byte value)
            => new ByteCoalesceFunctionExpression(new List<AnyByteElement> { element1, element2, new ByteExpressionMediator(new LiteralExpression<byte>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyByteElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyByteElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableByteCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="NullableByteElement"/>.</returns>
        public static NullableByteCoalesceFunctionExpression Coalesce(AnyByteElement element1, AnyByteElement element2, byte? value)
            => new NullableByteCoalesceFunctionExpression(new List<AnyByteElement> { element1, element2, new NullableByteExpressionMediator(new LiteralExpression<byte?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyByteElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyByteElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="ByteElement"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableByteCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="NullableByteElement"/>.</returns>
        public static NullableByteCoalesceFunctionExpression Coalesce(AnyByteElement element1, AnyByteElement element2, ByteElement element3)
            => new NullableByteCoalesceFunctionExpression(new List<AnyByteElement> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyByteElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyByteElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="NullableByteElement"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableByteCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="NullableByteElement"/>.</returns>
        public static NullableByteCoalesceFunctionExpression Coalesce(AnyByteElement element1, AnyByteElement element2, NullableByteElement element3)
            => new NullableByteCoalesceFunctionExpression(new List<AnyByteElement> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyByteElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyByteElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyByteElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="ByteCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="ByteElement"/>.</returns>
        public static ByteCoalesceFunctionExpression Coalesce(AnyByteElement element1, AnyByteElement element2, AnyByteElement element3, byte value)
            => new ByteCoalesceFunctionExpression(new List<AnyByteElement> { element1, element2, element3, new ByteExpressionMediator(new LiteralExpression<byte>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyByteElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyByteElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyByteElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableByteCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="NullableByteElement"/>.</returns>
        public static NullableByteCoalesceFunctionExpression Coalesce(AnyByteElement element1, AnyByteElement element2, AnyByteElement element3, byte? value)
            => new NullableByteCoalesceFunctionExpression(new List<AnyByteElement> { element1, element2, element3, new NullableByteExpressionMediator(new LiteralExpression<byte?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyByteElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyByteElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyByteElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element4">An expression of type <see cref="AnyByteElement"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyByteElement"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> evaluate to a (database) NULL, the first non (database) NULL value in this list will be returned.</param>
        /// <returns><see cref="NullableByteCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="NullableByteElement"/>.</returns>
        public static NullableByteCoalesceFunctionExpression Coalesce(AnyByteElement element1, AnyByteElement element2, AnyByteElement element3, AnyByteElement element4, params AnyByteElement[] elements)
            => new NullableByteCoalesceFunctionExpression(new List<AnyByteElement> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region DateTime
        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDateTimeElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DateTimeCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="DateTimeElement"/>.</returns>
        public static DateTimeCoalesceFunctionExpression Coalesce(AnyDateTimeElement element, DateTime value)
            => new DateTimeCoalesceFunctionExpression(new List<AnyDateTimeElement> { element, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDateTimeElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="NullableDateTimeElement"/>.</returns>
        public static NullableDateTimeCoalesceFunctionExpression Coalesce(AnyDateTimeElement element1, DateTime? value)
            => new NullableDateTimeCoalesceFunctionExpression(new List<AnyDateTimeElement> { element1, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDateTimeElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="DateTimeElement"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="NullableDateTimeElement"/>.</returns>
        public static NullableDateTimeCoalesceFunctionExpression Coalesce(AnyDateTimeElement element1, DateTimeElement element2)
            => new NullableDateTimeCoalesceFunctionExpression(new List<AnyDateTimeElement> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDateTimeElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableDateTimeElement"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="NullableDateTimeElement"/>.</returns>
        public static NullableDateTimeCoalesceFunctionExpression Coalesce(AnyDateTimeElement element1, NullableDateTimeElement element2)
            => new NullableDateTimeCoalesceFunctionExpression(new List<AnyDateTimeElement> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDateTimeElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDateTimeElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="DateTimeCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="DateTimeElement"/>.</returns>
        public static DateTimeCoalesceFunctionExpression Coalesce(AnyDateTimeElement element1, AnyDateTimeElement element2, DateTime value)
            => new DateTimeCoalesceFunctionExpression(new List<AnyDateTimeElement> { element1, element2, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDateTimeElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDateTimeElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="NullableDateTimeElement"/>.</returns>
        public static NullableDateTimeCoalesceFunctionExpression Coalesce(AnyDateTimeElement element1, AnyDateTimeElement element2, DateTime? value)
            => new NullableDateTimeCoalesceFunctionExpression(new List<AnyDateTimeElement> { element1, element2, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDateTimeElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDateTimeElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="DateTimeElement"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="NullableDateTimeElement"/>.</returns>
        public static NullableDateTimeCoalesceFunctionExpression Coalesce(AnyDateTimeElement element1, AnyDateTimeElement element2, DateTimeElement element3)
            => new NullableDateTimeCoalesceFunctionExpression(new List<AnyDateTimeElement> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDateTimeElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDateTimeElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="NullableDateTimeElement"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="NullableDateTimeElement"/>.</returns>
        public static NullableDateTimeCoalesceFunctionExpression Coalesce(AnyDateTimeElement element1, AnyDateTimeElement element2, NullableDateTimeElement element3)
            => new NullableDateTimeCoalesceFunctionExpression(new List<AnyDateTimeElement> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDateTimeElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDateTimeElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyDateTimeElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="DateTimeCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="DateTimeElement"/>.</returns>
        public static DateTimeCoalesceFunctionExpression Coalesce(AnyDateTimeElement element1, AnyDateTimeElement element2, AnyDateTimeElement element3, DateTime value)
            => new DateTimeCoalesceFunctionExpression(new List<AnyDateTimeElement> { element1, element2, element3, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDateTimeElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDateTimeElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyDateTimeElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="NullableDateTimeElement"/>.</returns>
        public static NullableDateTimeCoalesceFunctionExpression Coalesce(AnyDateTimeElement element1, AnyDateTimeElement element2, AnyDateTimeElement element3, DateTime? value)
            => new NullableDateTimeCoalesceFunctionExpression(new List<AnyDateTimeElement> { element1, element2, element3, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDateTimeElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDateTimeElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyDateTimeElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element4">An expression of type <see cref="AnyDateTimeElement"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyDateTimeElement"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> evaluate to a (database) NULL, the first non (database) NULL value in this list will be returned.</param>
        /// <returns><see cref="NullableDateTimeCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="NullableDateTimeElement"/>.</returns>
        public static NullableDateTimeCoalesceFunctionExpression Coalesce(AnyDateTimeElement element1, AnyDateTimeElement element2, AnyDateTimeElement element3, AnyDateTimeElement element4, params AnyDateTimeElement[] elements)
            => new NullableDateTimeCoalesceFunctionExpression(new List<AnyDateTimeElement> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region DateTimeOffset
        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DateTimeOffsetCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="DateTimeOffsetElement"/>.</returns>
        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(AnyDateTimeOffsetElement element, DateTimeOffset value)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<AnyDateTimeOffsetElement> { element, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeOffsetCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="NullableDateTimeOffsetElement"/>.</returns>
        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(AnyDateTimeOffsetElement element1, DateTimeOffset? value)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<AnyDateTimeOffsetElement> { element1, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="DateTimeOffsetElement"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeOffsetCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="NullableDateTimeOffsetElement"/>.</returns>
        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(AnyDateTimeOffsetElement element1, DateTimeOffsetElement element2)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<AnyDateTimeOffsetElement> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableDateTimeOffsetElement"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeOffsetCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="NullableDateTimeOffsetElement"/>.</returns>
        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(AnyDateTimeOffsetElement element1, NullableDateTimeOffsetElement element2)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<AnyDateTimeOffsetElement> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="DateTimeOffsetCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="DateTimeOffsetElement"/>.</returns>
        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(AnyDateTimeOffsetElement element1, AnyDateTimeOffsetElement element2, DateTimeOffset value)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<AnyDateTimeOffsetElement> { element1, element2, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeOffsetCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="NullableDateTimeOffsetElement"/>.</returns>
        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(AnyDateTimeOffsetElement element1, AnyDateTimeOffsetElement element2, DateTimeOffset? value)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<AnyDateTimeOffsetElement> { element1, element2, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="DateTimeOffsetElement"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeOffsetCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="NullableDateTimeOffsetElement"/>.</returns>
        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(AnyDateTimeOffsetElement element1, AnyDateTimeOffsetElement element2, DateTimeOffsetElement element3)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<AnyDateTimeOffsetElement> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="NullableDateTimeOffsetElement"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeOffsetCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="NullableDateTimeOffsetElement"/>.</returns>
        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(AnyDateTimeOffsetElement element1, AnyDateTimeOffsetElement element2, NullableDateTimeOffsetElement element3)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<AnyDateTimeOffsetElement> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="DateTimeOffsetCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="DateTimeOffsetElement"/>.</returns>
        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(AnyDateTimeOffsetElement element1, AnyDateTimeOffsetElement element2, AnyDateTimeOffsetElement element3, DateTimeOffset value)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<AnyDateTimeOffsetElement> { element1, element2, element3, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeOffsetCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="NullableDateTimeOffsetElement"/>.</returns>
        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(AnyDateTimeOffsetElement element1, AnyDateTimeOffsetElement element2, AnyDateTimeOffsetElement element3, DateTimeOffset? value)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<AnyDateTimeOffsetElement> { element1, element2, element3, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element4">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyDateTimeOffsetElement"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> evaluate to a (database) NULL, the first non (database) NULL value in this list will be returned.</param>
        /// <returns><see cref="NullableDateTimeOffsetCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="NullableDateTimeOffsetElement"/>.</returns>
        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(AnyDateTimeOffsetElement element1, AnyDateTimeOffsetElement element2, AnyDateTimeOffsetElement element3, AnyDateTimeOffsetElement element4, params AnyDateTimeOffsetElement[] elements)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<AnyDateTimeOffsetElement> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region double
        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDoubleElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DoubleCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="DoubleElement"/>.</returns>
        public static DoubleCoalesceFunctionExpression Coalesce(AnyDoubleElement element, double value)
            => new DoubleCoalesceFunctionExpression(new List<AnyDoubleElement> { element, new DoubleExpressionMediator(new LiteralExpression<double>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDoubleElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDoubleCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="NullableDoubleElement"/>.</returns>
        public static NullableDoubleCoalesceFunctionExpression Coalesce(AnyDoubleElement element1, double? value)
            => new NullableDoubleCoalesceFunctionExpression(new List<AnyDoubleElement> { element1, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDoubleElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="DoubleElement"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDoubleCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="NullableDoubleElement"/>.</returns>
        public static NullableDoubleCoalesceFunctionExpression Coalesce(AnyDoubleElement element1, DoubleElement element2)
            => new NullableDoubleCoalesceFunctionExpression(new List<AnyDoubleElement> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDoubleElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableDoubleElement"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDoubleCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="NullableDoubleElement"/>.</returns>
        public static NullableDoubleCoalesceFunctionExpression Coalesce(AnyDoubleElement element1, NullableDoubleElement element2)
            => new NullableDoubleCoalesceFunctionExpression(new List<AnyDoubleElement> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDoubleElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDoubleElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="DoubleCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="DoubleElement"/>.</returns>
        public static DoubleCoalesceFunctionExpression Coalesce(AnyDoubleElement element1, AnyDoubleElement element2, double value)
            => new DoubleCoalesceFunctionExpression(new List<AnyDoubleElement> { element1, element2, new DoubleExpressionMediator(new LiteralExpression<double>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDoubleElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDoubleElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableDoubleCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="NullableDoubleElement"/>.</returns>
        public static NullableDoubleCoalesceFunctionExpression Coalesce(AnyDoubleElement element1, AnyDoubleElement element2, double? value)
            => new NullableDoubleCoalesceFunctionExpression(new List<AnyDoubleElement> { element1, element2, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDoubleElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDoubleElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="DoubleElement"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableDoubleCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="NullableDoubleElement"/>.</returns>
        public static NullableDoubleCoalesceFunctionExpression Coalesce(AnyDoubleElement element1, AnyDoubleElement element2, DoubleElement element3)
            => new NullableDoubleCoalesceFunctionExpression(new List<AnyDoubleElement> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDoubleElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDoubleElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="NullableDoubleElement"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableDoubleCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="NullableDoubleElement"/>.</returns>
        public static NullableDoubleCoalesceFunctionExpression Coalesce(AnyDoubleElement element1, AnyDoubleElement element2, NullableDoubleElement element3)
            => new NullableDoubleCoalesceFunctionExpression(new List<AnyDoubleElement> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDoubleElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDoubleElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyDoubleElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="DoubleCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="DoubleElement"/>.</returns>
        public static DoubleCoalesceFunctionExpression Coalesce(AnyDoubleElement element1, AnyDoubleElement element2, AnyDoubleElement element3, double value)
            => new DoubleCoalesceFunctionExpression(new List<AnyDoubleElement> { element1, element2, element3, new DoubleExpressionMediator(new LiteralExpression<double>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDoubleElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDoubleElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyDoubleElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableDoubleCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="NullableDoubleElement"/>.</returns>
        public static NullableDoubleCoalesceFunctionExpression Coalesce(AnyDoubleElement element1, AnyDoubleElement element2, AnyDoubleElement element3, double? value)
            => new NullableDoubleCoalesceFunctionExpression(new List<AnyDoubleElement> { element1, element2, element3, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDoubleElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDoubleElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyDoubleElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element4">An expression of type <see cref="AnyDoubleElement"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyDoubleElement"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> evaluate to a (database) NULL, the first non (database) NULL value in this list will be returned.</param>
        /// <returns><see cref="NullableDoubleCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="NullableDoubleElement"/>.</returns>
        public static NullableDoubleCoalesceFunctionExpression Coalesce(AnyDoubleElement element1, AnyDoubleElement element2, AnyDoubleElement element3, AnyDoubleElement element4, params AnyDoubleElement[] elements)
            => new NullableDoubleCoalesceFunctionExpression(new List<AnyDoubleElement> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region decimal
        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDecimalElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DecimalCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="DecimalElement"/>.</returns>
        public static DecimalCoalesceFunctionExpression Coalesce(AnyDecimalElement element, decimal value)
            => new DecimalCoalesceFunctionExpression(new List<AnyDecimalElement> { element, new DecimalExpressionMediator(new LiteralExpression<decimal>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDecimalElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDecimalCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="NullableDecimalElement"/>.</returns>
        public static NullableDecimalCoalesceFunctionExpression Coalesce(AnyDecimalElement element1, decimal? value)
            => new NullableDecimalCoalesceFunctionExpression(new List<AnyDecimalElement> { element1, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDecimalElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="DecimalElement"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDecimalCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="NullableDecimalElement"/>.</returns>
        public static NullableDecimalCoalesceFunctionExpression Coalesce(AnyDecimalElement element1, DecimalElement element2)
            => new NullableDecimalCoalesceFunctionExpression(new List<AnyDecimalElement> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDecimalElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableDecimalElement"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDecimalCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="NullableDecimalElement"/>.</returns>
        public static NullableDecimalCoalesceFunctionExpression Coalesce(AnyDecimalElement element1, NullableDecimalElement element2)
            => new NullableDecimalCoalesceFunctionExpression(new List<AnyDecimalElement> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDecimalElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDecimalElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="DecimalCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="DecimalElement"/>.</returns>
        public static DecimalCoalesceFunctionExpression Coalesce(AnyDecimalElement element1, AnyDecimalElement element2, decimal value)
            => new DecimalCoalesceFunctionExpression(new List<AnyDecimalElement> { element1, element2, new DecimalExpressionMediator(new LiteralExpression<decimal>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDecimalElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDecimalElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableDecimalCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="NullableDecimalElement"/>.</returns>
        public static NullableDecimalCoalesceFunctionExpression Coalesce(AnyDecimalElement element1, AnyDecimalElement element2, decimal? value)
            => new NullableDecimalCoalesceFunctionExpression(new List<AnyDecimalElement> { element1, element2, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDecimalElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDecimalElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="DecimalElement"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableDecimalCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="NullableDecimalElement"/>.</returns>
        public static NullableDecimalCoalesceFunctionExpression Coalesce(AnyDecimalElement element1, AnyDecimalElement element2, DecimalElement element3)
            => new NullableDecimalCoalesceFunctionExpression(new List<AnyDecimalElement> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDecimalElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDecimalElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="NullableDecimalElement"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableDecimalCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="NullableDecimalElement"/>.</returns>
        public static NullableDecimalCoalesceFunctionExpression Coalesce(AnyDecimalElement element1, AnyDecimalElement element2, NullableDecimalElement element3)
            => new NullableDecimalCoalesceFunctionExpression(new List<AnyDecimalElement> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDecimalElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDecimalElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyDecimalElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="DecimalCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="DecimalElement"/>.</returns>
        public static DecimalCoalesceFunctionExpression Coalesce(AnyDecimalElement element1, AnyDecimalElement element2, AnyDecimalElement element3, decimal value)
            => new DecimalCoalesceFunctionExpression(new List<AnyDecimalElement> { element1, element2, element3, new DecimalExpressionMediator(new LiteralExpression<decimal>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDecimalElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDecimalElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyDecimalElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableDecimalCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="NullableDecimalElement"/>.</returns>
        public static NullableDecimalCoalesceFunctionExpression Coalesce(AnyDecimalElement element1, AnyDecimalElement element2, AnyDecimalElement element3, decimal? value)
            => new NullableDecimalCoalesceFunctionExpression(new List<AnyDecimalElement> { element1, element2, element3, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyDecimalElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyDecimalElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyDecimalElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element4">An expression of type <see cref="AnyDecimalElement"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyDecimalElement"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> evaluate to a (database) NULL, the first non (database) NULL value in this list will be returned.</param>
        /// <returns><see cref="NullableDecimalCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="NullableDecimalElement"/>.</returns>
        public static NullableDecimalCoalesceFunctionExpression Coalesce(AnyDecimalElement element1, AnyDecimalElement element2, AnyDecimalElement element3, AnyDecimalElement element4, params AnyDecimalElement[] elements)
            => new NullableDecimalCoalesceFunctionExpression(new List<AnyDecimalElement> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region Enum
        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="EnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyEnumElement{TEnum}"/> or <see cref="EnumElement{TEnum}"/>.</returns>
        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(AnyEnumElement<TEnum> element, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<AnyEnumElement<TEnum>> { element, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyEnumElement{TEnum}"/> or <see cref="NullableEnumElement{TEnum}"/>.</returns>
        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(AnyEnumElement<TEnum> element1, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<AnyEnumElement<TEnum>> { element1, new NullableEnumExpressionMediator<TEnum>(new LiteralExpression<TEnum?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="EnumElement{TEnum}"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyEnumElement{TEnum}"/> or <see cref="NullableEnumElement{TEnum}"/>.</returns>
        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(AnyEnumElement<TEnum> element1, EnumElement<TEnum> element2)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<AnyEnumElement<TEnum>> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableEnumElement{TEnum}"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyEnumElement{TEnum}"/> or <see cref="NullableEnumElement{TEnum}"/>.</returns>
        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(AnyEnumElement<TEnum> element1, NullableEnumElement<TEnum> element2)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<AnyEnumElement<TEnum>> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="EnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyEnumElement{TEnum}"/> or <see cref="EnumElement{TEnum}"/>.</returns>
        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(AnyEnumElement<TEnum> element1, AnyEnumElement<TEnum> element2, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<AnyEnumElement<TEnum>> { element1, element2, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyEnumElement{TEnum}"/> or <see cref="NullableEnumElement{TEnum}"/>.</returns>
        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(AnyEnumElement<TEnum> element1, AnyEnumElement<TEnum> element2, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<AnyEnumElement<TEnum>> { element1, element2, new NullableEnumExpressionMediator<TEnum>(new LiteralExpression<TEnum?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="EnumElement{TEnum}"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyEnumElement{TEnum}"/> or <see cref="NullableEnumElement{TEnum}"/>.</returns>
        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(AnyEnumElement<TEnum> element1, AnyEnumElement<TEnum> element2, EnumElement<TEnum> element3)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<AnyEnumElement<TEnum>> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="NullableEnumElement{TEnum}"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyEnumElement{TEnum}"/> or <see cref="NullableEnumElement{TEnum}"/>.</returns>
        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(AnyEnumElement<TEnum> element1, AnyEnumElement<TEnum> element2, NullableEnumElement<TEnum> element3)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<AnyEnumElement<TEnum>> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="EnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyEnumElement{TEnum}"/> or <see cref="EnumElement{TEnum}"/>.</returns>
        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(AnyEnumElement<TEnum> element1, AnyEnumElement<TEnum> element2, AnyEnumElement<TEnum> element3, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<AnyEnumElement<TEnum>> { element1, element2, element3, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyEnumElement{TEnum}"/> or <see cref="NullableEnumElement{TEnum}"/>.</returns>
        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(AnyEnumElement<TEnum> element1, AnyEnumElement<TEnum> element2, AnyEnumElement<TEnum> element3, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<AnyEnumElement<TEnum>> { element1, element2, element3, new NullableEnumExpressionMediator<TEnum>(new LiteralExpression<TEnum?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element4">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyEnumElement{TEnum}"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> evaluate to a (database) NULL, the first non (database) NULL value in this list will be returned.</param>
        /// <returns><see cref="NullableEnumCoalesceFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyEnumElement{TEnum}"/> or <see cref="NullableEnumElement{TEnum}"/>.</returns>
        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(AnyEnumElement<TEnum> element1, AnyEnumElement<TEnum> element2, AnyEnumElement<TEnum> element3, AnyEnumElement<TEnum> element4, params AnyEnumElement<TEnum>[] elements)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<AnyEnumElement<TEnum>> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region float
        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnySingleElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="SingleCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleCoalesceFunctionExpression Coalesce(AnySingleElement element, float value)
            => new SingleCoalesceFunctionExpression(new List<AnySingleElement> { element, new SingleExpressionMediator(new LiteralExpression<float>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnySingleElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableSingleCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleCoalesceFunctionExpression Coalesce(AnySingleElement element1, float? value)
            => new NullableSingleCoalesceFunctionExpression(new List<AnySingleElement> { element1, new NullableSingleExpressionMediator(new LiteralExpression<float?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnySingleElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="SingleElement"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableSingleCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleCoalesceFunctionExpression Coalesce(AnySingleElement element1, SingleElement element2)
            => new NullableSingleCoalesceFunctionExpression(new List<AnySingleElement> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnySingleElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableSingleElement"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableSingleCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleCoalesceFunctionExpression Coalesce(AnySingleElement element1, NullableSingleElement element2)
            => new NullableSingleCoalesceFunctionExpression(new List<AnySingleElement> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnySingleElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnySingleElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="SingleCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleCoalesceFunctionExpression Coalesce(AnySingleElement element1, AnySingleElement element2, float value)
            => new SingleCoalesceFunctionExpression(new List<AnySingleElement> { element1, element2, new SingleExpressionMediator(new LiteralExpression<float>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnySingleElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnySingleElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableSingleCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleCoalesceFunctionExpression Coalesce(AnySingleElement element1, AnySingleElement element2, float? value)
            => new NullableSingleCoalesceFunctionExpression(new List<AnySingleElement> { element1, element2, new NullableSingleExpressionMediator(new LiteralExpression<float?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnySingleElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnySingleElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="SingleElement"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableSingleCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleCoalesceFunctionExpression Coalesce(AnySingleElement element1, AnySingleElement element2, SingleElement element3)
            => new NullableSingleCoalesceFunctionExpression(new List<AnySingleElement> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnySingleElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnySingleElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="NullableSingleElement"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableSingleCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleCoalesceFunctionExpression Coalesce(AnySingleElement element1, AnySingleElement element2, NullableSingleElement element3)
            => new NullableSingleCoalesceFunctionExpression(new List<AnySingleElement> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnySingleElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnySingleElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnySingleElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="SingleCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleCoalesceFunctionExpression Coalesce(AnySingleElement element1, AnySingleElement element2, AnySingleElement element3, float value)
            => new SingleCoalesceFunctionExpression(new List<AnySingleElement> { element1, element2, element3, new SingleExpressionMediator(new LiteralExpression<float>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnySingleElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnySingleElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnySingleElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableSingleCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleCoalesceFunctionExpression Coalesce(AnySingleElement element1, AnySingleElement element2, AnySingleElement element3, float? value)
            => new NullableSingleCoalesceFunctionExpression(new List<AnySingleElement> { element1, element2, element3, new NullableSingleExpressionMediator(new LiteralExpression<float?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnySingleElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnySingleElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnySingleElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element4">An expression of type <see cref="AnySingleElement"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnySingleElement"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> evaluate to a (database) NULL, the first non (database) NULL value in this list will be returned.</param>
        /// <returns><see cref="NullableSingleCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleCoalesceFunctionExpression Coalesce(AnySingleElement element1, AnySingleElement element2, AnySingleElement element3, AnySingleElement element4, params AnySingleElement[] elements)
            => new NullableSingleCoalesceFunctionExpression(new List<AnySingleElement> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region Guid
        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyGuidElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="GuidCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyGuidElement"/> or <see cref="GuidElement"/>.</returns>
        public static GuidCoalesceFunctionExpression Coalesce(AnyGuidElement element, Guid value)
            => new GuidCoalesceFunctionExpression(new List<AnyGuidElement> { element, new GuidExpressionMediator(new LiteralExpression<Guid>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyGuidElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableGuidCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyGuidElement"/> or <see cref="NullableGuidElement"/>.</returns>
        public static NullableGuidCoalesceFunctionExpression Coalesce(AnyGuidElement element1, Guid? value)
            => new NullableGuidCoalesceFunctionExpression(new List<AnyGuidElement> { element1, new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyGuidElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="GuidElement"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableGuidCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyGuidElement"/> or <see cref="NullableGuidElement"/>.</returns>
        public static NullableGuidCoalesceFunctionExpression Coalesce(AnyGuidElement element1, GuidElement element2)
            => new NullableGuidCoalesceFunctionExpression(new List<AnyGuidElement> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyGuidElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableGuidElement"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableGuidCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyGuidElement"/> or <see cref="NullableGuidElement"/>.</returns>
        public static NullableGuidCoalesceFunctionExpression Coalesce(AnyGuidElement element1, NullableGuidElement element2)
            => new NullableGuidCoalesceFunctionExpression(new List<AnyGuidElement> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyGuidElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyGuidElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="GuidCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyGuidElement"/> or <see cref="GuidElement"/>.</returns>
        public static GuidCoalesceFunctionExpression Coalesce(AnyGuidElement element1, AnyGuidElement element2, Guid value)
            => new GuidCoalesceFunctionExpression(new List<AnyGuidElement> { element1, element2, new GuidExpressionMediator(new LiteralExpression<Guid>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyGuidElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyGuidElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableGuidCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyGuidElement"/> or <see cref="NullableGuidElement"/>.</returns>
        public static NullableGuidCoalesceFunctionExpression Coalesce(AnyGuidElement element1, AnyGuidElement element2, Guid? value)
            => new NullableGuidCoalesceFunctionExpression(new List<AnyGuidElement> { element1, element2, new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyGuidElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyGuidElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="GuidElement"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableGuidCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyGuidElement"/> or <see cref="NullableGuidElement"/>.</returns>
        public static NullableGuidCoalesceFunctionExpression Coalesce(AnyGuidElement element1, AnyGuidElement element2, GuidElement element3)
            => new NullableGuidCoalesceFunctionExpression(new List<AnyGuidElement> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyGuidElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyGuidElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="NullableGuidElement"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableGuidCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyGuidElement"/> or <see cref="NullableGuidElement"/>.</returns>
        public static NullableGuidCoalesceFunctionExpression Coalesce(AnyGuidElement element1, AnyGuidElement element2, NullableGuidElement element3)
            => new NullableGuidCoalesceFunctionExpression(new List<AnyGuidElement> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyGuidElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyGuidElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyGuidElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="GuidCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyGuidElement"/> or <see cref="GuidElement"/>.</returns>
        public static GuidCoalesceFunctionExpression Coalesce(AnyGuidElement element1, AnyGuidElement element2, AnyGuidElement element3, Guid value)
            => new GuidCoalesceFunctionExpression(new List<AnyGuidElement> { element1, element2, element3, new GuidExpressionMediator(new LiteralExpression<Guid>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyGuidElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyGuidElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyGuidElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableGuidCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyGuidElement"/> or <see cref="NullableGuidElement"/>.</returns>
        public static NullableGuidCoalesceFunctionExpression Coalesce(AnyGuidElement element1, AnyGuidElement element2, AnyGuidElement element3, Guid? value)
            => new NullableGuidCoalesceFunctionExpression(new List<AnyGuidElement> { element1, element2, element3, new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyGuidElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyGuidElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyGuidElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element4">An expression of type <see cref="AnyGuidElement"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyGuidElement"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> evaluate to a (database) NULL, the first non (database) NULL value in this list will be returned.</param>
        /// <returns><see cref="NullableGuidCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyGuidElement"/> or <see cref="NullableGuidElement"/>.</returns>
        public static NullableGuidCoalesceFunctionExpression Coalesce(AnyGuidElement element1, AnyGuidElement element2, AnyGuidElement element3, AnyGuidElement element4, params AnyGuidElement[] elements)
            => new NullableGuidCoalesceFunctionExpression(new List<AnyGuidElement> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region short
        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyInt16Element"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int16CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="Int16Element"/>.</returns>
        public static Int16CoalesceFunctionExpression Coalesce(AnyInt16Element element, short value)
            => new Int16CoalesceFunctionExpression(new List<AnyInt16Element> { element, new Int16ExpressionMediator(new LiteralExpression<short>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyInt16Element"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt16CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="NullableInt16Element"/>.</returns>
        public static NullableInt16CoalesceFunctionExpression Coalesce(AnyInt16Element element1, short? value)
            => new NullableInt16CoalesceFunctionExpression(new List<AnyInt16Element> { element1, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt16Element"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="Int16Element"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt16CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="NullableInt16Element"/>.</returns>
        public static NullableInt16CoalesceFunctionExpression Coalesce(AnyInt16Element element1, Int16Element element2)
            => new NullableInt16CoalesceFunctionExpression(new List<AnyInt16Element> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt16Element"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableInt16Element"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt16CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="NullableInt16Element"/>.</returns>
        public static NullableInt16CoalesceFunctionExpression Coalesce(AnyInt16Element element1, NullableInt16Element element2)
            => new NullableInt16CoalesceFunctionExpression(new List<AnyInt16Element> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt16Element"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyInt16Element"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="Int16CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="Int16Element"/>.</returns>
        public static Int16CoalesceFunctionExpression Coalesce(AnyInt16Element element1, AnyInt16Element element2, short value)
            => new Int16CoalesceFunctionExpression(new List<AnyInt16Element> { element1, element2, new Int16ExpressionMediator(new LiteralExpression<short>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt16Element"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyInt16Element"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableInt16CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="NullableInt16Element"/>.</returns>
        public static NullableInt16CoalesceFunctionExpression Coalesce(AnyInt16Element element1, AnyInt16Element element2, short? value)
            => new NullableInt16CoalesceFunctionExpression(new List<AnyInt16Element> { element1, element2, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt16Element"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyInt16Element"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="Int16Element"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableInt16CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="NullableInt16Element"/>.</returns>
        public static NullableInt16CoalesceFunctionExpression Coalesce(AnyInt16Element element1, AnyInt16Element element2, Int16Element element3)
            => new NullableInt16CoalesceFunctionExpression(new List<AnyInt16Element> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt16Element"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyInt16Element"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="NullableInt16Element"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableInt16CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="NullableInt16Element"/>.</returns>
        public static NullableInt16CoalesceFunctionExpression Coalesce(AnyInt16Element element1, AnyInt16Element element2, NullableInt16Element element3)
            => new NullableInt16CoalesceFunctionExpression(new List<AnyInt16Element> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt16Element"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyInt16Element"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyInt16Element"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="Int16CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="Int16Element"/>.</returns>
        public static Int16CoalesceFunctionExpression Coalesce(AnyInt16Element element1, AnyInt16Element element2, AnyInt16Element element3, short value)
            => new Int16CoalesceFunctionExpression(new List<AnyInt16Element> { element1, element2, element3, new Int16ExpressionMediator(new LiteralExpression<short>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt16Element"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyInt16Element"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyInt16Element"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableInt16CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="NullableInt16Element"/>.</returns>
        public static NullableInt16CoalesceFunctionExpression Coalesce(AnyInt16Element element1, AnyInt16Element element2, AnyInt16Element element3, short? value)
            => new NullableInt16CoalesceFunctionExpression(new List<AnyInt16Element> { element1, element2, element3, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt16Element"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyInt16Element"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyInt16Element"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element4">An expression of type <see cref="AnyInt16Element"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyInt16Element"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> evaluate to a (database) NULL, the first non (database) NULL value in this list will be returned.</param>
        /// <returns><see cref="NullableInt16CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="NullableInt16Element"/>.</returns>
        public static NullableInt16CoalesceFunctionExpression Coalesce(AnyInt16Element element1, AnyInt16Element element2, AnyInt16Element element3, AnyInt16Element element4, params AnyInt16Element[] elements)
            => new NullableInt16CoalesceFunctionExpression(new List<AnyInt16Element> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region int
        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyInt32Element"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int32CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32CoalesceFunctionExpression Coalesce(AnyInt32Element element, int value)
            => new Int32CoalesceFunctionExpression(new List<AnyInt32Element> { element, new Int32ExpressionMediator(new LiteralExpression<int>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyInt32Element"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt32CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32CoalesceFunctionExpression Coalesce(AnyInt32Element element1, int? value)
            => new NullableInt32CoalesceFunctionExpression(new List<AnyInt32Element> { element1, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt32Element"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="Int32Element"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt32CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32CoalesceFunctionExpression Coalesce(AnyInt32Element element1, Int32Element element2)
            => new NullableInt32CoalesceFunctionExpression(new List<AnyInt32Element> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt32Element"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableInt32Element"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt32CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32CoalesceFunctionExpression Coalesce(AnyInt32Element element1, NullableInt32Element element2)
            => new NullableInt32CoalesceFunctionExpression(new List<AnyInt32Element> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt32Element"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyInt32Element"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="Int32CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32CoalesceFunctionExpression Coalesce(AnyInt32Element element1, AnyInt32Element element2, int value)
            => new Int32CoalesceFunctionExpression(new List<AnyInt32Element> { element1, element2, new Int32ExpressionMediator(new LiteralExpression<int>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt32Element"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyInt32Element"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableInt32CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32CoalesceFunctionExpression Coalesce(AnyInt32Element element1, AnyInt32Element element2, int? value)
            => new NullableInt32CoalesceFunctionExpression(new List<AnyInt32Element> { element1, element2, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt32Element"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyInt32Element"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="Int32Element"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableInt32CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32CoalesceFunctionExpression Coalesce(AnyInt32Element element1, AnyInt32Element element2, Int32Element element3)
            => new NullableInt32CoalesceFunctionExpression(new List<AnyInt32Element> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt32Element"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyInt32Element"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="NullableInt32Element"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableInt32CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32CoalesceFunctionExpression Coalesce(AnyInt32Element element1, AnyInt32Element element2, NullableInt32Element element3)
            => new NullableInt32CoalesceFunctionExpression(new List<AnyInt32Element> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt32Element"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyInt32Element"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyInt32Element"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="Int32CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32CoalesceFunctionExpression Coalesce(AnyInt32Element element1, AnyInt32Element element2, AnyInt32Element element3, int value)
            => new Int32CoalesceFunctionExpression(new List<AnyInt32Element> { element1, element2, element3, new Int32ExpressionMediator(new LiteralExpression<int>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt32Element"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyInt32Element"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyInt32Element"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableInt32CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32CoalesceFunctionExpression Coalesce(AnyInt32Element element1, AnyInt32Element element2, AnyInt32Element element3, int? value)
            => new NullableInt32CoalesceFunctionExpression(new List<AnyInt32Element> { element1, element2, element3, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt32Element"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyInt32Element"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyInt32Element"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element4">An expression of type <see cref="AnyInt32Element"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyInt32Element"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> evaluate to a (database) NULL, the first non (database) NULL value in this list will be returned.</param>
        /// <returns><see cref="NullableInt32CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32CoalesceFunctionExpression Coalesce(AnyInt32Element element1, AnyInt32Element element2, AnyInt32Element element3, AnyInt32Element element4, params AnyInt32Element[] elements)
            => new NullableInt32CoalesceFunctionExpression(new List<AnyInt32Element> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region long
        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyInt64Element"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int64CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="Int64Element"/>.</returns>
        public static Int64CoalesceFunctionExpression Coalesce(AnyInt64Element element, long value)
            => new Int64CoalesceFunctionExpression(new List<AnyInt64Element> { element, new Int64ExpressionMediator(new LiteralExpression<long>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyInt64Element"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt64CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="NullableInt64Element"/>.</returns>
        public static NullableInt64CoalesceFunctionExpression Coalesce(AnyInt64Element element1, long? value)
            => new NullableInt64CoalesceFunctionExpression(new List<AnyInt64Element> { element1, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt64Element"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="Int64Element"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt64CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="NullableInt64Element"/>.</returns>
        public static NullableInt64CoalesceFunctionExpression Coalesce(AnyInt64Element element1, Int64Element element2)
            => new NullableInt64CoalesceFunctionExpression(new List<AnyInt64Element> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt64Element"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableInt64Element"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt64CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="NullableInt64Element"/>.</returns>
        public static NullableInt64CoalesceFunctionExpression Coalesce(AnyInt64Element element1, NullableInt64Element element2)
            => new NullableInt64CoalesceFunctionExpression(new List<AnyInt64Element> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt64Element"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyInt64Element"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="Int64CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="Int64Element"/>.</returns>
        public static Int64CoalesceFunctionExpression Coalesce(AnyInt64Element element1, AnyInt64Element element2, long value)
            => new Int64CoalesceFunctionExpression(new List<AnyInt64Element> { element1, element2, new Int64ExpressionMediator(new LiteralExpression<long>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt64Element"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyInt64Element"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableInt64CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="NullableInt64Element"/>.</returns>
        public static NullableInt64CoalesceFunctionExpression Coalesce(AnyInt64Element element1, AnyInt64Element element2, long? value)
            => new NullableInt64CoalesceFunctionExpression(new List<AnyInt64Element> { element1, element2, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt64Element"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyInt64Element"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="Int64Element"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableInt64CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="NullableInt64Element"/>.</returns>
        public static NullableInt64CoalesceFunctionExpression Coalesce(AnyInt64Element element1, AnyInt64Element element2, Int64Element element3)
            => new NullableInt64CoalesceFunctionExpression(new List<AnyInt64Element> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt64Element"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyInt64Element"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="NullableInt64Element"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableInt64CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="NullableInt64Element"/>.</returns>
        public static NullableInt64CoalesceFunctionExpression Coalesce(AnyInt64Element element1, AnyInt64Element element2, NullableInt64Element element3)
            => new NullableInt64CoalesceFunctionExpression(new List<AnyInt64Element> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt64Element"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyInt64Element"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyInt64Element"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="Int64CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="Int64Element"/>.</returns>
        public static Int64CoalesceFunctionExpression Coalesce(AnyInt64Element element1, AnyInt64Element element2, AnyInt64Element element3, long value)
            => new Int64CoalesceFunctionExpression(new List<AnyInt64Element> { element1, element2, element3, new Int64ExpressionMediator(new LiteralExpression<long>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt64Element"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyInt64Element"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyInt64Element"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableInt64CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="NullableInt64Element"/>.</returns>
        public static NullableInt64CoalesceFunctionExpression Coalesce(AnyInt64Element element1, AnyInt64Element element2, AnyInt64Element element3, long? value)
            => new NullableInt64CoalesceFunctionExpression(new List<AnyInt64Element> { element1, element2, element3, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyInt64Element"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyInt64Element"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyInt64Element"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element4">An expression of type <see cref="AnyInt64Element"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyInt64Element"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> evaluate to a (database) NULL, the first non (database) NULL value in this list will be returned.</param>
        /// <returns><see cref="NullableInt64CoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="NullableInt64Element"/>.</returns>
        public static NullableInt64CoalesceFunctionExpression Coalesce(AnyInt64Element element1, AnyInt64Element element2, AnyInt64Element element3, AnyInt64Element element4, params AnyInt64Element[] elements)
            => new NullableInt64CoalesceFunctionExpression(new List<AnyInt64Element> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region string
        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyStringElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="StringCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="StringElement"/>.</returns>
        public static StringCoalesceFunctionExpression Coalesce(AnyStringElement element, string value)
            => new StringCoalesceFunctionExpression(new List<AnyStringElement> { element, new StringExpressionMediator(new LiteralExpression<string>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyStringElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="StringElement"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableStringCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="NullableStringElement"/>.</returns>
        public static NullableStringCoalesceFunctionExpression Coalesce(AnyStringElement element1, StringElement element2)
            => new NullableStringCoalesceFunctionExpression(new List<AnyStringElement> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyStringElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableStringElement"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableStringCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="NullableStringElement"/>.</returns>
        public static NullableStringCoalesceFunctionExpression Coalesce(AnyStringElement element1, NullableStringElement element2)
            => new NullableStringCoalesceFunctionExpression(new List<AnyStringElement> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyStringElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyStringElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="StringCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="StringElement"/>.</returns>
        public static StringCoalesceFunctionExpression Coalesce(AnyStringElement element1, AnyStringElement element2, string value)
            => new StringCoalesceFunctionExpression(new List<AnyStringElement> { element1, element2, new StringExpressionMediator(new LiteralExpression<string>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyStringElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyStringElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="StringElement"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableStringCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="NullableStringElement"/>.</returns>
        public static NullableStringCoalesceFunctionExpression Coalesce(AnyStringElement element1, AnyStringElement element2, StringElement element3)
            => new NullableStringCoalesceFunctionExpression(new List<AnyStringElement> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyStringElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyStringElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="NullableStringElement"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableStringCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="NullableStringElement"/>.</returns>
        public static NullableStringCoalesceFunctionExpression Coalesce(AnyStringElement element1, AnyStringElement element2, NullableStringElement element3)
            => new NullableStringCoalesceFunctionExpression(new List<AnyStringElement> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyStringElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyStringElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyStringElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="StringCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="StringElement"/>.</returns>
        public static StringCoalesceFunctionExpression Coalesce(AnyStringElement element1, AnyStringElement element2, AnyStringElement element3, string value)
            => new StringCoalesceFunctionExpression(new List<AnyStringElement> { element1, element2, element3, new StringExpressionMediator(new LiteralExpression<string>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyStringElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyStringElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyStringElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element4">An expression of type <see cref="AnyStringElement"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyStringElement"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> evaluate to a (database) NULL, the first non (database) NULL value in this list will be returned.</param>
        /// <returns><see cref="NullableStringCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="NullableStringElement"/>.</returns>
        public static NullableStringCoalesceFunctionExpression Coalesce(AnyStringElement element1, AnyStringElement element2, AnyStringElement element3, AnyStringElement element4, params AnyStringElement[] elements)
            => new NullableStringCoalesceFunctionExpression(new List<AnyStringElement> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region TimeSpan
        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyTimeSpanElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="TimeSpanCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyTimeSpanElement"/> or <see cref="TimeSpanElement"/>.</returns>
        public static TimeSpanCoalesceFunctionExpression Coalesce(AnyTimeSpanElement element, TimeSpan value)
            => new TimeSpanCoalesceFunctionExpression(new List<AnyTimeSpanElement> { element, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyTimeSpanElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableTimeSpanCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyTimeSpanElement"/> or <see cref="NullableTimeSpanElement"/>.</returns>
        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(AnyTimeSpanElement element1, TimeSpan? value)
            => new NullableTimeSpanCoalesceFunctionExpression(new List<AnyTimeSpanElement> { element1, new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyTimeSpanElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="TimeSpanElement"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableTimeSpanCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyTimeSpanElement"/> or <see cref="NullableTimeSpanElement"/>.</returns>
        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(AnyTimeSpanElement element1, TimeSpanElement element2)
            => new NullableTimeSpanCoalesceFunctionExpression(new List<AnyTimeSpanElement> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyTimeSpanElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="NullableTimeSpanElement"/>, the returned value if <paramref name="element1"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableTimeSpanCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyTimeSpanElement"/> or <see cref="NullableTimeSpanElement"/>.</returns>
        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(AnyTimeSpanElement element1, NullableTimeSpanElement element2)
            => new NullableTimeSpanCoalesceFunctionExpression(new List<AnyTimeSpanElement> { element1 }, element2);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyTimeSpanElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyTimeSpanElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="TimeSpanCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyTimeSpanElement"/> or <see cref="TimeSpanElement"/>.</returns>
        public static TimeSpanCoalesceFunctionExpression Coalesce(AnyTimeSpanElement element1, AnyTimeSpanElement element2, TimeSpan value)
            => new TimeSpanCoalesceFunctionExpression(new List<AnyTimeSpanElement> { element1, element2, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyTimeSpanElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyTimeSpanElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableTimeSpanCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyTimeSpanElement"/> or <see cref="NullableTimeSpanElement"/>.</returns>
        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(AnyTimeSpanElement element1, AnyTimeSpanElement element2, TimeSpan? value)
            => new NullableTimeSpanCoalesceFunctionExpression(new List<AnyTimeSpanElement> { element1, element2, new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyTimeSpanElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyTimeSpanElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="TimeSpanElement"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableTimeSpanCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyTimeSpanElement"/> or <see cref="NullableTimeSpanElement"/>.</returns>
        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(AnyTimeSpanElement element1, AnyTimeSpanElement element2, TimeSpanElement element3)
            => new NullableTimeSpanCoalesceFunctionExpression(new List<AnyTimeSpanElement> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyTimeSpanElement"/>, if this value evaluates to a (database) NULL, <paramref name="element2"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyTimeSpanElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="NullableTimeSpanElement"/>, the returned value if <paramref name="element1"/> and <paramref name="element2"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableTimeSpanCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyTimeSpanElement"/> or <see cref="NullableTimeSpanElement"/>.</returns>
        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(AnyTimeSpanElement element1, AnyTimeSpanElement element2, NullableTimeSpanElement element3)
            => new NullableTimeSpanCoalesceFunctionExpression(new List<AnyTimeSpanElement> { element1, element2 }, element3);

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyTimeSpanElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyTimeSpanElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyTimeSpanElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="TimeSpanCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyTimeSpanElement"/> or <see cref="TimeSpanElement"/>.</returns>
        public static TimeSpanCoalesceFunctionExpression Coalesce(AnyTimeSpanElement element1, AnyTimeSpanElement element2, AnyTimeSpanElement element3, TimeSpan value)
            => new TimeSpanCoalesceFunctionExpression(new List<AnyTimeSpanElement> { element1, element2, element3, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyTimeSpanElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyTimeSpanElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyTimeSpanElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element1"/>, <paramref name="element2"/> and <paramref name="element3"/> evaluate to a (database) NULL.</param>
        /// <returns><see cref="NullableTimeSpanCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyTimeSpanElement"/> or <see cref="NullableTimeSpanElement"/>.</returns>
        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(AnyTimeSpanElement element1, AnyTimeSpanElement element2, AnyTimeSpanElement element3, TimeSpan? value)
            => new NullableTimeSpanCoalesceFunctionExpression(new List<AnyTimeSpanElement> { element1, element2, element3, new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(value)) });

        /// <summary>
        /// Construct an expression for the COALESCE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/language-elements/coalesce-transact-sql">Microsoft docs on COALESCE</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyTimeSpanElement"/>, if this value evaluates to a (database) NULL, the first non (database) NULL of <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element2">An expression of type <see cref="AnyTimeSpanElement"/>, if <paramref name="element1"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/>, <paramref name="element4"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element3">An expression of type <see cref="AnyTimeSpanElement"/>, if <paramref name="element1"/>, <paramref name="element2"/> and this evaluate to a (database) NULL, the first non (database) NULL of <paramref name="element3"/> and <paramref name="value"/> will be returned.</param>
        /// <param name="element4">An expression of type <see cref="AnyTimeSpanElement"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/> and this evaluate to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyTimeSpanElement"/>, if <paramref name="element1"/>, <paramref name="element2"/>, <paramref name="element3"/>, <paramref name="element4"/> evaluate to a (database) NULL, the first non (database) NULL value in this list will be returned.</param>
        /// <returns><see cref="NullableTimeSpanCoalesceFunctionExpression"/> for use with any operation accepting a <see cref="AnyTimeSpanElement"/> or <see cref="NullableTimeSpanElement"/>.</returns>
        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(AnyTimeSpanElement element1, AnyTimeSpanElement element2, AnyTimeSpanElement element3, AnyTimeSpanElement element4, params AnyTimeSpanElement[] elements)
            => new NullableTimeSpanCoalesceFunctionExpression(new List<AnyTimeSpanElement> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion
        #endregion

        #region isnull
        #region object
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyObjectElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyObjectElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="ObjectIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyObjectElement"/>.</returns>
        public static ObjectIsNullFunctionExpression IsNull(AnyObjectElement element1, AnyObjectElement element2)
            => new ObjectIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyObjectElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="ObjectIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyObjectElement"/>.</returns>
        public static ObjectIsNullFunctionExpression IsNull(AnyObjectElement element, object value)
            => new ObjectIsNullFunctionExpression(element, new ObjectExpressionMediator(new LiteralExpression<object>(value)));
        #endregion

        #region bool
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyBooleanElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="BooleanElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="BooleanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyBooleanElement"/> or <see cref="BooleanElement"/>.</returns>
        public static BooleanIsNullFunctionExpression IsNull(AnyBooleanElement element1, BooleanElement element2)
            => new BooleanIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyBooleanElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="NullableBooleanElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableBooleanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyBooleanElement"/> or <see cref="NullableBooleanElement"/>.</returns>
        public static NullableBooleanIsNullFunctionExpression IsNull(AnyBooleanElement element1, NullableBooleanElement element2)
            => new NullableBooleanIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyBooleanElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="BooleanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyBooleanElement"/> or <see cref="BooleanElement"/>.</returns>
        public static BooleanIsNullFunctionExpression IsNull(AnyBooleanElement element, bool value)
            => new BooleanIsNullFunctionExpression(element, new BooleanExpressionMediator(new LiteralExpression<bool>(value)));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyBooleanElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableBooleanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyBooleanElement"/> or <see cref="NullableBooleanElement"/>.</returns>
        public static NullableBooleanIsNullFunctionExpression IsNull(AnyBooleanElement element, bool? value)
            => new NullableBooleanIsNullFunctionExpression(element, new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(value)));
        #endregion

        #region byte
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyByteElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="ByteElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="ByteIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="ByteElement"/>.</returns>
        public static ByteIsNullFunctionExpression IsNull(AnyByteElement element1, ByteElement element2)
            => new ByteIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyByteElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="NullableByteElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableByteIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="NullableByteElement"/>.</returns>
        public static NullableByteIsNullFunctionExpression IsNull(AnyByteElement element1, NullableByteElement element2)
            => new NullableByteIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyByteElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="ByteIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="ByteElement"/>.</returns>
        public static ByteIsNullFunctionExpression IsNull(AnyByteElement element, byte value)
            => new ByteIsNullFunctionExpression(element, new ByteExpressionMediator(new LiteralExpression<byte>(value)));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyByteElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableByteIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="NullableByteElement"/>.</returns>
        public static NullableByteIsNullFunctionExpression IsNull(AnyByteElement element, byte? value)
            => new NullableByteIsNullFunctionExpression(element, new NullableByteExpressionMediator(new LiteralExpression<byte?>(value)));
        #endregion

        #region DateTime
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDateTimeElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="DateTimeElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DateTimeIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="DateTimeElement"/>.</returns>
        public static DateTimeIsNullFunctionExpression IsNull(AnyDateTimeElement element1, DateTimeElement element2)
            => new DateTimeIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDateTimeElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="NullableDateTimeElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="NullableDateTimeElement"/>.</returns>
        public static NullableDateTimeIsNullFunctionExpression IsNull(AnyDateTimeElement element1, NullableDateTimeElement element2)
            => new NullableDateTimeIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDateTimeElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DateTimeIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="DateTimeElement"/>.</returns>
        public static DateTimeIsNullFunctionExpression IsNull(AnyDateTimeElement element, DateTime value)
            => new DateTimeIsNullFunctionExpression(element, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(value)));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDateTimeElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="NullableDateTimeElement"/>.</returns>
        public static NullableDateTimeIsNullFunctionExpression IsNull(AnyDateTimeElement element, DateTime? value)
            => new NullableDateTimeIsNullFunctionExpression(element, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(value)));
        #endregion

        #region DateTimeOffset
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="DateTimeOffsetElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DateTimeOffsetIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="DateTimeOffsetElement"/>.</returns>
        public static DateTimeOffsetIsNullFunctionExpression IsNull(AnyDateTimeOffsetElement element1, DateTimeOffsetElement element2)
            => new DateTimeOffsetIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="NullableDateTimeOffsetElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeOffsetIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="NullableDateTimeOffsetElement"/>.</returns>
        public static NullableDateTimeOffsetIsNullFunctionExpression IsNull(AnyDateTimeOffsetElement element1, NullableDateTimeOffsetElement element2)
            => new NullableDateTimeOffsetIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DateTimeOffsetIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="DateTimeOffsetElement"/>.</returns>
        public static DateTimeOffsetIsNullFunctionExpression IsNull(AnyDateTimeOffsetElement element, DateTimeOffset value)
            => new DateTimeOffsetIsNullFunctionExpression(element, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(value)));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDateTimeOffsetElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeOffsetIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="NullableDateTimeOffsetElement"/>.</returns>
        public static NullableDateTimeOffsetIsNullFunctionExpression IsNull(AnyDateTimeOffsetElement element, DateTimeOffset? value)
            => new NullableDateTimeOffsetIsNullFunctionExpression(element, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(value)));
        #endregion

        #region decimal
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDecimalElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="DecimalElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DecimalIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="DecimalElement"/>.</returns>
        public static DecimalIsNullFunctionExpression IsNull(AnyDecimalElement element1, DecimalElement element2)
            => new DecimalIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDecimalElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="NullableDecimalElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDecimalIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="NullableDecimalElement"/>.</returns>
        public static NullableDecimalIsNullFunctionExpression IsNull(AnyDecimalElement element1, NullableDecimalElement element2)
            => new NullableDecimalIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDecimalElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DecimalIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="DecimalElement"/>.</returns>
        public static DecimalIsNullFunctionExpression IsNull(AnyDecimalElement element, decimal value)
            => new DecimalIsNullFunctionExpression(element, new DecimalExpressionMediator(new LiteralExpression<decimal>(value)));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDecimalElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDecimalIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="NullableDecimalElement"/>.</returns>
        public static NullableDecimalIsNullFunctionExpression IsNull(AnyDecimalElement element, decimal? value)
            => new NullableDecimalIsNullFunctionExpression(element, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(value)));
        #endregion

        #region double
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDoubleElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="DoubleElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DoubleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="DoubleElement"/>.</returns>
        public static DoubleIsNullFunctionExpression IsNull(AnyDoubleElement element1, DoubleElement element2)
            => new DoubleIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDoubleElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="NullableDoubleElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDoubleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="NullableDoubleElement"/>.</returns>
        public static NullableDoubleIsNullFunctionExpression IsNull(AnyDoubleElement element1, NullableDoubleElement element2)
            => new NullableDoubleIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDoubleElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DoubleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="DoubleElement"/>.</returns>
        public static DoubleIsNullFunctionExpression IsNull(AnyDoubleElement element, double value)
            => new DoubleIsNullFunctionExpression(element, new DoubleExpressionMediator(new LiteralExpression<double>(value)));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyDoubleElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDoubleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="NullableDoubleElement"/>.</returns>
        public static NullableDoubleIsNullFunctionExpression IsNull(AnyDoubleElement element, double? value)
            => new NullableDoubleIsNullFunctionExpression(element, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(value)));
        #endregion

        #region Enum
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="EnumElement{TEnum}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="EnumIsNullFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyEnumElement{TEnum}"/> or <see cref="EnumElement{TEnum}"/>.</returns>
        public static EnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(AnyEnumElement<TEnum> element1, EnumElement<TEnum> element2)
            where TEnum : struct, Enum, IComparable
            => new EnumIsNullFunctionExpression<TEnum>(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="NullableEnumElement{TEnum}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumIsNullFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyEnumElement{TEnum}"/> or <see cref="NullableEnumElement{TEnum}"/>.</returns>
        public static NullableEnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(AnyEnumElement<TEnum> element1, NullableEnumElement<TEnum> element2)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumIsNullFunctionExpression<TEnum>(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="EnumIsNullFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyEnumElement{TEnum}"/> or <see cref="EnumElement{TEnum}"/>.</returns>
        public static EnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(AnyEnumElement<TEnum> element, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumIsNullFunctionExpression<TEnum>(element, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyEnumElement{TEnum}"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumIsNullFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyEnumElement{TEnum}"/> or <see cref="NullableEnumElement{TEnum}"/>.</returns>
        public static NullableEnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(AnyEnumElement<TEnum> element, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumIsNullFunctionExpression<TEnum>(element, new NullableEnumExpressionMediator<TEnum>(new LiteralExpression<TEnum?>(value)));
        #endregion

        #region float
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnySingleElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="SingleElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="SingleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleIsNullFunctionExpression IsNull(AnySingleElement element1, SingleElement element2)
            => new SingleIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnySingleElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="NullableSingleElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableSingleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleIsNullFunctionExpression IsNull(AnySingleElement element1, NullableSingleElement element2)
            => new NullableSingleIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnySingleElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="SingleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleIsNullFunctionExpression IsNull(AnySingleElement element, float value)
            => new SingleIsNullFunctionExpression(element, new SingleExpressionMediator(new LiteralExpression<float>(value)));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnySingleElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableSingleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleIsNullFunctionExpression IsNull(AnySingleElement element, float? value)
            => new NullableSingleIsNullFunctionExpression(element, new NullableSingleExpressionMediator(new LiteralExpression<float?>(value)));
        #endregion

        #region Guid
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyGuidElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="GuidElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="GuidIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyGuidElement"/> or <see cref="GuidElement"/>.</returns>
        public static GuidIsNullFunctionExpression IsNull(AnyGuidElement element1, GuidElement element2)
            => new GuidIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyGuidElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="NullableGuidElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableGuidIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyGuidElement"/> or <see cref="NullableGuidElement"/>.</returns>
        public static NullableGuidIsNullFunctionExpression IsNull(AnyGuidElement element1, NullableGuidElement element2)
            => new NullableGuidIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyGuidElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="GuidIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyGuidElement"/> or <see cref="GuidElement"/>.</returns>
        public static GuidIsNullFunctionExpression IsNull(AnyGuidElement element, Guid value)
            => new GuidIsNullFunctionExpression(element, new GuidExpressionMediator(new LiteralExpression<Guid>(value)));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyGuidElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableGuidIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyGuidElement"/> or <see cref="NullableGuidElement"/>.</returns>
        public static NullableGuidIsNullFunctionExpression IsNull(AnyGuidElement element, Guid? value)
            => new NullableGuidIsNullFunctionExpression(element, new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(value)));
        #endregion

        #region short
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyInt16Element"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="Int16Element"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int16IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="Int16Element"/>.</returns>
        public static Int16IsNullFunctionExpression IsNull(AnyInt16Element element1, Int16Element element2)
            => new Int16IsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyInt16Element"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="NullableInt16Element"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt16IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="NullableInt16Element"/>.</returns>
        public static NullableInt16IsNullFunctionExpression IsNull(AnyInt16Element element1, NullableInt16Element element2)
            => new NullableInt16IsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyInt16Element"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int16IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="Int16Element"/>.</returns>
        public static Int16IsNullFunctionExpression IsNull(AnyInt16Element element, short value)
            => new Int16IsNullFunctionExpression(element, new Int16ExpressionMediator(new LiteralExpression<short>(value)));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyInt16Element"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt16IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="NullableInt16Element"/>.</returns>
        public static NullableInt16IsNullFunctionExpression IsNull(AnyInt16Element element, short? value)
            => new NullableInt16IsNullFunctionExpression(element, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(value)));
        #endregion

        #region int
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyInt32Element"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="Int32Element"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int32IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32IsNullFunctionExpression IsNull(AnyInt32Element element1, Int32Element element2)
            => new Int32IsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyInt32Element"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="NullableInt32Element"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt32IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32IsNullFunctionExpression IsNull(AnyInt32Element element1, NullableInt32Element element2)
            => new NullableInt32IsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyInt32Element"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int32IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32IsNullFunctionExpression IsNull(AnyInt32Element element, int value)
            => new Int32IsNullFunctionExpression(element, new Int32ExpressionMediator(new LiteralExpression<int>(value)));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyInt32Element"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt32IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32IsNullFunctionExpression IsNull(AnyInt32Element element, int? value)
            => new NullableInt32IsNullFunctionExpression(element, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(value)));
        #endregion

        #region long
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyInt64Element"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="Int64Element"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int64IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="Int64Element"/>.</returns>
        public static Int64IsNullFunctionExpression IsNull(AnyInt64Element element1, Int64Element element2)
            => new Int64IsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyInt64Element"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="NullableInt64Element"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt64IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="NullableInt64Element"/>.</returns>
        public static NullableInt64IsNullFunctionExpression IsNull(AnyInt64Element element1, NullableInt64Element element2)
            => new NullableInt64IsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyInt64Element"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int64IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="Int64Element"/>.</returns>
        public static Int64IsNullFunctionExpression IsNull(AnyInt64Element element, long value)
            => new Int64IsNullFunctionExpression(element, new Int64ExpressionMediator(new LiteralExpression<long>(value)));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyInt64Element"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt64IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="NullableInt64Element"/>.</returns>
        public static NullableInt64IsNullFunctionExpression IsNull(AnyInt64Element element, long? value)
            => new NullableInt64IsNullFunctionExpression(element, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(value)));
        #endregion

        #region string
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyStringElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="StringElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="StringIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="StringElement"/>.</returns>
        public static StringIsNullFunctionExpression IsNull(AnyStringElement element1, StringElement element2)
            => new StringIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyStringElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="NullableStringElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableStringIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="NullableStringElement"/>.</returns>
        public static NullableStringIsNullFunctionExpression IsNull(AnyStringElement element1, NullableStringElement element2)
            => new NullableStringIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyStringElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="StringIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="StringElement"/>.</returns>
        public static StringIsNullFunctionExpression IsNull(AnyStringElement element, string value)
            => new StringIsNullFunctionExpression(element, new StringExpressionMediator(new LiteralExpression<string>(value)));
        #endregion

        #region TimeSpan
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyTimeSpanElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="TimeSpanElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="TimeSpanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyTimeSpanElement"/> or <see cref="TimeSpanElement"/>.</returns>
        public static TimeSpanIsNullFunctionExpression IsNull(AnyTimeSpanElement element1, TimeSpanElement element2)
            => new TimeSpanIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyTimeSpanElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="NullableTimeSpanElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableTimeSpanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyTimeSpanElement"/> or <see cref="NullableTimeSpanElement"/>.</returns>
        public static NullableTimeSpanIsNullFunctionExpression IsNull(AnyTimeSpanElement element1, NullableTimeSpanElement element2)
            => new NullableTimeSpanIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyTimeSpanElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="TimeSpanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyTimeSpanElement"/> or <see cref="TimeSpanElement"/>.</returns>
        public static TimeSpanIsNullFunctionExpression IsNull(AnyTimeSpanElement element, TimeSpan value)
            => new TimeSpanIsNullFunctionExpression(element, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(value)));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyTimeSpanElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableTimeSpanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyTimeSpanElement"/> or <see cref="NullableTimeSpanElement"/>.</returns>
        public static NullableTimeSpanIsNullFunctionExpression IsNull(AnyTimeSpanElement element, TimeSpan? value)
            => new NullableTimeSpanIsNullFunctionExpression(element, new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(value)));
        #endregion
        #endregion

        #region average
        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/avg-transact-sql">Microsoft docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyObjectElement"/>, the value to use for calculating the average function result.</param>
        /// <returns><see cref="ObjectAverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyObjectElement"/>.</returns>
        public static ObjectAverageFunctionExpression Avg(AnyObjectElement element)
            => new ObjectAverageFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/avg-transact-sql">Microsoft docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ByteElement"/>, the value to use for calculating the average function result.</param>
        /// <returns><see cref="Int32AverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32AverageFunctionExpression Avg(ByteElement element)
            => new Int32AverageFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/avg-transact-sql">Microsoft docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableByteElement"/>, the value to use for calculating the average function result.</param>
        /// <returns><see cref="NullableInt32AverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32AverageFunctionExpression Avg(NullableByteElement element)
            => new NullableInt32AverageFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/avg-transact-sql">Microsoft docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int16Element"/>, the value to use for calculating the average function result.</param>
        /// <returns><see cref="Int32AverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32AverageFunctionExpression Avg(Int16Element element)
            => new Int32AverageFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/avg-transact-sql">Microsoft docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt16Element"/>, the value to use for calculating the average function result.</param>
        /// <returns><see cref="NullableInt32AverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32AverageFunctionExpression Avg(NullableInt16Element element)
            => new NullableInt32AverageFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/avg-transact-sql">Microsoft docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int32Element"/>, the value to use for calculating the average function result.</param>
        /// <returns><see cref="Int32AverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32AverageFunctionExpression Avg(Int32Element element)
            => new Int32AverageFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/avg-transact-sql">Microsoft docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt32Element"/>, the value to use for calculating the average function result.</param>
        /// <returns><see cref="NullableInt32AverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32AverageFunctionExpression Avg(NullableInt32Element element)
            => new NullableInt32AverageFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/avg-transact-sql">Microsoft docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int64Element"/>, the value to use for calculating the average function result.</param>
        /// <returns><see cref="Int64AverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="Int64Element"/>.</returns>
        public static Int64AverageFunctionExpression Avg(Int64Element element)
            => new Int64AverageFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/avg-transact-sql">Microsoft docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt64Element"/>, the value to use for calculating the average function result.</param>
        /// <returns><see cref="NullableInt64AverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="NullableInt64Element"/>.</returns>
        public static NullableInt64AverageFunctionExpression Avg(NullableInt64Element element)
            => new NullableInt64AverageFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/avg-transact-sql">Microsoft docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="SingleElement"/>, the value to use for calculating the average function result.</param>
        /// <returns><see cref="SingleAverageFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleAverageFunctionExpression Avg(SingleElement element)
            => new SingleAverageFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/avg-transact-sql">Microsoft docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableSingleElement"/>, the value to use for calculating the average function result.</param>
        /// <returns><see cref="NullableSingleAverageFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleAverageFunctionExpression Avg(NullableSingleElement element)
            => new NullableSingleAverageFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/avg-transact-sql">Microsoft docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DoubleElement"/>, the value to use for calculating the average function result.</param>
        /// <returns><see cref="DoubleAverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="DoubleElement"/>.</returns>
        public static DoubleAverageFunctionExpression Avg(DoubleElement element)
            => new DoubleAverageFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/avg-transact-sql">Microsoft docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDoubleElement"/>, the value to use for calculating the average function result.</param>
        /// <returns><see cref="NullableDoubleAverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="NullableDoubleElement"/>.</returns>
        public static NullableDoubleAverageFunctionExpression Avg(NullableDoubleElement element)
            => new NullableDoubleAverageFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/avg-transact-sql">Microsoft docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DecimalElement"/>, the value to use for calculating the average function result.</param>
        /// <returns><see cref="DecimalAverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="DecimalElement"/>.</returns>
        public static DecimalAverageFunctionExpression Avg(DecimalElement element)
            => new DecimalAverageFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/avg-transact-sql">Microsoft docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDecimalElement"/>, the value to use for calculating the average function result.</param>
        /// <returns><see cref="NullableDecimalAverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="NullableDecimalElement"/>.</returns>
        public static NullableDecimalAverageFunctionExpression Avg(NullableDecimalElement element)
            => new NullableDecimalAverageFunctionExpression(element);
        #endregion

        #region minimum
        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyObjectElement"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="ObjectAverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyObjectElement"/>.</returns>
        public static ObjectMinimumFunctionExpression Min(AnyObjectElement element)
            => new ObjectMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ByteElement"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="ByteMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="ByteElement"/>.</returns>
        public static ByteMinimumFunctionExpression Min(ByteElement element)
            => new ByteMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableByteElement"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableByteMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="NullableByteElement"/>.</returns>
        public static NullableByteMinimumFunctionExpression Min(NullableByteElement element)
            => new NullableByteMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int16Element"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="Int16MinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="Int16Element"/>.</returns>
        public static Int16MinimumFunctionExpression Min(Int16Element element)
            => new Int16MinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt16Element"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableInt16MinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="NullableInt16Element"/>.</returns>
        public static NullableInt16MinimumFunctionExpression Min(NullableInt16Element element)
            => new NullableInt16MinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int32Element"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="Int32MinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32MinimumFunctionExpression Min(Int32Element element)
            => new Int32MinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt32Element"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableInt32MinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32MinimumFunctionExpression Min(NullableInt32Element element)
            => new NullableInt32MinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int64Element"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="Int64MinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="Int64Element"/>.</returns>
        public static Int64MinimumFunctionExpression Min(Int64Element element)
            => new Int64MinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt64Element"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableInt64MinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="NullableInt64Element"/>.</returns>
        public static NullableInt64MinimumFunctionExpression Min(NullableInt64Element element)
            => new NullableInt64MinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="SingleElement"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="SingleMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleMinimumFunctionExpression Min(SingleElement element)
            => new SingleMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableSingleElement"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableSingleMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleMinimumFunctionExpression Min(NullableSingleElement element)
            => new NullableSingleMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DoubleElement"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="DoubleMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="DoubleElement"/>.</returns>
        public static DoubleMinimumFunctionExpression Min(DoubleElement element)
            => new DoubleMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDoubleElement"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableDoubleMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="NullableDoubleElement"/>.</returns>
        public static NullableDoubleMinimumFunctionExpression Min(NullableDoubleElement element)
            => new NullableDoubleMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DecimalElement"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="DecimalMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="DecimalElement"/>.</returns>
        public static DecimalMinimumFunctionExpression Min(DecimalElement element)
            => new DecimalMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDecimalElement"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableDecimalMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="NullableDecimalElement"/>.</returns>
        public static NullableDecimalMinimumFunctionExpression Min(NullableDecimalElement element)
            => new NullableDecimalMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DateTimeElement"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="DateTimeMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="DateTimeElement"/>.</returns>
        public static DateTimeMinimumFunctionExpression Min(DateTimeElement element)
            => new DateTimeMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDateTimeElement"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableDateTimeMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="NullableDateTimeElement"/>.</returns>
        public static NullableDateTimeMinimumFunctionExpression Min(NullableDateTimeElement element)
            => new NullableDateTimeMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DateTimeOffsetElement"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="DateTimeOffsetMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="DateTimeOffsetElement"/>.</returns>
        public static DateTimeOffsetMinimumFunctionExpression Min(DateTimeOffsetElement element)
            => new DateTimeOffsetMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDateTimeOffsetElement"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableDateTimeOffsetMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="NullableDateTimeOffsetElement"/>.</returns>
        public static NullableDateTimeOffsetMinimumFunctionExpression Min(NullableDateTimeOffsetElement element)
            => new NullableDateTimeOffsetMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="GuidElement"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="GuidMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyGuidElement"/> or <see cref="GuidElement"/>.</returns>
        public static GuidMinimumFunctionExpression Min(GuidElement element)
            => new GuidMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableGuidElement"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableGuidMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyGuidElement"/> or <see cref="NullableGuidElement"/>.</returns>
        public static NullableGuidMinimumFunctionExpression Min(NullableGuidElement element)
            => new NullableGuidMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="StringElement"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="StringMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="StringElement"/>.</returns>
        public static StringMinimumFunctionExpression Min(StringElement element)
            => new StringMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="TimeSpanElement"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="TimeSpanMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyTimeSpanElement"/> or <see cref="TimeSpanElement"/>.</returns>
        public static TimeSpanMinimumFunctionExpression Min(TimeSpanElement element)
            => new TimeSpanMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableTimeSpanElement"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableTimeSpanMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyTimeSpanElement"/> or <see cref="NullableTimeSpanElement"/>.</returns>
        public static NullableTimeSpanMinimumFunctionExpression Min(NullableTimeSpanElement element)
            => new NullableTimeSpanMinimumFunctionExpression(element);
        #endregion

        #region maximum
        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyObjectElement"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="ObjectAverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyObjectElement"/>.</returns>
        public static ObjectMaximumFunctionExpression Max(AnyObjectElement element)
            => new ObjectMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ByteElement"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="ByteMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="ByteElement"/>.</returns>
        public static ByteMaximumFunctionExpression Max(ByteElement element)
            => new ByteMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableByteElement"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableByteMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="NullableByteElement"/>.</returns>
        public static NullableByteMaximumFunctionExpression Max(NullableByteElement element)
            => new NullableByteMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int16Element"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="Int16MaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="Int16Element"/>.</returns>
        public static Int16MaximumFunctionExpression Max(Int16Element element)
            => new Int16MaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt16Element"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableInt16MaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="NullableInt16Element"/>.</returns>
        public static NullableInt16MaximumFunctionExpression Max(NullableInt16Element element)
            => new NullableInt16MaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int32Element"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="Int32MaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32MaximumFunctionExpression Max(Int32Element element)
            => new Int32MaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt32Element"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableInt32MaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32MaximumFunctionExpression Max(NullableInt32Element element)
            => new NullableInt32MaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int64Element"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="Int64MaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="Int64Element"/>.</returns>
        public static Int64MaximumFunctionExpression Max(Int64Element element)
            => new Int64MaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt64Element"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableInt64MaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="NullableInt64Element"/>.</returns>
        public static NullableInt64MaximumFunctionExpression Max(NullableInt64Element element)
            => new NullableInt64MaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="SingleElement"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="SingleMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleMaximumFunctionExpression Max(SingleElement element)
            => new SingleMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableSingleElement"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableSingleMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleMaximumFunctionExpression Max(NullableSingleElement element)
            => new NullableSingleMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DoubleElement"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="DoubleMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="DoubleElement"/>.</returns>
        public static DoubleMaximumFunctionExpression Max(DoubleElement element)
            => new DoubleMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDoubleElement"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableDoubleMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="NullableDoubleElement"/>.</returns>
        public static NullableDoubleMaximumFunctionExpression Max(NullableDoubleElement element)
            => new NullableDoubleMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DecimalElement"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="DecimalMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="DecimalElement"/>.</returns>
        public static DecimalMaximumFunctionExpression Max(DecimalElement element)
            => new DecimalMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDecimalElement"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableDecimalMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="NullableDecimalElement"/>.</returns>
        public static NullableDecimalMaximumFunctionExpression Max(NullableDecimalElement element)
            => new NullableDecimalMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DateTimeElement"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="DateTimeMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="DateTimeElement"/>.</returns>
        public static DateTimeMaximumFunctionExpression Max(DateTimeElement element)
            => new DateTimeMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDateTimeElement"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableDateTimeMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="NullableDateTimeElement"/>.</returns>
        public static NullableDateTimeMaximumFunctionExpression Max(NullableDateTimeElement element)
            => new NullableDateTimeMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DateTimeOffsetElement"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="DateTimeOffsetMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="DateTimeOffsetElement"/>.</returns>
        public static DateTimeOffsetMaximumFunctionExpression Max(DateTimeOffsetElement element)
            => new DateTimeOffsetMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDateTimeOffsetElement"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableDateTimeOffsetMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="NullableDateTimeOffsetElement"/>.</returns>
        public static NullableDateTimeOffsetMaximumFunctionExpression Max(NullableDateTimeOffsetElement element)
            => new NullableDateTimeOffsetMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="GuidElement"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="GuidMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyGuidElement"/> or <see cref="GuidElement"/>.</returns>
        public static GuidMaximumFunctionExpression Max(GuidElement element)
            => new GuidMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableGuidElement"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableGuidMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyGuidElement"/> or <see cref="NullableGuidElement"/>.</returns>
        public static NullableGuidMaximumFunctionExpression Max(NullableGuidElement element)
            => new NullableGuidMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="StringElement"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="StringMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/> or <see cref="StringElement"/>.</returns>
        public static StringMaximumFunctionExpression Max(StringElement element)
            => new StringMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="TimeSpanElement"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="TimeSpanMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyTimeSpanElement"/> or <see cref="TimeSpanElement"/>.</returns>
        public static TimeSpanMaximumFunctionExpression Max(TimeSpanElement element)
            => new TimeSpanMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableTimeSpanElement"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableTimeSpanMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyTimeSpanElement"/> or <see cref="NullableTimeSpanElement"/>.</returns>
        public static NullableTimeSpanMaximumFunctionExpression Max(NullableTimeSpanElement element)
            => new NullableTimeSpanMaximumFunctionExpression(element);
        #endregion

        #region count
        /// <summary>
        /// Construct an expression for the COUNT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/count-transact-sql">Microsoft docs on COUNT</see></para>
        /// </summary>
        /// <returns><see cref="Int32CountFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32CountFunctionExpression Count()
            => new Int32CountFunctionExpression();

        /// <summary>
        /// Construct an expression for the COUNT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/count-transact-sql">Microsoft docs on COUNT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement"/>, the value to use for calculating the count function result.</param>
        /// <returns><see cref="Int32CountFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32CountFunctionExpression Count(AnyElement element)
            => new Int32CountFunctionExpression(element);
        #endregion

        #region sum
        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sum-transact-sql">Microsoft docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyObjectElement"/>, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="ObjectSumFunctionExpression"/> for use with any operation accepting a <see cref="AnyObjectElement"/>.</returns>
        public static ObjectSumFunctionExpression Sum(AnyObjectElement element)
            => new ObjectSumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sum-transact-sql">Microsoft docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ByteElement"/>, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="Int32SumFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32SumFunctionExpression Sum(ByteElement element)
            => new Int32SumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sum-transact-sql">Microsoft docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableByteElement"/>, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="NullableInt32SumFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32SumFunctionExpression Sum(NullableByteElement element)
            => new NullableInt32SumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sum-transact-sql">Microsoft docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int16Element"/>, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="Int32SumFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32SumFunctionExpression Sum(Int16Element element)
            => new Int32SumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sum-transact-sql">Microsoft docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt16Element"/>, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="NullableInt32SumFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32SumFunctionExpression Sum(NullableInt16Element element)
            => new NullableInt32SumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sum-transact-sql">Microsoft docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int32Element"/>, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="Int32SumFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32SumFunctionExpression Sum(Int32Element element)
            => new Int32SumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sum-transact-sql">Microsoft docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt32Element"/>, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="NullableInt32SumFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32SumFunctionExpression Sum(NullableInt32Element element)
            => new NullableInt32SumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sum-transact-sql">Microsoft docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int64Element"/>, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="Int64SumFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="Int64Element"/>.</returns>
        public static Int64SumFunctionExpression Sum(Int64Element element)
            => new Int64SumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sum-transact-sql">Microsoft docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt64Element"/>, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="NullableInt64SumFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="NullableInt64Element"/>.</returns>
        public static NullableInt64SumFunctionExpression Sum(NullableInt64Element element)
            => new NullableInt64SumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sum-transact-sql">Microsoft docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DoubleElement"/>, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="DoubleSumFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="DoubleElement"/>.</returns>
        public static DoubleSumFunctionExpression Sum(DoubleElement element)
            => new DoubleSumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sum-transact-sql">Microsoft docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDoubleElement"/>, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="NullableDoubleSumFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="NullableDoubleElement"/>.</returns>
        public static NullableDoubleSumFunctionExpression Sum(NullableDoubleElement element)
            => new NullableDoubleSumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sum-transact-sql">Microsoft docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DecimalElement"/>, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="DecimalSumFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="DecimalElement"/>.</returns>
        public static DecimalSumFunctionExpression Sum(DecimalElement element)
            => new DecimalSumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sum-transact-sql">Microsoft docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDecimalElement"/>, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="NullableDecimalSumFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="NullableDecimalElement"/>.</returns>
        public static NullableDecimalSumFunctionExpression Sum(NullableDecimalElement element)
            => new NullableDecimalSumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sum-transact-sql">Microsoft docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="SingleElement"/>, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="SingleSumFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleSumFunctionExpression Sum(SingleElement element)
            => new SingleSumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sum-transact-sql">Microsoft docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableSingleElement"/>, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="NullableSingleSumFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleSumFunctionExpression Sum(NullableSingleElement element)
            => new NullableSingleSumFunctionExpression(element);
        #endregion

        #region standard deviation
        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyObjectElement"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="ObjectStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyObjectElement"/>.</returns>
        public static ObjectStandardDeviationFunctionExpression StDev(AnyObjectElement element)
            => new ObjectStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ByteElement"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="SingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleStandardDeviationFunctionExpression StDev(ByteElement element)
            => new SingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableByteElement"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="NullableSingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleStandardDeviationFunctionExpression StDev(NullableByteElement element)
            => new NullableSingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int16Element"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="SingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleStandardDeviationFunctionExpression StDev(Int16Element element)
            => new SingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt16Element"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="NullableSingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleStandardDeviationFunctionExpression StDev(NullableInt16Element element)
            => new NullableSingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int32Element"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="SingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleStandardDeviationFunctionExpression StDev(Int32Element element)
            => new SingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt32Element"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="NullableSingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleStandardDeviationFunctionExpression StDev(NullableInt32Element element)
            => new NullableSingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int64Element"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="SingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleStandardDeviationFunctionExpression StDev(Int64Element element)
            => new SingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt64Element"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="NullableSingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleStandardDeviationFunctionExpression StDev(NullableInt64Element element)
            => new NullableSingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DoubleElement"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="SingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleStandardDeviationFunctionExpression StDev(DoubleElement element)
            => new SingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDoubleElement"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="NullableSingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleStandardDeviationFunctionExpression StDev(NullableDoubleElement element)
            => new NullableSingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DecimalElement"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="SingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleStandardDeviationFunctionExpression StDev(DecimalElement element)
            => new SingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDecimalElement"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="NullableSingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleStandardDeviationFunctionExpression StDev(NullableDecimalElement element)
            => new NullableSingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="SingleElement"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="SingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleStandardDeviationFunctionExpression StDev(SingleElement element)
            => new SingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableSingleElement"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="NullableSingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleStandardDeviationFunctionExpression StDev(NullableSingleElement element)
            => new NullableSingleStandardDeviationFunctionExpression(element);
        #endregion

        #region standard deviation p
        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdevp-transact-sql">Microsoft docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyObjectElement"/>, the value to use for calculating the standard deviation function (for the population) result.</param>
        /// <returns><see cref="ObjectPopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyObjectElement"/>.</returns>
        public static ObjectPopulationStandardDeviationFunctionExpression StDevP(AnyObjectElement element)
            => new ObjectPopulationStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdevp-transact-sql">Microsoft docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ByteElement"/>, the value to use for calculating the standard deviation function (for the population) result.</param>
        /// <returns><see cref="SinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SinglePopulationStandardDeviationFunctionExpression StDevP(ByteElement element)
            => new SinglePopulationStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdevp-transact-sql">Microsoft docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableByteElement"/>, the value to use for calculating the standard deviation function (for the population) result.</param>
        /// <returns><see cref="NullableSinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSinglePopulationStandardDeviationFunctionExpression StDevP(NullableByteElement element)
            => new NullableSinglePopulationStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdevp-transact-sql">Microsoft docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int16Element"/>, the value to use for calculating the standard deviation function (for the population) result.</param>
        /// <returns><see cref="SinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SinglePopulationStandardDeviationFunctionExpression StDevP(Int16Element element)
            => new SinglePopulationStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdevp-transact-sql">Microsoft docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt16Element"/>, the value to use for calculating the standard deviation function (for the population) result.</param>
        /// <returns><see cref="NullableSinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSinglePopulationStandardDeviationFunctionExpression StDevP(NullableInt16Element element)
            => new NullableSinglePopulationStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdevp-transact-sql">Microsoft docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int32Element"/>, the value to use for calculating the standard deviation function (for the population) result.</param>
        /// <returns><see cref="SinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SinglePopulationStandardDeviationFunctionExpression StDevP(Int32Element element)
            => new SinglePopulationStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdevp-transact-sql">Microsoft docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt32Element"/>, the value to use for calculating the standard deviation function (for the population) result.</param>
        /// <returns><see cref="NullableSinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSinglePopulationStandardDeviationFunctionExpression StDevP(NullableInt32Element element)
            => new NullableSinglePopulationStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdevp-transact-sql">Microsoft docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int64Element"/>, the value to use for calculating the standard deviation function (for the population) result.</param>
        /// <returns><see cref="SinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SinglePopulationStandardDeviationFunctionExpression StDevP(Int64Element element)
            => new SinglePopulationStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdevp-transact-sql">Microsoft docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt64Element"/>, the value to use for calculating the standard deviation function (for the population) result.</param>
        /// <returns><see cref="NullableSinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSinglePopulationStandardDeviationFunctionExpression StDevP(NullableInt64Element element)
            => new NullableSinglePopulationStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdevp-transact-sql">Microsoft docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DoubleElement"/>, the value to use for calculating the standard deviation function (for the population) result.</param>
        /// <returns><see cref="SinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SinglePopulationStandardDeviationFunctionExpression StDevP(DoubleElement element)
            => new SinglePopulationStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdevp-transact-sql">Microsoft docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDoubleElement"/>, the value to use for calculating the standard deviation function (for the population) result.</param>
        /// <returns><see cref="NullableSinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSinglePopulationStandardDeviationFunctionExpression StDevP(NullableDoubleElement element)
            => new NullableSinglePopulationStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdevp-transact-sql">Microsoft docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DecimalElement"/>, the value to use for calculating the standard deviation function (for the population) result.</param>
        /// <returns><see cref="SinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SinglePopulationStandardDeviationFunctionExpression StDevP(DecimalElement element)
            => new SinglePopulationStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdevp-transact-sql">Microsoft docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDecimalElement"/>, the value to use for calculating the standard deviation function (for the population) result.</param>
        /// <returns><see cref="NullableSinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSinglePopulationStandardDeviationFunctionExpression StDevP(NullableDecimalElement element)
            => new NullableSinglePopulationStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdevp-transact-sql">Microsoft docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="SingleElement"/>, the value to use for calculating the standard deviation function (for the population) result.</param>
        /// <returns><see cref="SinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SinglePopulationStandardDeviationFunctionExpression StDevP(SingleElement element)
            => new SinglePopulationStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdevp-transact-sql">Microsoft docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableSingleElement"/>, the value to use for calculating the standard deviation function (for the population) result.</param>
        /// <returns><see cref="NullableSinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSinglePopulationStandardDeviationFunctionExpression StDevP(NullableSingleElement element)
            => new NullableSinglePopulationStandardDeviationFunctionExpression(element);
        #endregion

        #region variance
        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/var-transact-sql">Microsoft docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyObjectElement"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="ObjectVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyObjectElement"/>.</returns>
        public static ObjectVarianceFunctionExpression Var(AnyObjectElement element)
            => new ObjectVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/var-transact-sql">Microsoft docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ByteElement"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="SingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleVarianceFunctionExpression Var(ByteElement element)
            => new SingleVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/var-transact-sql">Microsoft docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableByteElement"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="NullableSingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleVarianceFunctionExpression Var(NullableByteElement element)
            => new NullableSingleVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/var-transact-sql">Microsoft docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int16Element"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="SingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleVarianceFunctionExpression Var(Int16Element element)
            => new SingleVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/var-transact-sql">Microsoft docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt16Element"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="NullableSingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleVarianceFunctionExpression Var(NullableInt16Element element)
            => new NullableSingleVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/var-transact-sql">Microsoft docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int32Element"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="SingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleVarianceFunctionExpression Var(Int32Element element)
            => new SingleVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/var-transact-sql">Microsoft docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt32Element"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="NullableSingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleVarianceFunctionExpression Var(NullableInt32Element element)
            => new NullableSingleVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/var-transact-sql">Microsoft docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int64Element"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="SingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleVarianceFunctionExpression Var(Int64Element element)
            => new SingleVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/var-transact-sql">Microsoft docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt64Element"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="NullableSingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleVarianceFunctionExpression Var(NullableInt64Element element)
            => new NullableSingleVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/var-transact-sql">Microsoft docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DoubleElement"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="SingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleVarianceFunctionExpression Var(DoubleElement element)
            => new SingleVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/var-transact-sql">Microsoft docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDoubleElement"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="NullableSingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleVarianceFunctionExpression Var(NullableDoubleElement element)
            => new NullableSingleVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/var-transact-sql">Microsoft docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DecimalElement"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="SingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleVarianceFunctionExpression Var(DecimalElement element)
            => new SingleVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/var-transact-sql">Microsoft docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDecimalElement"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="NullableSingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleVarianceFunctionExpression Var(NullableDecimalElement element)
            => new NullableSingleVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/var-transact-sql">Microsoft docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="SingleElement"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="SingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleVarianceFunctionExpression Var(SingleElement element)
            => new SingleVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/var-transact-sql">Microsoft docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableSingleElement"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="NullableSingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleVarianceFunctionExpression Var(NullableSingleElement element)
            => new NullableSingleVarianceFunctionExpression(element);
        #endregion

        #region variance p
        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/varp-transact-sql">Microsoft docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyObjectElement"/>, the value to use for calculating the variance function (for the population) result.</param>
        /// <returns><see cref="ObjectPopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyObjectElement"/>.</returns>
        public static ObjectPopulationVarianceFunctionExpression VarP(AnyObjectElement element)
            => new ObjectPopulationVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/varp-transact-sql">Microsoft docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ByteElement"/>, the value to use for calculating the variance function (for the population) result.</param>
        /// <returns><see cref="SinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SinglePopulationVarianceFunctionExpression VarP(ByteElement element)
            => new SinglePopulationVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/varp-transact-sql">Microsoft docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableByteElement"/>, the value to use for calculating the variance function (for the population) result.</param>
        /// <returns><see cref="NullableSinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSinglePopulationVarianceFunctionExpression VarP(NullableByteElement element)
            => new NullableSinglePopulationVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/varp-transact-sql">Microsoft docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int16Element"/>, the value to use for calculating the variance function (for the population) result.</param>
        /// <returns><see cref="SinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SinglePopulationVarianceFunctionExpression VarP(Int16Element element)
            => new SinglePopulationVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/varp-transact-sql">Microsoft docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt16Element"/>, the value to use for calculating the variance function (for the population) result.</param>
        /// <returns><see cref="NullableSinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSinglePopulationVarianceFunctionExpression VarP(NullableInt16Element element)
            => new NullableSinglePopulationVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/varp-transact-sql">Microsoft docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int32Element"/>, the value to use for calculating the variance function (for the population) result.</param>
        /// <returns><see cref="SinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SinglePopulationVarianceFunctionExpression VarP(Int32Element element)
            => new SinglePopulationVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/varp-transact-sql">Microsoft docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt32Element"/>, the value to use for calculating the variance function (for the population) result.</param>
        /// <returns><see cref="NullableSinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSinglePopulationVarianceFunctionExpression VarP(NullableInt32Element element)
            => new NullableSinglePopulationVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/varp-transact-sql">Microsoft docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int64Element"/>, the value to use for calculating the variance function (for the population) result.</param>
        /// <returns><see cref="SinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SinglePopulationVarianceFunctionExpression VarP(Int64Element element)
            => new SinglePopulationVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/varp-transact-sql">Microsoft docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt64Element"/>, the value to use for calculating the variance function (for the population) result.</param>
        /// <returns><see cref="NullableSinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSinglePopulationVarianceFunctionExpression VarP(NullableInt64Element element)
            => new NullableSinglePopulationVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/varp-transact-sql">Microsoft docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DoubleElement"/>, the value to use for calculating the variance function (for the population) result.</param>
        /// <returns><see cref="SinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SinglePopulationVarianceFunctionExpression VarP(DoubleElement element)
            => new SinglePopulationVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/varp-transact-sql">Microsoft docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDoubleElement"/>, the value to use for calculating the variance function (for the population) result.</param>
        /// <returns><see cref="NullableSinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSinglePopulationVarianceFunctionExpression VarP(NullableDoubleElement element)
            => new NullableSinglePopulationVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/varp-transact-sql">Microsoft docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DecimalElement"/>, the value to use for calculating the variance function (for the population) result.</param>
        /// <returns><see cref="SinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SinglePopulationVarianceFunctionExpression VarP(DecimalElement element)
            => new SinglePopulationVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/varp-transact-sql">Microsoft docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDecimalElement"/>, the value to use for calculating the variance function (for the population) result.</param>
        /// <returns><see cref="NullableSinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSinglePopulationVarianceFunctionExpression VarP(NullableDecimalElement element)
            => new NullableSinglePopulationVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/varp-transact-sql">Microsoft docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="SingleElement"/>, the value to use for calculating the variance function (for the population) result.</param>
        /// <returns><see cref="SinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SinglePopulationVarianceFunctionExpression VarP(SingleElement element)
            => new SinglePopulationVarianceFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/varp-transact-sql">Microsoft docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableSingleElement"/>, the value to use for calculating the variance function (for the population) result.</param>
        /// <returns><see cref="NullableSinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSinglePopulationVarianceFunctionExpression VarP(NullableSingleElement element)
            => new NullableSinglePopulationVarianceFunctionExpression(element);
        #endregion

        #region date
        /// <summary>
        /// Construct an expression for the CURRENT_TIMESTAMP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/current-timestamp-transact-sql">Microsoft docs on CURRENT_TIMESTAMP</see></para>
        /// </summary>
        /// <returns><see cref="CurrentTimestampFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="DateTimeElement"/>.</returns>
        public static CurrentTimestampFunctionExpression Current_Timestamp
            => new CurrentTimestampFunctionExpression();
        #endregion

        #region floor
        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyObjectElement"/>, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="ObjectFloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyObjectElement"/>.</returns>
        public static ObjectFloorFunctionExpression Floor(AnyObjectElement element)
            => new ObjectFloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ByteElement"/>, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="ByteFloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="ByteElement"/>.</returns>
        public static ByteFloorFunctionExpression Floor(ByteElement element)
            => new ByteFloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableByteElement"/>, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="NullableByteFloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="NullableByteElement"/>.</returns>
        public static NullableByteFloorFunctionExpression Floor(NullableByteElement element)
            => new NullableByteFloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int16Element"/>, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="Int16FloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="Int16Element"/>.</returns>
        public static Int16FloorFunctionExpression Floor(Int16Element element)
            => new Int16FloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt16Element"/>, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="NullableInt16FloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="NullableInt16Element"/>.</returns>
        public static NullableInt16FloorFunctionExpression Floor(NullableInt16Element element)
            => new NullableInt16FloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int32Element"/>, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="Int32FloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32FloorFunctionExpression Floor(Int32Element element)
            => new Int32FloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt32Element"/>, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="NullableInt32FloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32FloorFunctionExpression Floor(NullableInt32Element element)
            => new NullableInt32FloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int64Element"/>, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="Int64FloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="Int64Element"/>.</returns>
        public static Int64FloorFunctionExpression Floor(Int64Element element)
            => new Int64FloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt64Element"/>, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="NullableInt64FloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="NullableInt64Element"/>.</returns>
        public static NullableInt64FloorFunctionExpression Floor(NullableInt64Element element)
            => new NullableInt64FloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="SingleElement"/>, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="SingleFloorFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleFloorFunctionExpression Floor(SingleElement element)
            => new SingleFloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableSingleElement"/>, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="NullableSingleFloorFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleFloorFunctionExpression Floor(NullableSingleElement element)
            => new NullableSingleFloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DoubleElement"/>, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="DoubleFloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="DoubleElement"/>.</returns>
        public static DoubleFloorFunctionExpression Floor(DoubleElement element)
            => new DoubleFloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDoubleElement"/>, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="NullableDoubleFloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="NullableDoubleElement"/>.</returns>
        public static NullableDoubleFloorFunctionExpression Floor(NullableDoubleElement element)
            => new NullableDoubleFloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DecimalElement"/>, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="DecimalFloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="DecimalElement"/>.</returns>
        public static DecimalFloorFunctionExpression Floor(DecimalElement element)
            => new DecimalFloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDecimalElement"/>, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="NullableDecimalFloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="NullableDecimalElement"/>.</returns>
        public static NullableDecimalFloorFunctionExpression Floor(NullableDecimalElement element)
            => new NullableDecimalFloorFunctionExpression(element);
        #endregion

        #region ceiling
        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyObjectElement"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="ObjectCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyObjectElement"/>.</returns>
        public static ObjectCeilingFunctionExpression Ceiling(AnyObjectElement element)
            => new ObjectCeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ByteElement"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="ByteCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="ByteElement"/>.</returns>
        public static ByteCeilingFunctionExpression Ceiling(ByteElement element)
            => new ByteCeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableByteElement"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="NullableByteCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyByteElement"/> or <see cref="NullableByteElement"/>.</returns>
        public static NullableByteCeilingFunctionExpression Ceiling(NullableByteElement element)
            => new NullableByteCeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int16Element"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="Int16CeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="Int16Element"/>.</returns>
        public static Int16CeilingFunctionExpression Ceiling(Int16Element element)
            => new Int16CeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt16Element"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="NullableInt16CeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt16Element"/> or <see cref="NullableInt16Element"/>.</returns>
        public static NullableInt16CeilingFunctionExpression Ceiling(NullableInt16Element element)
            => new NullableInt16CeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int32Element"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="Int32CeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32CeilingFunctionExpression Ceiling(Int32Element element)
            => new Int32CeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt32Element"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="NullableInt32CeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32CeilingFunctionExpression Ceiling(NullableInt32Element element)
            => new NullableInt32CeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int64Element"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="Int64CeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="Int64Element"/>.</returns>
        public static Int64CeilingFunctionExpression Ceiling(Int64Element element)
            => new Int64CeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt64Element"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="NullableInt64CeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt64Element"/> or <see cref="NullableInt64Element"/>.</returns>
        public static NullableInt64CeilingFunctionExpression Ceiling(NullableInt64Element element)
            => new NullableInt64CeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="SingleElement"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="SingleCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="SingleElement"/>.</returns>
        public static SingleCeilingFunctionExpression Ceiling(SingleElement element)
            => new SingleCeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableSingleElement"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="NullableSingleCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnySingleElement"/> or <see cref="NullableSingleElement"/>.</returns>
        public static NullableSingleCeilingFunctionExpression Ceiling(NullableSingleElement element)
            => new NullableSingleCeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DoubleElement"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="DoubleCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="DoubleElement"/>.</returns>
        public static DoubleCeilingFunctionExpression Ceiling(DoubleElement element)
            => new DoubleCeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDoubleElement"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="NullableDoubleCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyDoubleElement"/> or <see cref="NullableDoubleElement"/>.</returns>
        public static NullableDoubleCeilingFunctionExpression Ceiling(NullableDoubleElement element)
            => new NullableDoubleCeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DecimalElement"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="DecimalCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="DecimalElement"/>.</returns>
        public static DecimalCeilingFunctionExpression Ceiling(DecimalElement element)
            => new DecimalCeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDecimalElement"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="NullableDecimalCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyDecimalElement"/> or <see cref="NullableDecimalElement"/>.</returns>
        public static NullableDecimalCeilingFunctionExpression Ceiling(NullableDecimalElement element)
            => new NullableDecimalCeilingFunctionExpression(element);
        #endregion
    }
}
