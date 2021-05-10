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

﻿using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Executor
{
    public class Row : ISqlFieldReader
    {
        #region internals
        private int fieldIndex;
        private IList<ISqlField> fields;
        #endregion

        #region interface
        public int Index { get; private set; }
        public int FieldCount => fields.Count;
        public int CurrentFieldIndex => fieldIndex;
        #endregion

        #region constructors
        public Row(int index, IList<ISqlField> fields)
        {
            Index = index;
            this.fields = fields ?? throw new ArgumentNullException(nameof(fields));
        }
        #endregion

        #region methods
        public ISqlField ReadField() => fieldIndex >= fields.Count ? null : fields[fieldIndex++];

        public T GetValue<T>(int index)
        {
            var field = fields[index];
            if (field.RawValue == default)
                return default;
            return field.GetValue<T>();
        }

        public IEnumerable<ISqlField> GetFields() => fields;
        #endregion
    }
}
