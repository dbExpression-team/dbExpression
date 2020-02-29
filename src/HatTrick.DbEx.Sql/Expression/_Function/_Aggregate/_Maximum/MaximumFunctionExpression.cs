using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class MaximumFunctionExpression : AggregateFunctionExpression,
        IDbExpressionIsDistinctProvider,
        IEquatable<MaximumFunctionExpression>
    {
        #region internals
        protected bool IsDistinct { get; private set; }
        #endregion

        #region interface
        bool IDbExpressionIsDistinctProvider.IsDistinct => IsDistinct;
        #endregion

        #region constructors
        protected MaximumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression)
        {
            IsDistinct = isDistinct;
        }
        #endregion

        #region to string
        public override string ToString() => $"MAX({(IsDistinct ? "DISTINCT " : string.Empty)}{Expression})";
        #endregion

        #region equals
        public bool Equals(MaximumFunctionExpression obj)
        {
            if (!base.Equals(obj)) return false;

            if (this.IsDistinct != obj.IsDistinct) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is MaximumFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
        {
            unchecked
            {
                const int multiplier = 16777619;

                int hash = base.GetHashCode();
                hash = (hash * multiplier) ^ IsDistinct.GetHashCode();
                return hash;
            }
        }
        #endregion
    }
}
