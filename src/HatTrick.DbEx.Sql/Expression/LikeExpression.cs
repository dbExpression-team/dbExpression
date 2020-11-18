using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class LikeExpression :
        IExpressionElement,
        IEquatable<LikeExpression>
    {
        #region interface
        public string Expression { get; set; }
        #endregion

        #region constructors
        public LikeExpression(string searchPhrase)
        {
            if (string.IsNullOrWhiteSpace(searchPhrase))
                throw new ArgumentException($"{nameof(searchPhrase)} is required and must have one or more characters.");

            Expression = searchPhrase;
        }
        #endregion

        #region tostring
        public override string ToString()
            => $"LIKE ({Expression})";
        #endregion

        #region equals
        public bool Equals(LikeExpression obj)
        {
            if (obj is null) return false;

            if (Expression is null && obj.Expression is object) return false;
            if (Expression is object && obj.Expression is null) return false;
            if (!Expression.Equals(obj.Expression)) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is LikeExpression exp && Equals(exp);

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
