using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class ExpressionMediator<TValue> : ExpressionMediator
    {
        #region constructors
        protected ExpressionMediator()
        {
        }

        protected ExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected ExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public override ExpressionMediator As(string alias) => throw new NotImplementedException("Expected concrete type to override the As method.");
        #endregion
    }
}
