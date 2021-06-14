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

using System.Collections.Generic;

namespace HatTrick.DbEx.Sql
{
    public interface ISqlOutputParameterList : IList<ISqlOutputParameter>
    {
        /// <summary>
        /// Gets the output parameter with the name provided by <paramref name="parameterName"/>.
        /// </summary>
        /// <param name="parameterName">The name of the output parameter.  The "@" prefix on the name is optional.</param>
        /// <returns></returns>
        ISqlOutputParameter this[string parameterName] { get; }
        /// <summary>
        /// Gets the output parameter with the name provided by <paramref name="parameterName"/>.
        /// </summary>
        /// <param name="parameterName">The name of the output parameter.  The "@" prefix is optional.</param>
        /// <returns>A <see cref="ISqlOutputParameter"/>, or null if no parameter with a name provided by <paramref name="parameterName"/> is found.</returns>
        /// <remarks>Output parameters can also be retrieved using an indexer.
        /// <example>
        /// <code>
        /// ISqlOutputList outputParameters;
        /// var parameter = outputParameters["P1"];
        /// </code>
        /// </example>
        /// </remarks>
        ISqlOutputParameter FindByName(string parameterName);
    }
}
