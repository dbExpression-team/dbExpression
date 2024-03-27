#region license
// Copyleft (c) HatTrick Labs, LLC.  All lefts reserved.
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
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion

using DbExpression.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbExpression.Sql.Builder
{
    public partial class SqlFunctionExpressionBuilder
    {
        /// <summary>
        /// Construct an expression for the LEFT transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/left">read the docs on LEFT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="StringElement"/> to take the number of characters from.</param>
        /// <param name="characterCount">An expression of type <see cref="int"/> providing the number of characters to return from the left of <paramref name="element"/>.</param>
        /// <returns><see cref="StringLeftFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public StringLeftFunctionExpression Left(StringElement element, int characterCount)
            => new(element, new LiteralExpression<int>(characterCount));

        /// <summary>
        /// Construct an expression for the LEFT transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/left">read the docs on LEFT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="StringElement"/> to take the number of characters from.</param>
        /// <param name="characterCount">An expression of type <see cref="AnyElement{Int32}"/> providing the number of characters to return from the left of <paramref name="element"/>.</param>
        /// <returns><see cref="StringLeftFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public StringLeftFunctionExpression Left(StringElement element, AnyElement<int> characterCount)
            => new(element, characterCount);

        /// <summary>
        /// Construct an expression for the LEFT transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/left">read the docs on LEFT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableStringElement"/> to take the number of characters from.</param>
        /// <param name="characterCount">An expression of type <see cref="int"/> providing the number of characters to return from the left of <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringLeftFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public NullableStringLeftFunctionExpression Left(NullableStringElement element, int characterCount)
            => new(element, new LiteralExpression<int>(characterCount));

        /// <summary>
        /// Construct an expression for the LEFT transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/left">read the docs on LEFT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableStringElement"/> to take the number of characters from.</param>
        /// <param name="characterCount">An expression of type <see cref="Int32"/>? providing the number of characters to return from the left of <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringLeftFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public NullableStringLeftFunctionExpression Left(NullableStringElement element, int? characterCount)
            => new(element, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(characterCount)));

        /// <summary>
        /// Construct an expression for the LEFT transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/left">read the docs on LEFT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableStringElement"/> to take the number of characters from.</param>
        /// <param name="characterCount">An expression of type <see cref="AnyElement{Int32}"/> providing the number of characters to return from the left of <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringLeftFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public NullableStringLeftFunctionExpression Left(NullableStringElement element, AnyElement<int> characterCount)
            => new(element, characterCount);

        /// <summary>
        /// Construct an expression for the LEFT transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/left">read the docs on LEFT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="StringElement"/> to take the number of characters from.</param>
        /// <param name="characterCount">An expression of type <see cref="AnyElement{Int32}"/>? providing the number of characters to return from the left of <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringLeftFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public NullableStringLeftFunctionExpression Left(StringElement element, AnyElement<int?> characterCount)
            => new(element, characterCount);
    }
}
