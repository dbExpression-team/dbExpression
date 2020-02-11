using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class AverageFunctionExpression : AggregateFunctionExpression,
        IDbNumericFunctionExpression,
        IAssemblyPart,
        IDbExpressionIsDistinctProvider,
        ISupportedForExpression<SelectExpression>,
        ISupportedForFunctionExpression<CastFunctionExpression>,
        ISupportedForFunctionExpression<DateDiffFunctionExpression, int>,
        IEquatable<AverageFunctionExpression>
    {
        #region internals
        protected bool IsDistinct { get; private set; }
        #endregion

        #region interface
        bool IDbExpressionIsDistinctProvider.IsDistinct => IsDistinct;
        #endregion

        #region constructors
        protected AverageFunctionExpression()
        {
        }

        protected AverageFunctionExpression((Type,object) expression, bool isDistinct) : base(expression)
        {
            IsDistinct = isDistinct;
        }
        #endregion

        #region to string
        public override string ToString() => $"AVG({(IsDistinct ? "DISTINCT " : string.Empty)}{Expression.Item2})";
        #endregion

        #region equals
        public bool Equals(AverageFunctionExpression obj)
        {
            if (!base.Equals(obj)) return false;
            if (this.IsDistinct != obj.IsDistinct) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is AverageFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
