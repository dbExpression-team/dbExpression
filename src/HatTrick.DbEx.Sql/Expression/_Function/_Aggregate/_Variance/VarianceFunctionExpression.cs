using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class VarianceFunctionExpression : AggregateFunctionExpression,
        IDbExpressionIsDistinctProvider,
        IEquatable<VarianceFunctionExpression>
    {
        #region internals
        protected bool IsDistinct { get; private set; }
        #endregion

        #region interface
        bool IDbExpressionIsDistinctProvider.IsDistinct => IsDistinct;
        #endregion

        #region constructors
        protected VarianceFunctionExpression(ExpressionMediator expression, bool isDistinct) : base(expression)
        {
            IsDistinct = isDistinct;
        }
        #endregion

        #region to string
        public override string ToString() => $"VAR({(IsDistinct ? "DISTINCT " : string.Empty)}{Expression})";
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
