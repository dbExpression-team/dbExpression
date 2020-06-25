using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class LiteralExpression :
        IEquatable<LiteralExpression>
    {
        #region interface
        public ExpressionContainer Expression { get; private set; }
        #endregion

        #region constructors
        protected LiteralExpression(ExpressionContainer expression)
        {
            Expression = expression ?? throw new ArgumentNullException($"{nameof(expression)} is required.");
        }
        #endregion

        #region equals
        public bool Equals(LiteralExpression obj)
        {
            if (obj is null) return false;

            if (Expression is null && obj.Expression is object) return false;
            if (Expression is object && obj.Expression is null) return false;
            if (!Expression.Equals(obj.Expression)) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is LiteralExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (Expression is object ? Expression.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
