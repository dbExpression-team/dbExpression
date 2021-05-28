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
using System.Linq;

namespace HatTrick.DbEx.Sql
{
    public class SqlOutputParameterList : List<ISqlOutputParameter>, ISqlOutputParameterList
    {
        /// <inheritdoc/>
        public ISqlOutputParameter this[string parameterName]
        {
            get
            {
                if ((parameterName?.Length ?? 0) == 0)
                    return null;

                if (parameterName[0] == '@')
                    return this.SingleOrDefault(x => x.Name == parameterName);

                parameterName = $"@{parameterName}";
                return this.SingleOrDefault(x => x.Name == parameterName);
            }
        }

        /// <inheritdoc/>
        public ISqlOutputParameter FindByName(string name)
            => this[name];
    }
}
