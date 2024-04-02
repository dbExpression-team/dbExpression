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

using DbExpression.Sql.Executor;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace DbExpression.Sql.Mapper
{
    public class ExpandoObjectMapper : IExpandoObjectMapper
    {
        public void Map(ExpandoObject expandoObject, ISqlFieldReader reader)
        {
            var expando = expandoObject as IDictionary<string, object?>;
            ISqlField? field;
            while ((field = reader.ReadField()) is not null)
            {
                if (string.IsNullOrWhiteSpace(field.Name))
                    throw new DbExpressionException($"A field name or alias has not been supplied for field index {field.Index}, therefore the retrieved value can't be mapped to a property of the dynamic object.");

                expando.Add(field.Name, field.GetValue());
            }
        }
    }
}

