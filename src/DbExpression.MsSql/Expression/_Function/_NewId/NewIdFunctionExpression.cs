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

﻿using DbExpression.Sql;
using DbExpression.Sql.Expression;
using System;
using System.Collections.Generic;

namespace DbExpression.MsSql.Expression
{
    public partial class NewIdFunctionExpression : SystemFunctionExpression,
        IExpressionElement<Guid>,
        GuidElement,
        IEquatable<NewIdFunctionExpression>
    {
        #region constructors
        public NewIdFunctionExpression() : base(typeof(Guid))
        {

        }
        #endregion

        #region in
        public FilterExpression In(params Guid[] values)
           => new FilterExpression<bool>(this, new InExpression<Guid>(this, values), FilterExpressionOperator.None);

        public FilterExpression In(IEnumerable<Guid> values)
            => new FilterExpression<bool>(this, new InExpression<Guid>(this, values), FilterExpressionOperator.None);
        #endregion

        #region as
        public AliasedElement<Guid> As(string alias)
            => new SelectExpression<Guid>(this, alias);
        #endregion

        #region to string
        public override string ToString() => "NEWID()";
        #endregion

        #region equals
        public bool Equals(NewIdFunctionExpression? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is NewIdFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
