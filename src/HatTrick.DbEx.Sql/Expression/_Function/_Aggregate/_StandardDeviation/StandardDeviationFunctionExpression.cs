using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class StandardDeviationFunctionExpression : AggregateFunctionExpression,
        IExpressionIsDistinctProvider,
        IEquatable<StandardDeviationFunctionExpression>
    {
        #region internals
        protected bool IsDistinct { get; private set; }
        #endregion

        #region interface
        bool IExpressionIsDistinctProvider.IsDistinct => IsDistinct;
        #endregion

        #region constructors
        protected StandardDeviationFunctionExpression(IExpressionElement expression, Type declaredType, bool isDistinct) : this(expression, declaredType, isDistinct, null)
        {

        }

        protected StandardDeviationFunctionExpression(IExpressionElement expression, Type declaredType, bool isDistinct, string alias) : base(expression, declaredType, alias)
        {
            IsDistinct = isDistinct;
        }
        #endregion

        #region to string
        public override string ToString() => $"STDEV({(IsDistinct ? "DISTINCT " : string.Empty)}{Expression})";
        #endregion

        #region equals
        public bool Equals(StandardDeviationFunctionExpression obj)
        {
            if (!base.Equals(obj)) return false;

            if (this.IsDistinct != obj.IsDistinct) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is StandardDeviationFunctionExpression exp ? Equals(exp) : false;

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
