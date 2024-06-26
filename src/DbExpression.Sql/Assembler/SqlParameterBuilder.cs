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

using DbExpression.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data;

namespace DbExpression.Sql.Assembler
{
    public abstract class SqlParameterBuilder
    {
        #region interface
        public virtual IList<ParameterizedExpression> Parameters { get; set; } = new List<ParameterizedExpression>();
        #endregion

        #region methods
        public virtual void AddParameter(ParameterizedExpression parameter)
        {
            if (!Parameters.Contains(parameter))
                Parameters.Add(parameter);
        }

        protected virtual ParameterizedExpression? FindExistingParameter<T>(T value, Type declaredType, DbType dbType, ParameterDirection direction, int? size, byte? precision, byte? scale)
        {
            foreach (var parameter in Parameters)
            {
                if (parameter.Parameter.Direction != direction)
                    continue;

                if (size.HasValue && !(parameter.Parameter.Size == size.Value))
                    continue;
                if (precision.HasValue && !(parameter.Parameter.Precision == precision.Value))
                    continue;
                if (scale.HasValue && !(parameter.Parameter.Scale == scale.Value))
                    continue;

                if (parameter.DeclaredType != declaredType)
                    continue;

                if (parameter.Parameter.DbType != dbType)
                    continue;

                if (value is null || value is DBNull)
                {
                    if (parameter.Parameter.Value == DBNull.Value)
                        return parameter; //both null/DBNull, parameters are equivalent
                    continue;
                }

                if (parameter.Parameter.Value is DBNull)
                    continue;  //parameter value is DBNull, continue before type conversion (DBNull will fail type conversion)

                if (!Convert.ChangeType(parameter.Parameter.Value!, parameter.DeclaredType).Equals(Convert.ChangeType(value, declaredType)))
                    continue;

                return parameter;
            }
            return default;
        }
        #endregion
    }
}
