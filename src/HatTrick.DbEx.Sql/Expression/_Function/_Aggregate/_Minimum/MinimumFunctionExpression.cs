using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class MinimumFunctionExpression : AggregateFunctionExpression,
        IExpressionIsDistinctProvider,
        IEquatable<MinimumFunctionExpression>
    {
        #region internals
        protected bool IsDistinct { get; set; }
        #endregion

        #region interface
        bool IExpressionIsDistinctProvider.IsDistinct => IsDistinct;
        #endregion

        #region constructors
        protected MinimumFunctionExpression(IExpressionElement expression, Type declaredType) : base(expression, declaredType)
        {

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
