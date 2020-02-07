using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class VarianceFunctionExpression : AggregateFunctionExpression,
        IDbNumericFunctionExpression,
        IAssemblyPart,
        IDbExpressionIsDistinctProvider,
        ISupportedForFunctionExpression<CastFunctionExpression>,
        ISupportedForFunctionExpression<CastFunctionExpression, double>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, double>,
        ISupportedForFunctionExpression<ConcatFunctionExpression, double>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, double>,
        IEquatable<VarianceFunctionExpression>,
        ISupportedForSelectExpression
    {
        #region internals
        protected bool IsDistinct { get; private set; }
        #endregion

        #region interface
        bool IDbExpressionIsDistinctProvider.IsDistinct => IsDistinct;
        #endregion

        #region constructors
        protected VarianceFunctionExpression()
        {
        }

        public VarianceFunctionExpression((Type,object) expression, bool isDistinct)
            : base(expression)
        {
            IsDistinct = isDistinct;
        }
        #endregion

        #region to string
        public override string ToString() => $"VAR({(IsDistinct ? "DISTINCT " : string.Empty)}{Expression.Item2})";
        #endregion

        #region equals
        public bool Equals(VarianceFunctionExpression obj)
        {
            if (!base.Equals(obj)) return false;
            if (this.IsDistinct != obj.IsDistinct) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is VarianceFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        public static implicit operator OrderByExpression(VarianceFunctionExpression variance) => new OrderByExpression((variance.GetType(), variance), OrderExpressionDirection.ASC);
        #endregion
    }
}
