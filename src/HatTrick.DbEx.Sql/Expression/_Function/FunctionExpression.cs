using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class FunctionExpression :
        IExpression,
        IExpressionAliasProvider,
        IEquatable<FunctionExpression>
    {
        #region internals
        protected string Alias { get; private set; }
        #endregion

        #region interface
        public IExpression Expression { get; }
        string IExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        protected FunctionExpression()
        {
        }

        protected FunctionExpression(ExpressionMediator expression)
        {
            Expression = expression ?? throw new ArgumentNullException($"{nameof(expression)} is required.");
        }
        #endregion

        #region order
        public abstract OrderByExpression Asc { get; }
        public abstract OrderByExpression Desc { get; }
        #endregion

        #region as
        public FunctionExpression As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(FunctionExpression obj)
        {
            if (Expression is null && obj.Expression is object) return false;
            if (Expression is object && obj.Expression is null) return false;
            if (!Expression.Equals(obj.Expression)) return false;

            if (!StringComparer.Ordinal.Equals(Alias, obj.Alias)) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is FunctionExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (Expression is object ? Expression.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (Alias is object ? Alias.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
