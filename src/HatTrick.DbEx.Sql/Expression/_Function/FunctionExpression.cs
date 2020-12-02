using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class FunctionExpression :
        AnyElement,
        AnyOrderByClause,
        IFunctionExpression,
        IExpressionAliasProvider,
        IExpressionTypeProvider,
        IEquatable<FunctionExpression>
    {
        #region internals
        protected Type DeclaredType { get; private set; }
        protected string Alias { get; set; }
        #endregion

        #region interface
        public IExpressionElement Expression { get; }
        string IExpressionAliasProvider.Alias => Alias;
        Type IExpressionTypeProvider.DeclaredType => DeclaredType;
        #endregion

        #region constructors
        private FunctionExpression()
        {
        }

        protected FunctionExpression(IExpressionElement expression, Type declaredType)
        {
            Expression = expression; //expression may be fully managed in subclass
            DeclaredType = declaredType ?? throw new ArgumentNullException($"{nameof(declaredType)} is required.");
        }
        #endregion

        #region order
        public OrderByExpression Asc => new OrderByExpression(this, OrderExpressionDirection.ASC);
        public OrderByExpression Desc => new OrderByExpression(this, OrderExpressionDirection.DESC);
        #endregion

        #region equals
        public bool Equals(FunctionExpression obj)
        {
            if (Expression is null && obj.Expression is object) return false;
            if (Expression is object && obj.Expression is null) return false;
            if (!Expression.Equals(obj.Expression)) return false;
            if (DeclaredType != obj.DeclaredType) return false;
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
                hash = (hash * multiplier) ^ (DeclaredType is object ? DeclaredType.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (Alias is object ? Alias.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        #region implicit operators
        public static implicit operator OrderByExpression(FunctionExpression a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        #endregion
    }
}
