#region license
// Copyright (c) dbExpression.  All rights reserved.
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

﻿using DbExpression.Sql.Expression;

namespace DbExpression.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface WithAlias<TCaller>
#pragma warning restore IDE1006 // Naming Styles
    {
        /// <summary>
        /// Specify an alias for the expression.
        /// <para>
        /// Use the <paramref name="alias"/> value from this operation as the 'tableName' parameter when creating an <see cref="AliasExpression"/> 
        /// (for the joined sql SELECT query expression) for use with outer expressions:
        /// <code>dbex.alias({tableName}, {fieldName})</code>
        /// </para>
        /// </summary>
        /// <param name="alias">The alias to apply to the expression.</param>
        /// <returns><typeparamref name="TCaller"/>, a fluent continuation for the construction of a query expression.</returns>
        TCaller As(string alias);
    }
}
