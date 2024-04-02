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

using DbExpression.Sql.Builder;
using System.Collections.Generic;

namespace DbExpression.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface UnionSelectDynamicsContinuation<TDatabase> :
#pragma warning restore IDE1006 // Naming Styles
        IExpressionBuilder<TDatabase> 
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Continue a sql SELECT query expression for a list of <see cref="System.Dynamic.ExpandoObject" /> object.  The properties of the object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/select-statement">read the docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element1">Any expression</param>
        /// <param name="element2">Any expression</param>
        /// <param name="elements">Any expression</param>
        /// <returns><see cref="SelectDynamics{TDatabase}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectDynamics<TDatabase> SelectOne(AnyElement element1, AnyElement element2, params AnyElement[] elements);

        /// <summary>
        /// Continue a sql SELECT query expression for a list of <see cref="System.Dynamic.ExpandoObject" /> object.  The properties of the object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/select-statement">read the docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element1">Any expression</param>
        /// <param name="elements">A list of any expression</param>
        /// <returns><see cref="SelectDynamics{TDatabase}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectDynamics<TDatabase> SelectOne(IEnumerable<AnyElement> elements);

        /// <summary>
        /// Continue a sql SELECT query expression for a list of <see cref="System.Dynamic.ExpandoObject" /> object.  The properties of the object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/select-statement">read the docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="elements">A list of any expression that is valid for a SELECT query expression.</param>
        /// <param name="additionalElements">Any additional fields to select as part of the SELECT query expression.</param>
        /// <returns><see cref="SelectDynamics{TDatabase}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectDynamics<TDatabase> SelectOne(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements);

        /// <summary>
        /// Continue a sql SELECT query expression for a list of <see cref="System.Dynamic.ExpandoObject" /> objects.  The dynamic properties of each object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/select-statement">read the docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element1">Any expression</param>
        /// <param name="element2">Any expression</param>
        /// <param name="elements">Any expression</param>
        /// <returns><see cref="SelectDynamics{TDatabase}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectDynamics<TDatabase> SelectMany(AnyElement element1, AnyElement element2, params AnyElement[] elements);

        /// <summary>
        /// Continue a sql SELECT query expression for a list of <see cref="System.Dynamic.ExpandoObject" /> objects.  The dynamic properties of each object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/select-statement">read the docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="elements">A list of any expression</param>
        /// <returns><see cref="SelectDynamics{TDatabase}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectDynamics<TDatabase> SelectMany(IEnumerable<AnyElement> elements);

        /// <summary>
        /// Continue a sql SELECT query expression for a list of <see cref="System.Dynamic.ExpandoObject" /> objects.  The dynamic properties of each object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/select-statement">read the docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="elements">A list of any expression that is valid for a SELECT query expression.</param>
        /// <param name="additionalElements">Any additional fields to select as part of the SELECT query expression.</param>
        /// <returns><see cref="SelectDynamics{TDatabase}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectDynamics<TDatabase> SelectMany(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements);
    }
}
