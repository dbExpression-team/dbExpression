using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class LiteralExpression :
        IExpression,
        IEquatable<LiteralExpression>
    {
        private object _expression;

        #region interface
        public object Expression => _expression ?? DBNull.Value;
        #endregion

        #region constructors
        protected LiteralExpression(object expression)
        {
            _expression = expression;
        }
        #endregion

        #region tostring
        public override string ToString()
        {
            if (Expression is null)
                return "null";

            if (!(Expression is string))
                return Expression.ToString();

            string exp = Expression as string;
            if (exp.All(char.IsWhiteSpace)) return $"'{Expression}'";

            return Expression.ToString();
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
