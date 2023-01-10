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

using HatTrick.DbEx.Sql.Converter;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Executor
{
    internal sealed class FieldTemplatedValueConverterProviderDecorator : IValueConverterProvider
    {
        #region internals
        private Dictionary<int, Type>? objectToTypeMap;
        private readonly ISqlField[] fieldTemplates;
        private readonly IValueConverterProvider decorated;
        #endregion

        #region constructors
        public FieldTemplatedValueConverterProviderDecorator(ISqlField[] fieldTemplates, IValueConverterProvider decorated)
        {
            this.fieldTemplates = fieldTemplates ?? throw new ArgumentNullException(nameof(fieldTemplates));
            this.decorated = decorated ?? throw new ArgumentNullException(nameof(decorated));
        }
        #endregion

        #region methods
        public IValueConverter? FindConverter(int fieldIndex, Type requestedType, object value)
        {
            if (requestedType == typeof(object))
            {
                objectToTypeMap ??= new();

                if (objectToTypeMap.TryGetValue(fieldIndex, out Type? type))
                {
                    requestedType = type!;
                }
                else
                {
                    requestedType = fieldTemplates[fieldIndex].DataType.IsConvertibleToNullableType() ? typeof(Nullable<>).MakeGenericType(fieldTemplates[fieldIndex].DataType) : fieldTemplates[fieldIndex].DataType;
                    objectToTypeMap.Add(fieldIndex, requestedType);
                }
            }

            return decorated.FindConverter(fieldIndex, requestedType, value);
        }
        #endregion
    }
}

