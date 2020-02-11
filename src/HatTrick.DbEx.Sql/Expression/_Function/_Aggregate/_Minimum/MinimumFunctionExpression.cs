using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class MinimumFunctionExpression : AggregateFunctionExpression,
        IDbNumericFunctionExpression,
        IAssemblyPart,
        IDbExpressionIsDistinctProvider,
        ISupportedForFunctionExpression<CastFunctionExpression>,
        IEquatable<MinimumFunctionExpression>,
        ISupportedForSelectExpression
    {
        #region internals
        protected bool IsDistinct { get; private set; }
        #endregion

        #region interface
        bool IDbExpressionIsDistinctProvider.IsDistinct => IsDistinct;
        #endregion

        #region constructors
        protected MinimumFunctionExpression()
        {
        }

        protected MinimumFunctionExpression((Type,object) expression, bool isDistinct)
            : base(expression)
        {
            IsDistinct = isDistinct;
        }
        #endregion

        #region to string
        public override string ToString() => $"MIN({(IsDistinct ? "DISTINCT " : string.Empty)}{Expression})";
        #endregion

        #region equals
        public bool Equals(MinimumFunctionExpression obj)
        {
            if (!base.Equals(obj)) return false;
            if (this.IsDistinct != obj.IsDistinct) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is MinimumFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
