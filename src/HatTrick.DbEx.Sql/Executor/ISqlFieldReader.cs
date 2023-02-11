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

﻿using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Executor
{
    public interface ISqlFieldReader
    {
        /// <summary>
        /// Get a rowset field and increments the current field index.  The next call to this method would return the next field in the rowset.
        /// </summary>
        /// <returns>An <see cref="ISqlField"/> containing the retrieved value and metadata for the field.</returns>
        ISqlField? ReadField();

        /// <summary>
        /// Get a rowset field at the provided index.
        /// </summary>
        /// <returns>The <see cref="ISqlField"/> value of the field converted to <typeparamref name="T"/>.</returns>
        T GetValue<T>(int index);

        /// <summary>
        /// Gets the total number of fields in the rowset.
        /// </summary>
        int FieldCount { get; }

        /// <summary>
        /// Gets the current index of the reader.  The index value is incremented only through a call to the <see cref="ReadField"/> method.
        /// </summary>
        int CurrentFieldIndex { get; }
    }
}
