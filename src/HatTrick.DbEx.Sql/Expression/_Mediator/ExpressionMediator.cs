﻿using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ExpressionMediator : 
        IExpression,
        IExpressionAliasProvider,
        IEquatable<ExpressionMediator>
    {
        #region internals
        protected string Alias { get; private set; }
        #endregion

        #region interface
        public IExpression Expression { get; set; }
        string IExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        protected ExpressionMediator()
        {
        }

        public ExpressionMediator(IExpression expression) : this(expression, null)
        {
            Expression = expression ?? throw new ArgumentNullException($"{nameof(expression)} is required.");
        }

        protected ExpressionMediator(IExpression expression, string alias)
        {
            Expression = expression ?? throw new ArgumentNullException($"{nameof(expression)} is required.");
            Alias = string.IsNullOrWhiteSpace(alias) ? null : alias;
        }
        #endregion

        #region as
        public ExpressionMediator As(string alias)
            => new ExpressionMediator(Expression, alias);
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

            if (!StringComparer.Ordinal.Equals(Alias, obj.Alias)) return false;

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
                hash = (hash * multiplier) ^ (Alias is object ? Alias.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
