﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class CoalesceFunctionExpression : DataTypeFunctionExpression,
        IDbFunctionExpression,
        IEquatable<CoalesceFunctionExpression>
    {
        #region interface
        public new IList<ExpressionMediator> Expression { get; private set; }
        #endregion

        #region constructors
        protected CoalesceFunctionExpression(params ExpressionMediator[] expressions) : base()
        {
            Expression = expressions.ToList();
        }
        #endregion

        #region to string
        public override string ToString() => $"COALESCE({string.Join(", ", Expression)})";
        #endregion

        #region equals
        public bool Equals(CoalesceFunctionExpression obj)
        {
            if (!base.Equals(obj)) return false;

            if (Expression.Count != obj.Expression.Count) return false;

            foreach (var exp in Expression)
                if (!obj.Expression.Any(e => e.Equals(exp))) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is CoalesceFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
