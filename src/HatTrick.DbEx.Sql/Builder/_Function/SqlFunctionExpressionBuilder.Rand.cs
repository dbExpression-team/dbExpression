#region license
// Copyright (c) HatTrick Lrandom, LLC.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/HatTrickLrandom/db-ex
#endregion

using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public partial class SqlFunctionExpressionBuilder
    {
        /// <summary>
        /// Construct an expression for the RAND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/rand?version=0.9.5">read the docs on RAND</see></para>
        /// </summary>
        /// <returns><see cref="SingleRandFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleRandFunctionExpression Rand()
            => new();

        /// <summary>
        /// Construct an expression for the RAND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/rand?version=0.9.5">read the docs on RAND</see></para>
        /// </summary>
        /// <param name="seed">An expression of type <see cref="Byte"/>, the seed to use for calculating the random value.</param>
        /// <returns><see cref="SingleRandFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleRandFunctionExpression Rand(byte seed)
            => new(new LiteralExpression<byte>(seed));

        /// <summary>
        /// Construct an expression for the RAND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/rand?version=0.9.5">read the docs on RAND</see></para>
        /// </summary>
        /// <param name="seed">An expression of type <see cref="Int16"/>, the seed to use for calculating the random value.</param>
        /// <returns><see cref="SingleRandFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleRandFunctionExpression Rand(short seed)
            => new(new LiteralExpression<short>(seed));

        /// <summary>
        /// Construct an expression for the RAND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/rand?version=0.9.5">read the docs on RAND</see></para>
        /// </summary>
        /// <param name="seed">An expression of type <see cref="Int32"/>, the seed to use for calculating the random value.</param>
        /// <returns><see cref="SingleRandFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleRandFunctionExpression Rand(int seed)
            => new(new LiteralExpression<int>(seed));

        /// <summary>
        /// Construct an expression for the RAND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/rand?version=0.9.5">read the docs on RAND</see></para>
        /// </summary>
        /// <param name="seed">An expression of type <see cref="ByteElement"/>, the seed to use for calculating the random value.</param>
        /// <returns><see cref="SingleRandFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleRandFunctionExpression Rand(ByteElement seed)
            => new(seed);

        /// <summary>
        /// Construct an expression for the RAND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/rand?version=0.9.5">read the docs on RAND</see></para>
        /// </summary>
        /// <param name="seed">An expression of type <see cref="NullableByteElement"/>, the seed to use for calculating the random value.</param>
        /// <returns><see cref="NullableSingleRandFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleRandFunctionExpression Rand(NullableByteElement seed)
            => new(seed);

        /// <summary>
        /// Construct an expression for the RAND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/rand?version=0.9.5">read the docs on RAND</see></para>
        /// </summary>
        /// <param name="seed">An expression of type <see cref="Int16Element"/>, the seed to use for calculating the random value.</param>
        /// <returns><see cref="SingleRandFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleRandFunctionExpression Rand(Int16Element seed)
            => new(seed);

        /// <summary>
        /// Construct an expression for the RAND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/rand?version=0.9.5">read the docs on RAND</see></para>
        /// </summary>
        /// <param name="seed">An expression of type <see cref="NullableInt16Element"/>, the seed to use for calculating the random value.</param>
        /// <returns><see cref="NullableSingleRandFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleRandFunctionExpression Rand(NullableInt16Element seed)
            => new(seed);

        /// <summary>
        /// Construct an expression for the RAND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/rand?version=0.9.5">read the docs on RAND</see></para>
        /// </summary>
        /// <param name="seed">An expression of type <see cref="Int32Element"/>, the seed to use for calculating the random value.</param>
        /// <returns><see cref="SingleRandFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleRandFunctionExpression Rand(Int32Element seed)
            => new(seed);

        /// <summary>
        /// Construct an expression for the RAND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/rand?version=0.9.5">read the docs on RAND</see></para>
        /// </summary>
        /// <param name="seed">An expression of type <see cref="NullableInt32Element"/>, the seed to use for calculating the random value.</param>
        /// <returns><see cref="NullableSingleRandFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleRandFunctionExpression Rand(NullableInt32Element seed)
            => new(seed);
    }
}
