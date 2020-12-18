using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class RawExpression :
        ObjectElement,
        IEquatable<RawExpression>
    {
        #region interface
        public string Expression { get; private set; }

        public OrderByExpression Asc => new OrderByExpression(this, OrderExpressionDirection.ASC);

        public OrderByExpression Desc => new OrderByExpression(this, OrderExpressionDirection.DESC);
        #endregion

        #region constructors
        public RawExpression(string expression)
        {
            Expression = expression;
        }
        #endregion

        #region as
        public ObjectElement As(string alias)
            => new ObjectSelectExpression(this).As(alias);
        #endregion

        #region tostring
        public override string ToString() => Expression ?? "null";
        #endregion

        #region equals
        public bool Equals(RawExpression obj)
        {
            if (obj is null) return false;

            if (Expression is null && obj.Expression is object) return false;
            if (Expression is object && obj.Expression is null) return false;
            if (!StringComparer.OrdinalIgnoreCase.Equals(Expression, obj.Expression)) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is RawExpression exp && Equals(exp);

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
