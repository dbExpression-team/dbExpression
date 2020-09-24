using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class SelectExpression : 
        IExpression,
        IExpressionAliasProvider
    {
        #region internals
        protected string alias;
        protected bool IsDistinct { get; private set; }
        #endregion

        #region interface
        public ExpressionMediator Expression { get; }
        string IExpressionAliasProvider.Alias => alias;
        #endregion

        #region constructors
        public SelectExpression(ExpressionMediator expression) : this(expression, null)
        {

        }

        protected SelectExpression(ExpressionMediator expression, string alias)
        {
            Expression = expression ?? throw new ArgumentNullException($"{nameof(expression)} is required");
            this.alias = alias;
        }
        #endregion

        #region as
        public SelectExpression As(string alias)
            => new SelectExpression(Expression, alias);
        #endregion

        #region to string
        public override string ToString() => Expression.ToString();
        #endregion

        #region logical & operator
        public static SelectExpressionSet operator &(SelectExpression a, SelectExpression b) => new SelectExpressionSet(a, b);
        #endregion

        #region implicit select expression set operator
        public static implicit operator SelectExpressionSet(SelectExpression a) => new SelectExpressionSet(a);
        #endregion

        #region equals
        public bool Equals(SelectExpression obj)
        {
            if (obj is null) return false;

            if (Expression is null && obj.Expression is object) return false;
            if (Expression is object && obj.Expression is null) return false;
            if (!Expression.Equals(obj.Expression)) return false;

            if (IsDistinct != obj.IsDistinct) return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SelectExpression other)) return false;
            return Equals(other);
        }

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
