using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class DbTypeExpression : IExpressionElement,
        IEquatable<DbTypeExpression>
    {
        #region interface
        public object Expression { get; }
        #endregion

        #region constructors
        protected DbTypeExpression(object value)
        {
            Expression = value;
        }
        #endregion

        #region to string
        public override string ToString() => Expression.ToString();
        #endregion

        #region equals
        public bool Equals(DbTypeExpression obj)
        {
            if (this.Expression is null && obj.Expression is object) return false;
            if (this.Expression is object && obj.Expression is null) return false;
            if (!this.Expression.Equals(obj.Expression)) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is DbTypeExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => Expression is object ? Expression.GetHashCode() : 0;
        #endregion
    }
}
