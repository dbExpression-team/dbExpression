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

﻿using System;

namespace DbExpression.Sql.Expression
{
    public abstract class DbTypeExpression : IExpressionElement,
        IEquatable<DbTypeExpression>
    {
        #region interface
        public object Expression { get; }
        #endregion

        #region constructors
        protected DbTypeExpression(object value)
        {
            Expression = value;
        }
        #endregion

        #region to string
        public override string? ToString() => Expression.ToString();
        #endregion

        #region equals
        public bool Equals(DbTypeExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (!Expression.Equals(obj.Expression)) return false;
            
            return true;
        }

        public override bool Equals(object? obj)
         => obj is DbTypeExpression exp && Equals(exp);

        public override int GetHashCode()
            => Expression is not null ? Expression.GetHashCode() : 0;
        #endregion
    }
}
