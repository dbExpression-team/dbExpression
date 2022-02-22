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

namespace HatTrick.DbEx.Sql.Expression
{
    public class SelectExpression : 
        AnyElement,
        IExpressionTypeProvider,
        IExpressionAliasProvider
    {
        #region internals
        protected string Alias { get; set; }
        protected bool IsDistinct { get; private set; }
        #endregion

        #region interface
        public IExpressionElement Expression { get; }
        Type IExpressionTypeProvider.DeclaredType => (Expression as IExpressionTypeProvider).DeclaredType;
        string IExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        public SelectExpression(IExpressionElement expression) : this(expression, null)
        {

        }

        public SelectExpression(IExpressionElement expression, string alias)
        {
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
            this.Alias = alias;
        }
        #endregion

        #region order by
        OrderByExpression AnyElement.Asc => throw new DbExpressionException("Select expressions cannot be used in Order By clauses.");

        OrderByExpression AnyElement.Desc => throw new DbExpressionException("Select expressions cannot be used in Order By clauses.");
        #endregion

        #region to string
        public override string ToString() => Expression.ToString();
        #endregion

        #region logical & operator
        public static SelectExpressionSet operator &(SelectExpression a, SelectExpression b) => new SelectExpressionSet(a, b);
        #endregion

        #region implicit select expression set operator
        public static implicit operator SelectExpressionSet(SelectExpression a) => new SelectExpressionSet(a);
        #endregion

        #region equals
        public bool Equals(SelectExpression obj)
        {
            if (obj is null) return false;

            if (Expression is null && obj.Expression is object) return false;
            if (Expression is object && obj.Expression is null) return false;
            if (!Expression.Equals(obj.Expression)) return false;

            if (IsDistinct != obj.IsDistinct) return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SelectExpression other)) return false;
            return Equals(other);
        }

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
