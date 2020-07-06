using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class ConcatFunctionExpression : DataTypeFunctionExpression,
        IEquatable<ConcatFunctionExpression>
    {
        #region interface
        public new IList<ExpressionMediator> Expression { get; private set; }
        #endregion

        #region constructors
        protected ConcatFunctionExpression(params ExpressionMediator[] expressions) : base()
        {
            Expression = expressions.ToList();
        }
        #endregion

        #region to string
        public override string ToString() => $"CONCAT({string.Join(", ", Expression)})";
        #endregion

        #region equals
        public bool Equals(ConcatFunctionExpression obj)
        {
            if (!base.Equals(obj)) return false;

            if (Expression.Count != obj.Expression.Count) return false;

            foreach (var exp in Expression)
                if (!obj.Expression.Any(e => e.Equals(exp))) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is ConcatFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
