using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class PopulationVarianceFunctionExpression : AggregateFunctionExpression,
        IExpressionIsDistinctProvider,
        IEquatable<PopulationVarianceFunctionExpression>
    {
        #region internals
        protected bool IsDistinct { get; private set; }
        #endregion

        #region interface
        bool IExpressionIsDistinctProvider.IsDistinct => IsDistinct;
        #endregion

        #region constructors
        protected PopulationVarianceFunctionExpression(ExpressionMediator expression, bool isDistinct) : base(expression)
        {
            IsDistinct = isDistinct;
        }
        #endregion

        #region to string
        public override string ToString() => $"VARP({(IsDistinct ? "DISTINCT " : string.Empty)}{Expression})";
        #endregion

        #region equals
        public bool Equals(PopulationVarianceFunctionExpression obj)
        {
            if (!base.Equals(obj)) return false;

            if (this.IsDistinct != obj.IsDistinct) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is PopulationVarianceFunctionExpression exp ? Equals(exp) : false;

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
