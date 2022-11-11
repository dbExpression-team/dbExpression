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

namespace HatTrick.DbEx.Sql.Builder
{
    public partial class SqlFunctionExpressionBuilder
    {
        /// <summary>
        /// Construct an expression for the RIGHT transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/right?version=0.9.5">read the docs on RIGHT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="StringElement"/> to take the number of characters from.</param>
        /// <param name="characterCount">An expression of type <see cref="int"/> providing the number of characters to return from the right of <paramref name="element"/>.</param>
        /// <returns><see cref="StringRightFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public StringRightFunctionExpression Right(StringElement element, int characterCount)
            => new(element, new LiteralExpression<int>(characterCount));

        /// <summary>
        /// Construct an expression for the RIGHT transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/right?version=0.9.5">read the docs on RIGHT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="StringElement"/> to take the number of characters from.</param>
        /// <param name="characterCount">An expression of type <see cref="AnyElement{Int32}"/> providing the number of characters to return from the right of <paramref name="element"/>.</param>
        /// <returns><see cref="StringRightFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public StringRightFunctionExpression Right(StringElement element, AnyElement<int> characterCount)
            => new(element, characterCount);

        /// <summary>
        /// Construct an expression for the RIGHT transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/right?version=0.9.5">read the docs on RIGHT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableStringElement"/>? to take the number of characters from.</param>
        /// <param name="characterCount">An expression of type <see cref="int"/> providing the number of characters to return from the right of <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringRightFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public NullableStringRightFunctionExpression Right(NullableStringElement element, int characterCount)
            => new(element, new LiteralExpression<int>(characterCount));

        /// <summary>
        /// Construct an expression for the RIGHT transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/right?version=0.9.5">read the docs on RIGHT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableStringElement"/>? to take the number of characters from.</param>
        /// <param name="characterCount">An expression of type <see cref="int"/> providing the number of characters to return from the right of <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringRightFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public NullableStringRightFunctionExpression Right(NullableStringElement element, int? characterCount)
            => new(element, new LiteralExpression<int?>(characterCount));

        /// <summary>
        /// Construct an expression for the RIGHT transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/right?version=0.9.5">read the docs on RIGHT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableStringElement"/>? to take the number of characters from.</param>
        /// <param name="characterCount">An expression of type <see cref="AnyElement{Int32}"/> providing the number of characters to return from the right of <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringRightFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public NullableStringRightFunctionExpression Right(NullableStringElement element, AnyElement<int> characterCount)
            => new(element, characterCount);

        /// <summary>
        /// Construct an expression for the RIGHT transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/right?version=0.9.5">read the docs on RIGHT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="StringElement"/> to take the number of characters from.</param>
        /// <param name="characterCount">An expression of type <see cref="AnyElement{Int32}"/>? providing the number of characters to return from the right of <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringRightFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public NullableStringRightFunctionExpression Right(StringElement element, AnyElement<int?> characterCount)
            => new(element, characterCount);
    }
}
