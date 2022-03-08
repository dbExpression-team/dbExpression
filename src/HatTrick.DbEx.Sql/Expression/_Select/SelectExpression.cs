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
        protected string? Alias { get; set; }
        protected bool IsDistinct { get; private set; }
        #endregion

        #region interface
        public IExpressionElement Expression { get; }
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        Type IExpressionTypeProvider.DeclaredType => (Expression as IExpressionTypeProvider).DeclaredType; //TODO: interface
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        string? IExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        public SelectExpression(IExpressionElement expression) : this(expression, null)
        {

        }

        public SelectExpression(IExpressionElement expression, string? alias)
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
        public override string? ToString() => Expression.ToString();
        #endregion

        #region logical & operator
        public static SelectExpressionSet operator &(SelectExpression a, SelectExpression b) => new(a, b);
        #endregion

        #region implicit select expression set operator
        public static implicit operator SelectExpressionSet(SelectExpression a) => new(a);
        #endregion

        #region equals
        public bool Equals(SelectExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (Expression is null && obj.Expression is not null) return false;
            if (Expression is not null && obj.Expression is null) return false;
            if (Expression is not null && !Expression.Equals(obj.Expression)) return false;

            if (IsDistinct != obj.IsDistinct) return false;

            if (Alias is not null && !Alias.Equals(obj.Alias)) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is SelectExpression exp && Equals(exp);


        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (Expression is not null ? Expression.GetHashCode() : 0);
                hash = (hash * multiplier) ^ IsDistinct.GetHashCode();
                hash = (hash * multiplier) ^ (Alias is not null ? Alias.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
