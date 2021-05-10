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

﻿using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Expression
{
    public partial class GetDateFunctionExpression : DataTypeFunctionExpression,
        IExpressionElement<DateTime>,
        AnyDateTimeElement,
        DateTimeElement,
        IEquatable<GetDateFunctionExpression>
    {
        #region constructors
        public GetDateFunctionExpression() : base(typeof(DateTime))
        { 
        
        }
        #endregion

        #region methods
        #region as
        public DateTimeElement As(string alias)
            => new DateTimeSelectExpression(this).As(alias);
        #endregion

        #region to string
        public override string ToString() => "GETDATE()";
        #endregion

        #region equals
        public bool Equals(GetDateFunctionExpression obj)
            => base.Equals(obj); 

        public override bool Equals(object obj)
            => obj is GetDateFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
        #endregion
    }
}
