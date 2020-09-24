using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ExpressionMediator<TValue> : ExpressionMediator
    {
        #region constructors
        protected ExpressionMediator()
        {
        }

        public ExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected ExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public new ExpressionMediator<TValue> As(string alias) 
            => new ExpressionMediator<TValue>(Expression, alias);
        #endregion
    }
}
