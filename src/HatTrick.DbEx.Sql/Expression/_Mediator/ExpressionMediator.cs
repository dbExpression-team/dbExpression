using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class ExpressionMediator : 
        AnyElement,
        IFilterExpressionElement,
        AnyOrderByClause,
        AnyGroupByClause,
        IExpressionTypeProvider,
        IExpressionAliasProvider,
        IEquatable<ExpressionMediator>
    {
        #region internals
        private Type declaredType;
        private string alias;
        #endregion

        #region interface
        public IExpressionElement Expression { get; set; }
        Type IExpressionTypeProvider.DeclaredType => declaredType;
        string IExpressionAliasProvider.Alias => alias;
        #endregion

        #region constructors
        protected ExpressionMediator()
        {
        }

        protected ExpressionMediator(IExpressionElement expression, Type declaredType) : this(expression, declaredType, null)
        {

        }

        protected ExpressionMediator(IExpressionElement expression, Type declaredType, string alias)
        {
            Expression = expression ?? throw new ArgumentNullException($"{nameof(expression)} is required.");
            this.declaredType = declaredType ?? throw new ArgumentNullException($"{nameof(declaredType)} is required.");
            this.alias = string.IsNullOrWhiteSpace(alias) ? null : alias;
        }
        #endregion

        #region order
        public virtual OrderByExpression Asc => new OrderByExpression(this, OrderExpressionDirection.ASC);
        public virtual OrderByExpression Desc => new OrderByExpression(this, OrderExpressionDirection.DESC);
        #endregion

        #region tostring
        public override string ToString() => Expression?.ToString();
        #endregion

        #region equals
        public bool Equals(ExpressionMediator obj)
        {
            if (obj is null) return false;

            if (Expression is null && obj.Expression is object) return false;
            if (Expression is object && obj.Expression is null) return false;
            if (!Expression.Equals(obj.Expression)) return false;

            if (declaredType != obj.declaredType) return false;
            if (!StringComparer.Ordinal.Equals(alias, obj.alias)) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is ExpressionMediator exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (Expression is object ? Expression.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (declaredType is object ? declaredType.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (alias is object ? alias.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
